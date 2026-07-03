using CadastroCliente.Domain.Entities;
using CadastroCliente.Domain.Repositories;
using Dapper;

namespace CadastroCliente.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private Database _conn;

        public ClienteRepository(Database conn)
        {
            _conn = conn;
        }

        public async Task<dynamic> GetClienteAsync(int ID, string documeto = "")
        {
            string parametros = ID > 0 ? $"Where IdCliente = {ID}" : "";
            parametros = documeto != "" && parametros == "" ? $"Where DocumentoCliente = '{documeto}'" : parametros;

            using (var connection = _conn.Opener())
            {

                // Query que busca uma pessoa em específico ou puxar todas. 
                string query = "Select NomeCliente, DataCliente, ContatoCliente, EnderecoCliente, DocumentoCliente, Cast(StatusCliente as Bit) StatusCliente, IdCliente from Cliente " + parametros;

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
                    (NomeCliente, DataCliente, ContatoCliente, EnderecoCliente, DocumentoCliente, StatusCliente)
                    Values
                    (@NomeCliente, @DataCliente, @ContatoCliente, @EnderecoCliente, @DocumentoCliente, @StatusCliente)";

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
                    NomeCliente = @NomeCliente,
                    DataCliente = @DataCliente,
                    ContatoCliente = @ContatoCliente,
                    EnderecoCliente = @EnderecoCliente,
                    DocumentoCliente = @DocumentoCliente,
                    StatusCliente = @StatusCliente WHERE idCliente = @IdCliente ";

                await connection.ExecuteAsync(query, cliente);
            }
            MessageBox.Show("Cliente Alterado com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }
    }
}
