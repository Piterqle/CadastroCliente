using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<string>AddCliente(Guid Id, string nome, DateTime dataNasc, string contato, string endereco, string documento);
    }
}
