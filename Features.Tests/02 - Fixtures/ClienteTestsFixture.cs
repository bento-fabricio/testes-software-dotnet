using Bogus;
using Features.Clientes;
using System;
using Xunit;

namespace Features.Tests
{
    [CollectionDefinition(nameof(ClienteCollection))]
    public class ClienteCollection : ICollectionFixture<ClienteTestsFixture>
    {

    }

    public class ClienteTestsFixture : IDisposable
    {
        public Cliente GerarClienteValido()
        {
            var cliente = new Cliente(
                Guid.NewGuid(),
                nome: "Fabricio",
                sobrenome: "Bento",
                dataNascimento: DateTime.Now.AddYears(-46),
                dataCadastro: DateTime.Now,
                email: "fabricio@teste.com",
                ativo: true);

            return cliente;
        }

        public Cliente GerarClienteInvalido()
        {
            var cliente = new Cliente(
                Guid.NewGuid(),
                nome: "Fabricio",
                sobrenome: "Bento",
                dataNascimento: DateTime.Now,
                dataCadastro: DateTime.Now,
                email: "fabricio@teste.com",
                ativo: true);

            return cliente;
        }

        public void Dispose()
        {
            
        }
    }
}
