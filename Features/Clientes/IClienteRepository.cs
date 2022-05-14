using Features.Core;
using System.Collections.Generic;

namespace Features.Clientes
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterPorEmail(string email);

        IEnumerable<Cliente> ObterTodos();

        void Adicionar(Cliente cliente);

        void Atualizar(Cliente cliente);

        void Remover(Cliente cliente);
    }
}
