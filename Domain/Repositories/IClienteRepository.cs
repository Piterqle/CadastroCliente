using CadastroCliente.Domain.Entities;

namespace CadastroCliente.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<string> AddCliente(Cliente cliente);
        Task<dynamic> GetClienteAsync(int ID, string Documento = "");
        Task UpdateCliente(Cliente cliente);
    }
}
