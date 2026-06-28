using CadastroCliente.Domain.Entities;
using CadastroCliente.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Aplication.UseCases
{
    public class GetClienteUseCase
    {
        private readonly IClienteRepository _clienteRepository;
        public GetClienteUseCase(IClienteRepository clienteRepository) {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<Cliente>>Execute(int ID)
        {
            var res = await _clienteRepository.GetClienteAsync(ID);

            // Formartar o resultado para Objeto e coloca-lo na Lista
            var clientes = new List<Cliente>();

            foreach (var cliente in res)
            {
                clientes.Add(new Cliente(
                   cliente.nomeCliente,
                   DateTime.Parse(cliente.dataCliente),
                   cliente.contatoCliente,
                   cliente.enderecoCliente,
                   cliente.documentoCliente,
                   cliente.statusCliente == 1));
            }

            return clientes;
        }
            
    }
}
