using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Aplication.Models
{
    public class ClienteModelView
    {
        internal int idCliente { get; private set; }
        public string nomeCliente { get; private set; }
        public DateTime dataCliente { get; private set; }
        public string contatoCliente { get; private set; }
        public string enderecoCliente { get; private set; }
        public string documentoCliente { get; private set; }
        public bool statusCliente { get; private set; }

        public ClienteModelView(
            string nomeCliente,
            DateTime dataCliente,
            string contatoCliente,
            string enderecoCliente,
            string documentoCliente,
            bool statusCliente,
            int idCliente = 0
           )
        {
            this.idCliente = idCliente;
            this.nomeCliente = nomeCliente;
            this.dataCliente = dataCliente;
            this.contatoCliente = contatoCliente;
            this.enderecoCliente = enderecoCliente;
            this.documentoCliente = documentoCliente;
            this.statusCliente = statusCliente;

        }
    }
}
