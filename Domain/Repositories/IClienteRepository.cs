using CadastroCliente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<string>AddCliente(Cliente cliente);
        Task<dynamic> GetClienteAsync(int ID);
        Task UpdateCliente(Cliente cliente);
    }
}
