using CadastroCliente.Aplication.Facade;
using CadastroCliente.Aplication.UseCases;
using CadastroCliente.Domain.Repositories;
using CadastroCliente.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroCliente
{
    public class DependencyServices //Injeção de Dependências paras os outros Arquivos
    {
        private static ServiceProvider? _provider;

        private static string? _connectionString;
        private static readonly object _lock = new object();

        public static void Configure(string connectionString)
        {
            lock (_lock)
            {
                _connectionString = connectionString;

                _provider?.Dispose();
                _provider = null;
                _provider = BuidServiceProvider();
            }
        }
        public static ServiceProvider BuidServiceProvider()
        {
            if (_connectionString == null) throw new InvalidOperationException("Connection string is not configured.");
            var services = new ServiceCollection();

            services.AddScoped<Database>(provider =>
            {
                return new Database(_connectionString);
            });

            services.AddTransient<IClienteRepository, ClienteRepository>();

            services.AddTransient<ClienteReadUseCase>();
            services.AddTransient<ClienteUseCase>();

            services.AddTransient<ClienteFacade>();

            return services.BuildServiceProvider();
        }

        public static T Get<T>() where T : class => _provider.GetRequiredService<T>();
    }
}
