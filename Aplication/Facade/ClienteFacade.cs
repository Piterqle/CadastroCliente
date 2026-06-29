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


        public async Task AdicionarCliente(string nome, DateTime dataNasc, string contato, string endereco, string documento) =>
            _ClienteUseCase.Insert(nome, dataNasc, contato, endereco, documento);


        public async Task<List<ClienteReadView>> BuscarCliente(int ID)
        {
            List<ClienteReadView> clientes = await _ClienteReadUseCase.Read(ID);
            return clientes;
        }

        public async Task CancelarStatus(ClienteReadView cliente)
        {
            if (cliente == null) throw new Exception("É Necessário dados do Cliente");

            _ClienteUseCase.Update(cliente);
        }
    }
}
