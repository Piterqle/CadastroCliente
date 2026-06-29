using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace CadastroCliente.Aplication.DTO
{
    public class ClienteDTO
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome do Cliente é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Tamanho do nome deverá ser entre 2 a 100 caracteres")]
        public string NomeCliente {  get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode =true)]
        [Required(ErrorMessage = "Data de Nascimento do Cliente é obrigatório")]
        public DateTime DataCliente { get; set;}


       
    }
}
