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
        public void Insert(string name, DateTime dateTime, string contato, string endereco, string documento)
        {
            List<string> dados = [name, dateTime.ToString(), contato, endereco, documento];

            if (dados.Any(items => items == "")) throw new Exception("Preencha os Campos");

            if (contato.Length < 12) throw new Exception("Número de Telefone inválido");


            Cliente cliente = new Cliente(name, dateTime, contato, endereco, documento, true);
            _clienteRepository.AddCliente(cliente);
        }


        public void Update()
        {

        }
    }
}
