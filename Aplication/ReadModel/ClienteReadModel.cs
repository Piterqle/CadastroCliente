using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Aplication.Models
{
    public class ClienteReadModel
    {
        internal int IdCliente { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public DateTime DataCliente { get;  set; }
        public string ContatoCliente { get; set; } = string.Empty;
        public string EnderecoCliente { get; set; } = string.Empty;
        public string DocumentoCliente { get; set; } = string.Empty;
        public bool StatusCliente { get; set; }
    }
}
