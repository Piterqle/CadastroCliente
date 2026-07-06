using CadastroCliente.Aplication.Models;
using CadastroCliente.Domain.Repositories;
using CadastroCliente.Domain.ValueObject;

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
                clientes.Add(new ClienteReadModel()
                {
                    NomeCliente = cliente.NomeCliente,
                    DataCliente = DateTime.Parse(cliente.DataCliente),
                    ContatoCliente = Convert.ToUInt64(cliente.ContatoCliente.Trim()).ToString(@"(00) 00000-0000"),
                    EnderecoCliente = cliente.EnderecoCliente,
                    DocumentoCliente = new DocumentoGeral(cliente.DocumentoCliente).Documento,
                    StatusCliente = cliente.StatusCliente == 1,
                    IdCliente = (int)cliente.IdCliente
                }
                  );
            }

            return clientes;
        }

    }
}
