using Features.Clientes;
using System;
using Xunit;

namespace Features.Tests
{
    public class ClientesTests
    {
        [Fact(DisplayName = "Novo Cliente Válido")]
        [Trait("Categoria", "Cliente Trait Testes")]
        public void Cliente_NovoCliente_DeveEstarValido()
        {
            // Arrange
            var cliente = new Cliente(
                Guid.NewGuid(),
                nome: "Fabricio",
                sobrenome: "Bento",
                dataNascimento: DateTime.Now.AddYears(-46),
                dataCadastro: DateTime.Now,
                email: "fabricio@teste.com",
                ativo: true);

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.True(result);
            Assert.Equal(expected: 0, cliente.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "Novo Cliente Inválido")]
        [Trait("Categoria", "Cliente Trait Testes")]
        public void Cliente_NovoCliente_DeveEstarInvalidoValido()
        {
            // Arrange
            var cliente = new Cliente(
                Guid.NewGuid(),
                nome: "Fabricio",
                sobrenome: "Bento",
                dataNascimento: DateTime.Now,
                dataCadastro: DateTime.Now,
                email: "fabricio@teste.com",
                ativo: true);

            // Act
            var result = cliente.EhValido();

            // Assert
            Assert.False(result);
            Assert.NotEqual(expected: 0, cliente.ValidationResult.Errors.Count);
        }

    }
}
