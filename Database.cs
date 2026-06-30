using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente
{
    public class Database
    {
        private readonly string connString;
        private SqliteConnection _connection;

        public Database(string connString)
        {
            this.connString = connString;
        }

        private SqliteConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqliteConnection(connString);
                    _connection.Open();
                }
                ExecuteQuery();
                return _connection;

            }
        }


        public SqliteConnection Opener() => Connection;

        public void ExecuteQuery()
        {
           
            var command = _connection.CreateCommand();
            command.CommandText = """"
                        Create Table If Not Exists Cliente(
                            IdCliente INTEGER Primary Key ,
                            NomeCliente varchar(250) Not Null,
                            DataCliente date Not Null,
                            ContatoCliente varchar(13) Not Null,
                            EnderecoCliente varchar(250) Not Null,
                            DocumentoCliente varchar(18) Not Null,
                            StatusCliente boolean Not Null
                        )
                        """";
            command.ExecuteNonQuery();
            MessageBox.Show("Query Executada com Sucesso");
        }
        
    }
}
