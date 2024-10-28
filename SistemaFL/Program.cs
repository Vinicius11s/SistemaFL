using Infraestrutura.Contexto;
using InfraEstrutura.Repositorio;
using Microsoft.Extensions.DependencyInjection;
using Interfaces;
using System;
using Infraestrutura.Repositorio;
using Entidades;
using SistemaFL.Funcionalidades;

namespace SistemaFL
{
    internal static class Program
    {
        public static ServiceProvider serviceProvider;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            ConfigureServices(services);

            using (serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = serviceProvider.GetRequiredService
                                                <FrmPrincipal>();

                Application.Run(new FrmPrincipal());
            }
        }

            private static void ConfigureServices(ServiceCollection services)
            {
            services.AddDbContext<ContextoSistema>();

             services.AddScoped<FrmFuncionalidadeRegisto>();

            services.AddScoped<Form1>();
            services.AddScoped<FrmCadEmpresa>();
            services.AddScoped<FrmCadFlat>();
            services.AddScoped<FrmCadLancamento>();
            services.AddScoped<FrmCadUsuario>();
            services.AddScoped<FrmConsultaEmpresa>();
            services.AddScoped<FrmConsultaFlat>();
            services.AddScoped<FrmConsultaLancamento>();
            services.AddScoped<FrmConsultaOcorrencia>();
            services.AddScoped<FrmConsultaUsuario>();
            services.AddScoped<FrmPrincipal>();
            
            services.AddScoped<IEmpresaRepositorio, EmpresaRepositorio>();
            services.AddScoped<IFlatRepositorio, FlatRepositorio>();
            services.AddScoped<ILancamentoRepositorio, LancamentoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

        }
    }
}