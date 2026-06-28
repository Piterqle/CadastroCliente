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
        
        public bool  statusCliente { get; private set;  }

        public Cliente(string nomeCliente, DateTime dataCliente, string contatoCliente, string enderecoCliente, string documentoCliente, bool statusCliente)
        {
            
            this.nomeCliente = nomeCliente;
            this.dataCliente = dataCliente;
            this.contatoCliente = contatoCliente;
            this.enderecoCliente = enderecoCliente;
            this.documentoCliente = documentoCliente;
            this.statusCliente = statusCliente;

        }


        public void AlterarDados(dynamic dados)
        {
            this.nomeCliente = dados.nome;
            this.dataCliente = dados.data;
            this.contatoCliente = dados.contato;
            this.documentoCliente = dados.documento;
        }


        public void MudarStatus(bool status)
        {
            this.statusCliente = !status;
        }
    }
}
