using CadastroCliente.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Domain.Entities
{
    public class Cliente(
        string nomeCliente,
        DateTime dataCliente,
        string contatoCliente,
        string enderecoCliente,
        DocumentoGeral documentoCliente,
        bool statusCliente,
        int idCliente = 0)
    {

        public int IdCliente { get; private set; } = idCliente;
        public string NomeCliente { get; private set; } = nomeCliente;
        public DateTime DataCliente { get; private set; } = dataCliente;
        public string ContatoCliente { get; private set; } = contatoCliente;
        public string EnderecoCliente { get; private set; } = enderecoCliente;
        public DocumentoGeral DocumentoCliente { get; private set; } = documentoCliente;
        public bool StatusCliente { get; private set; } = statusCliente;

        public void AlterarNome(string novoNome) => NomeCliente = novoNome;

        public void AlterarContato(string novoContato) => ContatoCliente = novoContato;

        public void AlterarData(DateTime novaData) => DataCliente = novaData;

        public void AlterarEndereco(string novoEndereco) => EnderecoCliente = novoEndereco;
        
        public void AlterarDocumento(DocumentoGeral novoDocumento) => DocumentoCliente = novoDocumento;

        public void AlterarStatus()
        {
            StatusCliente = !StatusCliente;
        }
    }
}
