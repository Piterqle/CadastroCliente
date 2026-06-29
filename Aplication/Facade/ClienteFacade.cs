using CadastroCliente.Aplication.Models;
using CadastroCliente.Aplication.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Aplication.Facade
{
    internal class ClienteFacade //Facade para não expor os metodos da UseCase no Form
    {
        private readonly AdicionarClienteUseCase _adicionarClienteUseCase;
        private readonly GetClienteUseCase _getClienteUseCase;
        private readonly UpdateClienteUseCase _updateClientesUseCase;

        
        public ClienteFacade()
        {
            _adicionarClienteUseCase = DependencyServices.Get<AdicionarClienteUseCase>();
            _getClienteUseCase = DependencyServices.Get<GetClienteUseCase>();
            _updateClientesUseCase = DependencyServices.Get<UpdateClienteUseCase>();
        }


        public async Task AdicionarCliente(string nome, DateTime dataNasc, string contato, string endereco, string documento) =>
            _adicionarClienteUseCase.Execute(nome, dataNasc, contato, endereco, documento);


        public async Task<List<ClienteModelView>> BuscarCliente(int ID)
        {
            List<ClienteModelView> clientes = await _getClienteUseCase.Execute(ID);
            return clientes;
        }

        public async Task CancelarStatus(ClienteModelView cliente)
        {
            if (cliente == null) throw new Exception("É Necessário dados do Cliente");

            _updateClientesUseCase.ExecuteStatus(cliente);
        }
    }
}
