using CadastroCliente.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace CadastroCliente.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private Database _conn;

        public ClienteRepository(Database conn)
        {
            _conn = conn;
        }
        public Task<string> AddCliente(string nome, DateTime dataNasc, string contato, string endereco, string documento)
        {

            _conn.Opener();

            
            
            return Task.FromResult(nome);
        }   
    }
}
