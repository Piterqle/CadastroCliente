using CadastroCliente.Aplication.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Aplication.Facade
{
    internal class ClienteFacade //Facade para não expor os metodos da UseCase no Form
    {
        private readonly AdicionarAlunoUseCase _adicionarAlunoUseCase;


        
        public ClienteFacade()
        {
            _adicionarAlunoUseCase = DependencyServices.Get<AdicionarAlunoUseCase>();
        }


        public async Task AdicionarCliente(string nome, DateTime dataNasc, string contato, string endereco, string documento) => 
            _adicionarAlunoUseCase.execute(nome, dataNasc, contato, endereco, documento);

    }
}
