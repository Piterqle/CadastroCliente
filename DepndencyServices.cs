using System;
using System.Collections.Generic;
using System.Text;
using CadastroCliente.Aplication.Facade;
using CadastroCliente.Aplication.UseCases;
using CadastroCliente.Domain.Repositories;
using CadastroCliente.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroCliente
{
    public class DependencyServices //Injeção de Dependências paras os outros Arquivos
    {
        private static ServiceProvider _provider;

        private static string _connectionString;
        private static readonly object _lock = new object();

        public static void Configure()
        {
            lock (_lock)
            {
                _provider?.Dispose();
                _provider = null;
                _provider = BuidServiceProvider();
            }
        }
        public static ServiceProvider BuidServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddTransient<IClienteRepository, ClienteRepository>();

            services.AddTransient<AdicionarAlunoUseCase>();

            services.AddTransient<ClienteFacade>();

            return services.BuildServiceProvider();
        }

        public static T Get<T>() where T : class => _provider.GetRequiredService<T>(); 
    }   
}
