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
                                                <FrmPrincipalFF>();

                Application.Run(mainForm);
            }
        }

            private static void ConfigureServices(ServiceCollection services)
            {
            services.AddDbContext<ContextoSistema>();

            services.AddScoped<FrmFuncAluguelDividendo>();
            services.AddScoped<FrmFuncDividendos>();
            services.AddScoped<FrmFuncFundoReserva>();
            services.AddScoped<FrmFuncionalidadeLogin>();
            services.AddScoped<FrmFuncionalidadeRegisto>();
            services.AddScoped<FrmFuncPISeCOFINS>();
            services.AddScoped<FrmFuncRendimentoscs>();


            services.AddScoped<Form1>();
            services.AddScoped<FrmCadEmpresa>();
            services.AddScoped<FrmCadEmpresaFF>();
            services.AddScoped<FrmCadFlat>();
            services.AddScoped<FrmCadLancamento>();
            services.AddScoped<FrmCadUsuario>();
            services.AddScoped<FrmConsultaEmpresa>();
            services.AddScoped<FrmConsultaFlat>();
            services.AddScoped<FrmConsultaLancamento>();
            services.AddScoped<FrmConsultaOcorrencia>();
            services.AddScoped<FrmConsultaUsuario>();
            services.AddScoped<FrmPrincipalFF>();


            services.AddScoped<IEmpresaRepositorio, EmpresaRepositorio>();
            services.AddScoped<IFlatRepositorio, FlatRepositorio>();
            services.AddScoped<ILancamentoRepositorio, LancamentoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IOcorrenciaRepositorio, OcorrenciaRepositorio>();

        }
    }
}