using CadastroCliente.Domain.ValueObject;
using CadastroCliente.Optional;
using CadastroCliente.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CadastroCliente.Aplication.DTO
{
    public class ClienteUpdateDTO : CustomValidatableObjectCheck, IValidatableObject
    {
        private Optional<int> _idCliente = Optional<int>.NotProvided();
        private OptionalRef<string> _nomeCliente = OptionalRef<string>.NotProvided();
        private Optional<DateTime> _dataCliente = Optional<DateTime>.NotProvided();
        private OptionalRef<string> _contatoCliente = OptionalRef<string>.NotProvided();
        private OptionalRef<string> _enderecoCliente = OptionalRef<string>.NotProvided();
        private OptionalRef<DocumentoGeral> _documentoCliente  = OptionalRef<DocumentoGeral>.NotProvided();
        private Optional<bool> _statusCliente  = Optional<bool>.NotProvided();


        public Optional<int> IdCliente
        {
            get => _idCliente; set => _idCliente = value ?? Optional<int>.FromNullValue();
        }

        public OptionalRef<string> NomeCliente
        {
            get => _nomeCliente; set => _nomeCliente = value ?? OptionalRef<string>.FromNullValue(); 
        }

        public Optional<DateTime> DataCliente
        {
            get => _dataCliente; set => _dataCliente = value;
        }

        public OptionalRef<string> ContatoCliente
        {
            get => _contatoCliente; set => _contatoCliente = value ?? OptionalRef<string>.FromNullValue();
        }

        public OptionalRef<string> EnderecoCliente
        {
            get => _enderecoCliente; set => _enderecoCliente = value ?? OptionalRef<string>.FromNullValue();
        }
        public OptionalRef<DocumentoGeral> DocumentoCliente
        {
            get => _documentoCliente; set => _documentoCliente = value ?? OptionalRef<DocumentoGeral>.FromNullValue();
        }

        public Optional<bool> StatusCliente
        {
            get => _statusCliente; set => _statusCliente = value ?? Optional<bool>.FromNullValue();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(ContatoCliente.HasChange){
                if (ContatoCliente.Value.Any(char.IsLetter))
                    yield return
                    new ValidationResult("O Número de Telefone não pode possuir Letras", new[] { nameof(ContatoCliente) });
                else if (ContatoCliente.Value.Length > 17 || ContatoCliente.Value.Length < 13)
                    yield return
                    new ValidationResult("Tamanho do Telefone deverá ser entre 13 e 17 caracteres", new[] { nameof(ContatoCliente) });
            }
            if (DocumentoCliente.HasChange)
            {
                if (DocumentoCliente.GetType() == typeof(DocumentoGeral))
                    yield return
                    new ValidationResult("O Documento CPF/CNPJ é inválido", new[] { nameof(DocumentoCliente) });
                else if (DocumentoCliente.Value.Documento.Any(char.IsLetter))
                    yield return
                    new ValidationResult("O Documento CPF/CNPJ não pode possuir Letras", new[] { nameof(DocumentoCliente) });

                else if (DocumentoCliente.Value.Documento.Length > 20 || DocumentoCliente.Value.Documento.Length < 14)
                    yield return
                    new ValidationResult("Tamanho do Documento CPF/CNPJ deverá ser entre 14 e 20 caracteres", new[] { nameof(DocumentoCliente) });
            }
            if (NomeCliente.HasChange)
            {
                if (NomeCliente.Value.Length < 3 || NomeCliente.Value.Length > 60)
                    yield return
                        new ValidationResult("Tamanho do Nome deverá ser entre 3 a 60 caracteres", new[] { nameof(NomeCliente) });
            }
            if (EnderecoCliente.HasChange)
            {
                if (EnderecoCliente.Value.Length < 3 || EnderecoCliente.Value.Length > 60)
                    yield return
                        new ValidationResult("Tamanho do Endereço deverá ser entre 3 a 60 caracteres", new[] { nameof(EnderecoCliente) });
            }

            yield break; 
        }
    }
}
