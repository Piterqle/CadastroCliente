using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Domain.Entities
{
    public class Cliente
    {
        internal Guid idCliente { get; private set; }

        public string Nome { get; private set; }

        public DateTime DataNascimento { get; private set; }

        public string Contato { get; private set; }

        public string Endereco { get; private set; }

        public string Documento { get; private set; }

        public Cliente(Guid Id, string nome, DateTime dataNasc, string contato, string endereco, string documento)
        {
            this.idCliente = Id;
            this.Nome = nome;
            this.DataNascimento = dataNasc;
            this.Contato = contato;
            this.Endereco = endereco;
            this.Documento = documento; 
        }
    }
}
