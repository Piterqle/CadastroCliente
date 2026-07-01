using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace CadastroCliente.Aplication.DTO
{
    public class ClienteCreateDTO : CustomValidatableObjectCheck, IValidatableObject
    {
        // Identificador do CLiente pode ser opicional, mas não negativo
        public int Id { get; set; }


        // Nome é obrigatório com caracteres limitada
        [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome do Cliente é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Tamanho do nome deverá ser entre 2 a 100 caracteres")]
        public string NomeCliente {  get; set; }  = string.Empty;


        // Data de Nascimento é obrigatório e com formato correto
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Data de Nascimento do Cliente é obrigatório")]
        public DateTime DataCliente { get; set;}

        // Telefone é obrigatório e com caracteres limitado
        [Required(AllowEmptyStrings = false, ErrorMessage = "Número de telfone é obrigatório")]
        [StringLength(17, MinimumLength = 13, ErrorMessage = "Número de telefone inválido")]
        public string ClienteContato { get; set;} = string.Empty;

        // Endereço é obrigatório e com caracteres limitado
        [Required(AllowEmptyStrings = false, ErrorMessage = "Endereço do Cliente é obrigatório")]
        [StringLength(120, MinimumLength = 3, ErrorMessage = "Tamanho do endereço deverá ser entre 2 a 120 caracteres")]
        public string EnderecoCliente { get; set;} = string.Empty;

        // Documento é obrigatório e com caracteres limitado
        [Required(AllowEmptyStrings = false, ErrorMessage = "Documento do Cliente é obrigatório")]
        [StringLength(20, MinimumLength = 13, ErrorMessage = "Tamanho do Documento deverá ser entre 16 a 20 caracteres")]
        public string DocumentoCliente { get; set;} = string.Empty;

        // Status do Cliente é apenas obrigatório
        [Required(ErrorMessage = "Status do Cliente é obrigatório")]
        public bool StatusCliente { get; set;}

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ClienteContato.Any(char.IsLetter))
                yield return
                new ValidationResult("O Número de Telefone não pode possuir Letras", new[] { nameof(ClienteContato) });
            if (DocumentoCliente.Any(char.IsLetter))
                yield return
                new ValidationResult("O Número de Telefone não pode possuir Letras", new[] { nameof(DocumentoCliente) });

            yield break; 
        }
    }
}
