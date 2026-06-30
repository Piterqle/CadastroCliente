using CadastroCliente.Aplication.DTO;
using CadastroCliente.Domain.Entities;
using CadastroCliente.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Aplication.UseCases
{
    internal class ClienteUseCase
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteUseCase(IClienteRepository repository) //Construtor da classe
        {
            _clienteRepository = repository;

        }

        //Método de Inserir no Banco de Dados
        public void Insert(ClienteCreateDTO clienteDTO)
        {
            if (clienteDTO == null) { throw new ArgumentNullException(nameof(clienteDTO)); }

            var erros = clienteDTO.Validate();
            if (erros.Count > 0) { throw new Exception(string.Join(Environment.NewLine, erros));  }

            Cliente cliente = new Cliente(
                clienteDTO.NomeCliente,
                clienteDTO.DataCliente,
                clienteDTO.ClienteContato,
                clienteDTO.EnderecoCliente,
                clienteDTO.DocumentoCliente,
                clienteDTO.StatusCliente

                );

            _clienteRepository.AddCliente(cliente);
        }


        public void Update()
        {

        }
    }
}
