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

        public async Task<dynamic> GetClienteAsync(int ID)
        {
            string parametros = ID > 0 ? $"Where idCliente = {ID}" : "";
            using (var connection = _conn.Opener())
            {

                // Query que busca uma pessoa em específico ou puxar todas. 
                string query = "Select idCliente, nomeCliente, dataCliente, contatoCliente, enderecoCliente, documentoCliente, Cast(statusCliente as Bit) statusCliente from Cliente " + parametros;

                var res = await connection.QueryAsync(query);

                return res;
            }
        }

        public Task<string> AddCliente(Cliente cliente)
        {


            using (var connection = _conn.Opener())
            {

                // Query para adicionar os Clientes
                const string query = @"Insert Into Cliente
                    (nomeCliente, dataCliente, contatoCliente, enderecoCliente, documentoCliente, statusCliente)
                    Values
                    (@nomeCliente, @dataCliente, @contatoCliente, @enderecoCliente, @documentoCliente, @statusCliente)";

                connection.Execute(query, cliente);

            }

            MessageBox.Show("Cliente Adicionado com Sucesso", "Seja Ben-vindo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return Task.FromResult(cliente.NomeCliente);
        }


        public async Task UpdateCliente(Cliente cliente)
        {
            using (var connection = _conn.Opener())
            {
                string query = $@"Update Cliente Set
                    nomeCliente = @nomeCliente,
                    dataCliente = @dataCliente,
                    contatoCliente = @contatoCliente,
                    enderecoCliente = @enderecoCliente,
                    documentoCliente = @documentoCliente,
                    statusCliente = @statusCliente WHERE idCliente = @idCliente ";

                var rowsAffect = connection.Execute(query, cliente);
            }
            MessageBox.Show("Cliente Alterado com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }
    }
}
