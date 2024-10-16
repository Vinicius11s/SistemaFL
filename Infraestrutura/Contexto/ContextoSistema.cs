using System;
using System.Collections.Generic;
using System.Linq;
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
            this.Database.EnsureCreated();//comando para criar o bd;
        }

        //entidades que serão mapeadas pelo DbSet como tabelas no meu bd; (ADC TODAS)
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var stringConexao = @"Server=PCVINICIUS;
            DataBase=dbSistemaFL;integrated security=true; TrustServerCertificate=True;";

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
                e.HasIndex(e => e.Cnpj).IsUnique();
                e.Property(e => e.Cnpj).IsRequired().HasMaxLength(14);
                e.Property(e => e.Descricao).IsRequired().HasMaxLength(150);

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
                f.Property(f => f.NumeroAp).HasMaxLength(10).IsRequired(false); 
                f.Property(f => f.Bairro).HasMaxLength(50).IsRequired(false); 
                f.Property(f => f.Cidade).HasMaxLength(50) .IsRequired(false);
                f.Property(f => f.ValorInvestimento).HasColumnType("decimal(18,2)");
                f.Property(f => f.Status).IsRequired();

                f.HasOne(e => e.Empresa)
                    .WithMany(f => f.Flats)
                    .HasForeignKey(e => e.idEmpresa)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Lancamento>(l =>
            {
                l.Property(l => l.DataPagamento).IsRequired();
                l.Property(l => l.ValorPagamento).HasColumnType("decimal(18,2)").IsRequired(); 
                l.Property(l => l.TipoPagamento).HasMaxLength(50).IsRequired(false); 
                l.Property(l => l.FundoReserva).HasColumnType("decimal(18,2)");

                l.HasOne(p => p.Flat)
                    .WithMany(f => f.Lancamentos)
                    .HasForeignKey(p => p.idFlat)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Ocorrencia>(o =>
            {
                o.Property(o => o.valorAntigo).HasColumnType("decimal(18,2)").IsRequired();
                o.Property(o => o.valorNovo).HasColumnType("decimal(18,2)").IsRequired(); 
                o.Property(o => o.DataAlteracao).IsRequired();

                o.HasOne(f => f.Flat)
                    .WithMany(o => o.Ocorrencias)
                    .HasForeignKey(o => o.idFlat)
                    .OnDelete(DeleteBehavior.NoAction);

                o.HasOne(u => u.Usuario)
                    .WithMany(o => o.Ocorrencias)
                    .HasForeignKey(o => o.idUsuario)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Usuario>(u =>
            {
                u.Property(u => u.nome).IsRequired().HasMaxLength(100);
                u.Property(u => u.login).IsRequired() .HasMaxLength(50); 
                u.Property(u => u.Senha).IsRequired().HasMaxLength(100);
                u.Property(u => u.DataCriacao).IsRequired();
                u.Property(u => u.nome).IsRequired().HasMaxLength(150);
            });
        }
    }
}

