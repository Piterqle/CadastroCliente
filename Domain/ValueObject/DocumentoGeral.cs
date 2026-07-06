using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Domain.ValueObject
{
    public class DocumentoGeral
    {
        public string Documento { get; private set; }
        public string? DocumentoNumerico { get; private set; }

        public DocumentoGeral(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
            {
                throw new ArgumentException("Documento não pode ser nulo ou vazio.");
            }

            if (documento.Length <= 14 && documento.Length >= 11)
            {
                var documentoCPF = new DocumentoCPF(documento);
                Documento = documentoCPF.CPF;
                DocumentoNumerico = documentoCPF.DocumentoNumerico;
            }
            else if (documento.Length > 14 && documento.Length < 18)
            {
                var documentoCNPJ = new DocumentoCNPJ(documento);
                Documento = documentoCNPJ.CNPJ;
                DocumentoNumerico = documentoCNPJ.DocumentoNumerico;
            }
            else
            {
                throw new ArgumentException("Documento deve ter 14 caracteres para CPF ou 18 caracteres para CNPJ.");
            }

            return;
        }
    }
}
