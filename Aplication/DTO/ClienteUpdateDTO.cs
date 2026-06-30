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
        private OptionalRef<string> _documentoCliente  = OptionalRef<string>.NotProvided();
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

        public OptionalRef<string> EderecoCliente
        {
            get => _enderecoCliente; set => _enderecoCliente = value ?? OptionalRef<string>.FromNullValue();
        }
        public OptionalRef<string> DocumentoCliente
        {
            get => _documentoCliente; set => _documentoCliente = value ?? OptionalRef<string>.FromNullValue();
        }

        public Optional<bool> StatusCliente
        {
            get => _statusCliente; set => _statusCliente = value ?? Optional<bool>.FromNullValue();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {   yield break; }
    }
}
