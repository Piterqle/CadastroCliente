using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Domain.Entities
{
    public class Cliente
    {
        internal Guid idCliente { get; private set; }

        public string nomeCliente { get; private set; }

        public DateTime dataCliente { get; private set; }

        public string contatoCliente { get; private set; }

        public string enderecoCliente { get; private set; }

        public string documentoCliente { get; private set; }
        
        public bool statusCliente { get; private set;  }

        public Cliente(string nome, DateTime dataNasc, string contato, string endereco, string documento, bool status)
        {
            
            this.nomeCliente = nome;
            this.dataCliente = dataNasc;
            this.contatoCliente = contato;
            this.enderecoCliente = endereco;
            this.documentoCliente = documento;
            this.statusCliente = status;

        }
    }
}
