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

        public Task<List<Cliente>>Execute(int ID)
        {
            var clientes = _clienteRepository.GetClienteAsync(ID);
            return clientes;
        }
            
    }
}
