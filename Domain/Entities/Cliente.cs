using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Domain.Entities
{
    public class Cliente
    {
        public int IdCliente { get; private set; }
        public string NomeCliente { get; private set; }
        public DateTime DataCliente { get; private set; }
        public string ContatoCliente { get; private set; }
        public string EnderecoCliente { get; private set; }
        public string DocumentoCliente { get; private set; }
        public bool  StatusCliente { get; private set;  }

        public Cliente(
            string nomeCliente, 
            DateTime dataCliente, 
            string contatoCliente, 
            string enderecoCliente, 
            string documentoCliente, 
            bool statusCliente,
            int idCliente = 0
           )
        {
            IdCliente = idCliente;
            NomeCliente = nomeCliente;
            DataCliente = dataCliente;
            ContatoCliente = contatoCliente;
            EnderecoCliente = enderecoCliente;
            DocumentoCliente = documentoCliente;
            StatusCliente = statusCliente;

        }


        public void AlterarDados(dynamic dados)
        {
            NomeCliente = dados.nome;
            DataCliente = dados.data;
            ContatoCliente = dados.contato;
            EnderecoCliente = dados.endereco;
            DocumentoCliente = dados.documento;
        }


        public void AlterarStatus()
        {
            this.StatusCliente = !(this.StatusCliente);
        }
    }
}
