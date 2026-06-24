using CadastroCliente.Domain.Entities;
using CadastroCliente.Domain.Repositories;
using CadastroCliente.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Aplication.UseCases
{
    public class AdicionarAlunoUseCase //Classe para o Caso de Uso de adicionar Alunos 
    {
        private readonly IClienteRepository _clienteRepository;

        public AdicionarAlunoUseCase(IClienteRepository repository) //Construtor da classe
        {
                _clienteRepository = repository;
            
        }

        //Executável da Classe
        public void execute(string name, DateTime dateTime, string contato, string endereco, string documento)
        {
            List<string> dados  = [name, dateTime.ToString(), contato, endereco, documento];

            if (dados.Any(items => items == "")) throw new Exception("Preencha os Campos");

            if (contato.Length < 12) throw new Exception("Número de Telefone inválido");


            Cliente cliente = new Cliente(name, dateTime, endereco, contato, documento, true);
            _clienteRepository.AddCliente(cliente);
        }
    }
}
