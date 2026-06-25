using CadastroCliente.Aplication.UseCases;
using CadastroCliente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Aplication.Facade
{
    internal class ClienteFacade //Facade para não expor os metodos da UseCase no Form
    {
        private readonly AdicionarClienteUseCase _adicionarAlunoUseCase;
        private readonly GetClienteUseCase _getClienteUseCase;

        
        public ClienteFacade()
        {
            _adicionarAlunoUseCase = DependencyServices.Get<AdicionarClienteUseCase>();
            _getClienteUseCase = DependencyServices.Get<GetClienteUseCase>();
        }


        public async Task AdicionarCliente(string nome, DateTime dataNasc, string contato, string endereco, string documento) => 
            _adicionarAlunoUseCase.Execute(nome, dataNasc, contato, endereco, documento);


        public async Task<List<Cliente>> BuscarCliente(int ID)
        {
            List<Cliente> clientes = await _getClienteUseCase.Execute(ID);
            return clientes;
        }
    }
}
