using CadastroCliente.Aplication.Models;
using CadastroCliente.Domain.Entities;
using CadastroCliente.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Aplication.UseCases
{
    public class UpdateClienteUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public UpdateClienteUseCase(IClienteRepository clienteRepository) => _clienteRepository = clienteRepository;

        private Cliente transformCliente(ClienteModelView model) =>
           new Cliente(
               model.nomeCliente, 
               model.dataCliente,
               model.contatoCliente,
               model.enderecoCliente,
               model.documentoCliente,
               model.statusCliente,
               model.idCliente
               );
        
        public void ExecuteStatus(ClienteModelView model)
        {
            Cliente cliente = transformCliente(model);
            cliente.AlterarStatus();

            _clienteRepository.UpdateCliente(cliente);
        }
    }
}
