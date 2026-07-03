using CadastroCliente.Aplication.Models;
using CadastroCliente.Domain.Repositories;

namespace CadastroCliente.Aplication.UseCases
{
    public class ClienteReadUseCase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteReadUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<ClienteReadModel>> Read(int ID)
        {
            var res = await _clienteRepository.GetClienteAsync(ID);

            // Formartar o resultado para Objeto e coloca-lo na Lista
            var clientes = new List<ClienteReadModel>();
            foreach (var cliente in res)
            {
                Console.WriteLine(cliente.StatusCliente.GetType());
                clientes.Add(new ClienteReadModel()
                {
                    NomeCliente = cliente.NomeCliente,
                    DataCliente = DateTime.Parse(cliente.DataCliente),
                    ContatoCliente = cliente.ContatoCliente,
                    EnderecoCliente = cliente.EnderecoCliente,
                    DocumentoCliente = cliente.DocumentoCliente,
                    StatusCliente = cliente.StatusCliente == 1,
                    IdCliente = (int)cliente.IdCliente
                }
                  );
            }

            return clientes;
        }

    }
}
