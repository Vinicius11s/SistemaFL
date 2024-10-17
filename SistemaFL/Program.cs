using Infraestrutura.Contexto;
using InfraEstrutura.Repositorio;
using Microsoft.Extensions.DependencyInjection;
using Interfaces;
using System;
using Infraestrutura.Repositorio;

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
            services.AddScoped<Form1>();

            services.AddScoped<FrmPrincipal>();
            services.AddScoped<FrmCadEmpresa>();
            services.AddScoped<FrmConsultaEmpresa>();


            services.AddSingleton<IEmpresaRepositorio, EmpresaRepositorio>();
        }
    }
}