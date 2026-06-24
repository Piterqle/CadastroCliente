using CadastroCliente.Domain.Entities;
using CadastroCliente.Domain.Repositories;
using Dapper;
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
        public Task<string> AddCliente(Cliente cliente)
        {

            
            using(var connection = _conn.Opener())
            {
                const string query = @" Insert Into Cliente
                    (nomeCliente, dataCliente, contatoCliente, enderecoCliente, documentoCliente, statusCliente)
                    Values
                    (@nomeCliente, @dataCliente, @contatoCliente, @enderecoCliente, @documentoCliente, @statusCliente)";

                connection.Execute(query, cliente);

            }

            MessageBox.Show("Cliente Adicionado com Sucesso", "Seja Ben-vindo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return Task.FromResult(cliente.nomeCliente);
        }   
    }
}
