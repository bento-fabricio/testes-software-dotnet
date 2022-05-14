using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Features.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMediator _mediator;

        public ClienteService(IClienteRepository clienteRepository, IMediator mediator)
        {
            _clienteRepository = clienteRepository;
            _mediator = mediator;
        }

        public IEnumerable<Cliente> ObterTodosAtivos()
        {
            return _clienteRepository.ObterTodos().Where(c => c.Ativo);
        }

        public void Adicionar(Cliente cliente)
        {
            if (!cliente.EhValido()) return;

            _clienteRepository.Adicionar(cliente);
            _mediator.Publish(new ClienteEmailNotification("admin@me.com", cliente.Email, assunto: "", mensagem: ""));
        }

        public void Atualizar(Cliente cliente)
        {
            if (!cliente.EhValido()) return;

            _clienteRepository.Atualizar(cliente);
            _mediator.Publish(new ClienteEmailNotification("admin@me.com", cliente.Email, assunto: "", mensagem: ""));
        }

        public void Inativar(Cliente cliente)
        {
            if (!cliente.EhValido()) return;

            cliente.Inativar();
            _clienteRepository.Atualizar(cliente);
            _mediator.Publish(new ClienteEmailNotification("admin@me.com", cliente.Email, assunto: "", mensagem: ""));
        }

        public void Remover(Cliente cliente)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}
