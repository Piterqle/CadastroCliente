using CadastroCliente.Aplication.DTO;
using CadastroCliente.Domain.Entities;
using CadastroCliente.Domain.Repositories;

namespace CadastroCliente.Aplication.UseCases
{
    internal class ClienteUseCase
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteUseCase(IClienteRepository repository) //Construtor da classe
        {
            _clienteRepository = repository;

        }

        //Método de Inserir no Banco de Dados
        public async Task Insert(ClienteCreateDTO clienteDTO)
        {
            if (clienteDTO == null) { throw new ArgumentNullException(nameof(clienteDTO)); }

            var erros = clienteDTO.Validate();
            if (erros.Count > 0) { throw new Exception(string.Join(Environment.NewLine, erros)); }

            var res = await _clienteRepository.GetClienteAsync(0, clienteDTO.DocumentoCliente!.Documento);
            if (res.Count > 0) throw new DuplicateWaitObjectException("Documento Já Existe");

            Cliente cliente = new Cliente(
                clienteDTO.NomeCliente,
                clienteDTO.DataCliente,
                clienteDTO.ClienteContato,
                clienteDTO.EnderecoCliente,
                clienteDTO.DocumentoCliente,
                clienteDTO.StatusCliente

                );

            await _clienteRepository.AddCliente(cliente);
        }


        public async Task Update(int clienteId, ClienteUpdateDTO clienteDTO)
        {
            if (clienteDTO == null) throw new Exception("É Necessário dados do Cliente");

            var erros = clienteDTO.Validate();

            if (erros.Count > 0) { throw new Exception(string.Join(Environment.NewLine, erros)); }


            var res = await _clienteRepository.GetClienteAsync(clienteId);

            Cliente cliente = new(
                res[0].NomeCliente,
                DateTime.Parse(res[0].DataCliente),
                res[0].ContatoCliente,
                res[0].EnderecoCliente,
                new Domain.ValueObject.DocumentoGeral(res[0].DocumentoCliente.DocumentoNumerico),
                res[0].StatusCliente == 1,
                (int)res[0].IdCliente

            );

            //Alterar todos os Dados se houver uma mudança no Começo

            if (clienteDTO.StatusCliente.HasChange) cliente.AlterarStatus();

            if (clienteDTO.NomeCliente.HasChange) cliente.AlterarNome(clienteDTO.NomeCliente.Value!);

            if (clienteDTO.ContatoCliente.HasChange) cliente.AlterarContato(clienteDTO.ContatoCliente.Value!);

            if (clienteDTO.DataCliente.HasChange) cliente.AlterarData(clienteDTO.DataCliente.Value ?? throw new Exception("Erro na Alteração da Data do Cliente"));

            if (clienteDTO.EnderecoCliente.HasChange) cliente.AlterarEndereco(clienteDTO.EnderecoCliente.Value!);

            if (clienteDTO.DocumentoCliente.HasChange) cliente.AlterarDocumento(clienteDTO.DocumentoCliente.Value!);


            await _clienteRepository.UpdateCliente(cliente);
        }
    }
}
