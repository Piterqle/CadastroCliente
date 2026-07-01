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
        public async Task Insert(ClienteCreateDTO clienteDTO)
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

            await _clienteRepository.AddCliente(cliente);
        }


        public async Task Update(int clienteId, ClienteUpdateDTO clienteDTO)
        {
            if (clienteDTO == null) throw new Exception("É Necessário dados do Cliente");

            var erros = clienteDTO.Validate();

            if (erros.Count > 0) { throw new Exception(string.Join(Environment.NewLine, erros)); }


            var res = await _clienteRepository.GetClienteAsync(clienteId);

            var nomeCliente = res[0].nomeCliente;
            Cliente cliente = new Cliente(
                res[0].nomeCliente,
                DateTime.Parse(res[0].dataCliente),
                res[0].contatoCliente,
                res[0].enderecoCliente,
                res[0].documentoCliente,
                res[0].statusCliente == 1,
                (int)res[0].idCliente

            );
            
            //Alterar todos os Dados se houver uma mudança no Começo

            if (clienteDTO.StatusCliente.HasChange) cliente.AlterarStatus();

            if (clienteDTO.NomeCliente.HasChange) cliente.AlterarNome(clienteDTO.NomeCliente.Value);

            if (clienteDTO.ContatoCliente.HasChange) cliente.AlterarContato(clienteDTO.ContatoCliente.Value);

            if (clienteDTO.DataCliente.HasChange) cliente.AlterarData(clienteDTO.DataCliente.Value ?? throw new Exception("Erro na Alteração da Data do Cliente"));

            if (clienteDTO.EnderecoCliente.HasChange) cliente.AlterarContato(clienteDTO.EnderecoCliente.Value);
            
            if (clienteDTO.ContatoCliente.HasChange) cliente.AlterarContato(clienteDTO.ContatoCliente.Value);
            
            
            await _clienteRepository.UpdateCliente(cliente);
        }
    }
}
