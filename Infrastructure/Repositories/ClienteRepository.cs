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

        public async Task<List<Cliente>> GetClienteAsync(int ID)
        {
            string parametros = ID > 0 ? $"Where idCliente = {ID}" : "";
            using(var connection = _conn.Opener())
            {

                string query = "Select nomeCliente, dataCliente, contatoCliente, enderecoCliente, documentoCliente, Cast(statusCliente as Bit) statusCliente from Cliente " + parametros;

                var res = await connection.QueryAsync(query);

               

                var clientes = new List<Cliente>();

                Console.WriteLine(res.ToString());

                foreach (var cliente in res)
                {
                     clientes.Add(new Cliente(
                        cliente.nomeCliente,
                        DateTime.Parse(cliente.dataCliente),
                        cliente.contatoCliente,
                        cliente.enderecoCliente,
                        cliente.documentoCliente,
                        cliente.statusCliente == 1));
                }

                return clientes;
            }
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
