using Microsoft.Data.Sqlite;

namespace CadastroCliente
{
    public class Database(string connString)
    {
        private readonly string connString = connString;
        private SqliteConnection? _connection = null;

        private SqliteConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqliteConnection(connString);
                    _connection.Open();
                    CreateTableIfNotExists();
                }
                return _connection;

            }
        }


        public SqliteConnection Opener() => Connection;

        private void CreateTableIfNotExists()
        {

            var command = Connection.CreateCommand();

            command.CommandText =
                "CREATE TABLE IF NOT EXISTS Cliente( \n" +
                "    IdCliente INTEGER PRIMARY KEY, \n" +
                "    NomeCliente VARCHAR(250) NOT NULL, \n" +
                "    DataCliente DATE NOT NULL, \n" +
                "    ContatoCliente VARCHAR(13) NOT NULL, \n" +
                "    EnderecoCliente VARCHAR(250) NOT NULL, \n" +
                "    DocumentoCliente VARCHAR(18) NOT NULL, \n" +
                "    StatusCliente BOOLEAN NOT NULL \n" +
                ")";

            command.ExecuteNonQuery();

        }

    }
}
