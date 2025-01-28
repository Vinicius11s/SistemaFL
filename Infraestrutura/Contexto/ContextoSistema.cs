using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Contexto
{
    public class ContextoSistema : DbContext
    {
        public ContextoSistema()
        {
            this.Database.EnsureCreated();
        }       

        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Flat> Flat { get; set; }
        public DbSet<Lancamento> Lancamento { get; set; }
        public DbSet<Ocorrencia> Ocorrencia { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Server Master = DESKTOP-6RMV3GQ
            //Server Local = DESKTOP-I32AP0S
            var stringConexao = @"Server=DESKTOP-6RMV3GQ;Database=DBSISFLATS01;Integrated Security=True;TrustServerCertificate=True;";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(stringConexao);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração das entidades de Empresa
            modelBuilder.Entity<Empresa>(e =>   
            {
                e.Property(e => e.Descricao).IsRequired().HasMaxLength(150);
                e.Property(e => e.Cnpj).HasMaxLength(14);

                e.Property(e => e.Rua).IsRequired().HasMaxLength(100);
                e.Property(e => e.Numero).IsRequired().HasMaxLength(10);
                e.Property(e => e.Bairro).HasMaxLength(50);
                e.Property(e => e.Cidade).IsRequired().HasMaxLength(50);
                e.Property(e => e.Estado).IsRequired().HasMaxLength(2);
                e.Property(e => e.Cep).IsRequired().HasMaxLength(9);

                e.Property(e => e.InscricaoEstadual).HasMaxLength(20);
                e.Property(e => e.RazaoSocial).HasMaxLength(150);
            });

            // Configuração das entidades de Flat
            modelBuilder.Entity<Flat>(f =>
            {
                f.Property(f => f.DataAquisicao).IsRequired();
                f.Property(f => f.Descricao).HasMaxLength(200) .IsRequired(); 
                f.Property(f => f.TipoInvestimento).HasMaxLength(100) .IsRequired(false);
                f.Property(f => f.Rua).HasMaxLength(100).IsRequired(false); 
                f.Property(f => f.Bairro).HasMaxLength(50).IsRequired(false); 
                f.Property(f => f.Cidade).HasMaxLength(50) .IsRequired(false);
                f.Property(f => f.ValorDeCompra).HasColumnType("decimal(18,2)");
                f.Property(f => f.Status).IsRequired();
                f.Property(f => f.Unidade).IsRequired();

                f.HasOne(f => f.Empresa)
                    .WithMany(e => e.Flats)
                    .HasForeignKey(f => f.idEmpresa)
                     .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Lancamento>(l =>
            {
                l.ToTable("lancamento", tb =>
                {
                    tb.HasTrigger("trg_InsertedNewLancamento");
                });
                l.Property(l => l.DataPagamento).IsRequired();
                l.Property(l => l.TipoPagamento).HasMaxLength(50).IsRequired();
                l.Property(l => l.ValorAluguel).HasColumnType("decimal(18,2)");
                l.Property(l => l.ValorDividendos).HasColumnType("decimal(18,2)");
                l.Property(l => l.ValorFundoReserva).HasColumnType("decimal(18,2)");

                l.HasOne(p => p.Flat)
                    .WithMany(f => f.Lancamentos)
                    .HasForeignKey(p => p.idFlat)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Ocorrencia>(o =>
            {
                o.Property(o => o.oco_valorAntigo).HasColumnType("decimal(18,2)").IsRequired();
                o.Property(o => o.oco_valorAlteracao).HasColumnType("decimal(18,2)").IsRequired();
                o.Property(o => o.oco_DataAlteracao).IsRequired();

                // Relacionamento com Lancamento
                o.HasOne(o => o.Lancamento)
                    .WithMany(l => l.Ocorrencias)
                    .HasForeignKey(o => o.idLancamento)
                    .OnDelete(DeleteBehavior.NoAction);

                // Relacionamento com Flat
                o.HasOne(o => o.Flat)
                    .WithMany(f => f.Ocorrencias)
                    .HasForeignKey(o => o.idFlat)
                    .OnDelete(DeleteBehavior.NoAction);
            });


            modelBuilder.Entity<Usuario>(u =>
            {
                u.Property(u => u.Login).IsRequired().HasMaxLength(50);
                u.Property(u => u.Senha).IsRequired().HasMaxLength(100);
                u.Property(u => u.DataCriacao).IsRequired();

                // Relacionamento com Lançamento
                u.HasMany(l => l.Lancamentos) // Um Usuário pode ter muitos Lançamentos
                    .WithOne(u => u.Usuario) // Um Lançamento pertence a um Usuário
                    .HasForeignKey(u => u.idUsuario) // Aqui, adicione o campo idUsuario em Lançamento
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
        private void CriaTrigger()
        {
            /*CREATE TRIGGER trg_InsertedNewLancamento
                ON Lancamento
                AFTER INSERT
                AS
                BEGIN
                    DECLARE @dataAtual DATETIME = GETDATE();

                    INSERT INTO ocorrencia (
                        oco_ValorAntigo,
                        oco_ValorAlteracao,
                        oco_DataAlteracao,
                        idLancamento,
                        idFlat,
                        oco_Tabela,
                        oco_Descricao,
                        DescricaoFlat,
                        IdUsuario,
                        DescricaoUsuario
                    )
                    SELECT 
                        ISNULL(ult.ValorAntigo, 0) AS ValorAntigo,
                        CASE 
                            WHEN i.TipoPagamento = 'Aluguel Fixo' THEN i.ValorAluguel
                            WHEN i.TipoPagamento = 'Dividendos' THEN i.ValorDividendos
                            WHEN i.TipoPagamento = 'Aluguel Fixo + Dividendos' THEN i.ValorAluguel + i.ValorDividendos
                            WHEN i.TipoPagamento = 'Fundo de Reserva' THEN i.ValorFundoReserva
                            ELSE 0
                        END AS ValorAlteracao,
                        @dataAtual,
                        i.id,
                        i.idFlat,
                        'Lancamento',
                        'Inserção',
                        f.Descricao AS DescricaoFlat,
                        i.IdUsuario,
                        u.Nome AS DescricaoUsuario
                    FROM INSERTED i
                    JOIN Flat f ON f.id = i.idFlat
                    LEFT JOIN Usuario u ON u.id = i.IdUsuario  -- Busca o nome do usuário
                    OUTER APPLY (
                        SELECT TOP 1
                            CASE 
                                WHEN i.TipoPagamento = 'Aluguel Fixo' THEN l.ValorAluguel
                                WHEN i.TipoPagamento = 'Dividendos' THEN l.ValorDividendos
                                WHEN i.TipoPagamento = 'Aluguel Fixo + Dividendos' THEN l.ValorAluguel + l.ValorDividendos
                                WHEN i.TipoPagamento = 'Fundo de Reserva' THEN l.ValorFundoReserva
                                ELSE 0
                            END AS ValorAntigo
                        FROM lancamento l
                        WHERE l.idFlat = i.idFlat
                          AND l.id < i.id
                        ORDER BY l.DataPagamento DESC
                    ) ult;
                END;
                */

        }
    }
}
