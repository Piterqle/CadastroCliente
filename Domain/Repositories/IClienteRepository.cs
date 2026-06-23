using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<string>AddCliente(string nome, DateTime dataNasc, string contato, string endereco, string documento);
    }
}
