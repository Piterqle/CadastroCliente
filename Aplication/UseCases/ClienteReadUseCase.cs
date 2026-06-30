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

        public async Task<List<ClienteReadModel>>Read(int ID)
        {
            var res = await _clienteRepository.GetClienteAsync(ID);

            // Formartar o resultado para Objeto e coloca-lo na Lista
            var clientes = new List<ClienteReadModel>();

            foreach (var cliente in res)
            {
                clientes.Add(new ClienteReadModel() {
                   NomeCliente = cliente.nomeCliente,
                   DataCliente = DateTime.Parse(cliente.dataCliente),
                   ContatoCliente = cliente.contatoCliente,
                   EnderecoCliente = cliente.enderecoCliente,
                   DocumentoCliente = cliente.documentoCliente,
                   StatusCliente = cliente.statusCliente == 1,
                   IdCliente = (int)cliente.idCliente }); 
            }

            return clientes;
        }
            
    }
}
