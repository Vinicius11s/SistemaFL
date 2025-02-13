using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public DbSet<OutrosLancamentos> OutrosLancamentos { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Server Master = DESKTOP-6RMV3GQ
            //Server Local = DESKTOP-I32AP0S
            var stringConexao = @"Server=DESKTOP-6RMV3GQ;Database=DBSISFLATS09;Integrated Security=True;TrustServerCertificate=True;";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(stringConexao);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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

            modelBuilder.Entity<OutrosLancamentos>(o =>
            {
                o.Property(o => o.DataLancamento).IsRequired();
                o.Property(o => o.ValorRetidoNaFonte).HasColumnType("decimal(18,2)").IsRequired();
                o.Property(o => o.GanhoDeCapital).HasColumnType("decimal(18,2)").IsRequired();
                o.Property(o => o.OutrosRecebimentos).HasColumnType("decimal(18,2)").IsRequired();

                // Relacionamento com Ocorrencias
                o.HasMany(o => o.Ocorrencias)
                    .WithOne(o => o.OutrosLancamentos)
                    .HasForeignKey(o => o.idOutrosLancamentos)
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
        private void CriaTriggerLancamento()
        {
        /* ALTER TRIGGER trg_InsertedUpdatedLancamento
            ON Lancamento
            AFTER INSERT, UPDATE
            AS
            BEGIN
                --Tratamento para INSERT(Somente novos lançamentos)
                IF NOT EXISTS(SELECT 1 FROM deleted)
                BEGIN
                    INSERT INTO ocorrencia(
                        oco_ValorAntigo,
                        oco_ValorAlteracao,
                        oco_DataAlteracao,
                        oco_DataLancamentoAntigo,
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
                        i.DataPagamento,  
                        ult.DataLancamentoAntigo,
                        i.id,
                        i.idFlat,
                        'Lancamento',
                        'Inserção',
                        f.Descricao AS DescricaoFlat,
                        i.IdUsuario,
                        u.Login AS DescricaoUsuario
                    FROM INSERTED i
                    JOIN Flat f ON f.id = i.idFlat
                    LEFT JOIN Usuario u ON u.id = i.IdUsuario
                    OUTER APPLY(
                        SELECT TOP 1
                            CASE
                                WHEN i.TipoPagamento = 'Aluguel Fixo' THEN l.ValorAluguel
                                WHEN i.TipoPagamento = 'Dividendos' THEN l.ValorDividendos
                                WHEN i.TipoPagamento = 'Aluguel Fixo + Dividendos' THEN l.ValorAluguel + l.ValorDividendos
                                WHEN i.TipoPagamento = 'Fundo de Reserva' THEN l.ValorFundoReserva
                                ELSE 0
                            END AS ValorAntigo,
                            l.DataPagamento AS DataLancamentoAntigo
                        FROM lancamento l
                        WHERE l.idFlat = i.idFlat
                            AND l.id<i.id
                        ORDER BY l.DataPagamento DESC
                    ) ult;
                        END

                        -- Tratamento para UPDATE(Somente se houver alteração nos valores)
                ELSE
                BEGIN
                    INSERT INTO ocorrencia(
                        oco_ValorAntigo,
                        oco_ValorAlteracao,
                        oco_DataAlteracao,
                        oco_DataLancamentoAntigo,
                        idLancamento,
                        idFlat,
                        oco_Tabela,
                        oco_Descricao,
                        DescricaoFlat,
                        IdUsuario,
                        DescricaoUsuario
                    )
                    SELECT
                        CASE
                            WHEN d.TipoPagamento = 'Aluguel Fixo' THEN d.ValorAluguel
                            WHEN d.TipoPagamento = 'Dividendos' THEN d.ValorDividendos
                            WHEN d.TipoPagamento = 'Aluguel Fixo + Dividendos' THEN d.ValorAluguel + d.ValorDividendos
                            WHEN d.TipoPagamento = 'Fundo de Reserva' THEN d.ValorFundoReserva
                            ELSE 0
                        END AS ValorAntigo,
                        CASE
                            WHEN i.TipoPagamento = 'Aluguel Fixo' THEN i.ValorAluguel
                            WHEN i.TipoPagamento = 'Dividendos' THEN i.ValorDividendos
                            WHEN i.TipoPagamento = 'Aluguel Fixo + Dividendos' THEN i.ValorAluguel + i.ValorDividendos
                            WHEN i.TipoPagamento = 'Fundo de Reserva' THEN i.ValorFundoReserva
                            ELSE 0
                        END AS ValorAlteracao,
                        i.DataPagamento,  
                        d.DataPagamento AS DataLancamentoAntigo,
                        i.id,
                        i.idFlat,
                        'Alteração',
                        'Alteração',
                        f.Descricao AS DescricaoFlat,
                        i.IdUsuario,
                        u.Login AS DescricaoUsuario
                    FROM INSERTED i
                    JOIN DELETED d ON i.id = d.id
                    JOIN Flat f ON f.id = i.idFlat
                    LEFT JOIN Usuario u ON u.id = i.IdUsuario
                    WHERE
                        d.ValorAluguel<> i.ValorAluguel OR
                        d.ValorDividendos<> i.ValorDividendos OR
                        d.ValorFundoReserva<> i.ValorFundoReserva OR
                        d.TipoPagamento<> i.TipoPagamento;
                        END
                    END;
            */
        }
    }
}
