using CadastroCliente.Aplication.DTO;
using CadastroCliente.Aplication.Models;
using CadastroCliente.Aplication.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Aplication.Facade
{
    internal class ClienteFacade //Facade para não expor os metodos da UseCase no Form
    {
        private readonly ClienteUseCase _ClienteUseCase;
        private readonly ClienteReadUseCase _ClienteReadUseCase;
        

        
        public ClienteFacade()
        {
            _ClienteUseCase = DependencyServices.Get<ClienteUseCase>();
            _ClienteReadUseCase = DependencyServices.Get<ClienteReadUseCase>();
        }


        public async Task AdicionarCliente(ClienteCreateDTO cliente) =>
            _ClienteUseCase.Insert(cliente);


        public async Task<List<ClienteReadModel>> BuscarCliente(int ID)
        {
            List<ClienteReadModel> clientes = await _ClienteReadUseCase.Read(ID);
            return clientes;
        }

        public async Task CancelarStatus(ClienteReadModel cliente)
        {
            if (cliente == null) throw new Exception("É Necessário dados do Cliente");

            _ClienteUseCase.Update(cliente);
        }
    }
}
