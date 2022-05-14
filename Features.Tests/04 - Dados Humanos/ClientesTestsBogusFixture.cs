using Bogus;
using Bogus.DataSets;
using Features.Clientes;
using System;
using Xunit;
using static Bogus.DataSets.Name;

namespace Features.Tests
{
    [CollectionDefinition(nameof(ClienteBogusCollection))]
    public class ClienteBogusCollection : ICollectionFixture<ClienteTestsBogusFixture>
    {

    }

    public class ClienteTestsBogusFixture : IDisposable
    {
        public Cliente GerarClienteValido()
        {
            var genero = new Faker().PickRandom<Gender>();

            var cliente = new Faker<Cliente>(locale: "pt_BR")
                .CustomInstantiator(f => new Cliente(
                    Guid.NewGuid(),
                    nome: f.Name.FirstName(genero),
                    sobrenome: f.Name.LastName(genero),
                    f.Date.Past(yearsToGoBack: 80, DateTime.Now.AddYears(-18)),
                    email: "",
                    ativo: true,
                    dataCadastro: DateTime.Now))
                .RuleFor(property: c => c.Email, setter: (f, c) =>
                     f.Internet.Email(firstName: c.Nome.ToLower(), lastName: c.Sobrenome.ToLower()));

            return cliente;
        }

        public Cliente GerarClienteInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var cliente = new Faker<Cliente>(locale: "pt_BR")
                .CustomInstantiator(f => new Cliente(
                Guid.NewGuid(),
                nome: f.Name.FirstName(genero),
                sobrenome: f.Name.LastName(genero),
                dataNascimento: f.Date.Past(yearsToGoBack: 1, DateTime.Now.AddYears(1)),
                dataCadastro: DateTime.Now,
                email: "",
                ativo: false));

            return cliente;
        }

        public void Dispose()
        {

        }
    }
}
