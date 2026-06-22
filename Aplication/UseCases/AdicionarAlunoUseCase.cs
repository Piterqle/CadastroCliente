using CadastroCliente.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Aplication.UseCases
{
    public class AdicionarAlunoUseCase()
    {
        private readonly ClienteRepository _clienteRepository;

        public AdicionarUseCase(ClienteRepository repository)
        {
                _clienteRepository = repository;
            
        }

        public void execute(string name, DateTime dateTime, string contato, string endereco, string documento)
        {
            
        }
    }
}
