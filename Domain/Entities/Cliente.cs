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


        public void AlterarNome(string novoNome) => NomeCliente = novoNome;

        public void AlterarContato(string novoContato) => ContatoCliente = novoContato;

        public void AlterarData(DateTime novaData) => DataCliente = novaData;
        
        public void AlterarEndereco(string novoEndereco) => EnderecoCliente = novoEndereco;
        
        public void AlterarDocumento(string novoDocumento) => DocumentoCliente = novoDocumento;

        public void AlterarStatus()
        {
            this.StatusCliente = !(this.StatusCliente);
        }
    }
}
