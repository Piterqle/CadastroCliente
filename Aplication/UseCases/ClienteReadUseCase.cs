using CadastroCliente.Aplication.Models;
using CadastroCliente.Domain.Entities;
using CadastroCliente.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Aplication.UseCases
{
    public class ClienteReadUseCase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteReadUseCase(IClienteRepository clienteRepository) {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<ClienteReadView>>Read(int ID)
        {
            var res = await _clienteRepository.GetClienteAsync(ID);

            // Formartar o resultado para Objeto e coloca-lo na Lista
            var clientes = new List<ClienteReadView>();

            foreach (var cliente in res)
            {
                clientes.Add(new ClienteReadView(
                   cliente.nomeCliente,
                   DateTime.Parse(cliente.dataCliente),
                   cliente.contatoCliente,
                   cliente.enderecoCliente,
                   cliente.documentoCliente,
                   cliente.statusCliente == 1,
                   (int)cliente.idCliente));
            }

            return clientes;
        }
            
    }
}
