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
            var stringConexao = @"Server=PC-VINICIUS; 
            DataBase=dbSistemaFL;integrated security=true; TrustServerCertificate=True;";

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(stringConexao);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração de Empresa
            modelBuilder.Entity<Empresa>(e =>
            {
                e.HasKey(e => e.id);
                e.Property(e => e.Descricao).IsRequired().HasMaxLength(150);
            });

            // Configuração de Flat
            modelBuilder.Entity<Flat>(e =>
            {
                e.Property(f => f.DataAquisicao).IsRequired();
                e.Property(e => e.Descricao).IsRequired().HasMaxLength(150);
                e.Property(f => f.Unidade).IsRequired();
                e.Property(f => f.TipoInvestimento).IsRequired();
                e.Property(f => f.Cidade).IsRequired();
                e.Property(f => f.Status).HasDefaultValue(true);

                // Relacionamento com Empresa
                e.HasOne(v => v.Empresa)
                    .WithMany(fp => fp.Flats)
                    .HasForeignKey(v => v.idEmpresa)
                    .HasConstraintName("fk_empresa_flat")
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // Configuração de Lancamento
            modelBuilder.Entity<Lancamento>(e =>
            {
                e.Property(p => p.DataPagamento).IsRequired().HasMaxLength(100);
                e.Property(p => p.ValorPagamento).IsRequired();

                // Relacionamento com Flat
                e.HasOne(p => p.Flat)
                    .WithMany(f => f.Lancamentos)
                    .HasForeignKey(p => p.idFlat)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // Configuração de Ocorrencia
            modelBuilder.Entity<Ocorrencia>(e =>
            {
                e.Property(o => o.DataAlteracao).IsRequired();

                // Relacionamento com Flat
                e.HasOne(o => o.Flat)
                    .WithMany(f => f.Ocorrencias)
                    .HasForeignKey(o => o.idFlat)
                    .OnDelete(DeleteBehavior.NoAction);

                // Relacionamento com Usuario
                e.HasOne(o => o.Usuario)
                    .WithMany(u => u.Ocorrencias)
                    .HasForeignKey(o => o.idUsuario)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // Configuração de Usuario
            modelBuilder.Entity<Usuario>(e =>
            {
                e.Property(u => u.nome).IsRequired().HasMaxLength(150);
            });
        }

    }
}

