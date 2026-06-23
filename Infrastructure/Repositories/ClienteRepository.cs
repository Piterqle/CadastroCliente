using CadastroCliente.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public Task<string> AddCliente(string nome, DateTime dataNasc, string contato, string endereco, string documento)
        {
            throw new NotImplementedException();
        }   
    }
}
