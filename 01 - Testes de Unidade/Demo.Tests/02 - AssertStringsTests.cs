using Xunit;

namespace Demo.Tests
{
    public class AssertStringsTests
    {
        [Fact]
        public void StringTools_UnirNomes_RetornarNomeCompleto()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir(nome: "Fabricio", sobrenome: "Bento");

            // Assert
            Assert.Equal(expected: "Fabricio Bento", actual: nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveIgnorarCase()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir(nome: "Fabricio", sobrenome: "Bento");

            // Assert
            Assert.Equal(expected: "FABRICIO BENTO", actual: nomeCompleto, ignoreCase: true);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveConterTrecho()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir(nome: "Fabricio", sobrenome: "Bento");

            // Assert
            Assert.Contains(expectedSubstring: "icio", actualString: nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveComecarCom()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir(nome: "Fabricio", sobrenome: "Bento");
            // Assert
            Assert.StartsWith(expectedStartString: "Fab", actualString: nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveAcabarCom()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir(nome: "Fabricio", sobrenome: "Bento");

            // Assert
            Assert.EndsWith(expectedEndString: "nto", actualString: nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_ValidarExpressaoRegular()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var nomeCompleto = sut.Unir("Fabricio", "Bento");

            // Assert
            Assert.Matches(expectedRegexPattern: "[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", actualString: nomeCompleto);
        }

    }
}
