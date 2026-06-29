using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Aplication.Models
{
    public class ClienteReadView
    {
        internal int IdCliente { get; private set; }
        public string NomeCliente { get; private set; } = string.Empty;
        public DateTime DataCliente { get; private set; }
        public string ContatoCliente { get; private set; } = string.Empty;
        public string EnderecoCliente { get; private set; } = string.Empty;
        public string DocumentoCliente { get; private set; } = string.Empty;
        public bool StatusCliente { get; private set; }
    }
}
