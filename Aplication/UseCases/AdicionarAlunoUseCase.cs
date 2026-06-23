using CadastroCliente.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Aplication.UseCases
{
    public class AdicionarAlunoUseCase //Classe para o Caso de Uso de adicionar Alunos 
    {
        private readonly ClienteRepository _clienteRepository;

        public AdicionarAlunoUseCase(ClienteRepository repository) //Construtor da classe
        {
                _clienteRepository = repository;
            
        }

        //Executável da Classe
        public void execute(string name, DateTime dateTime, string contato, string endereco, string documento)
        {
            
        }
    }
}
