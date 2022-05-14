using Xunit;

namespace Demo.Tests
{
    public class AssertingRangeTests
    {
        [Theory]
        [InlineData(700)]
        [InlineData(1500)]
        [InlineData(2000)]
        [InlineData(7500)]
        [InlineData(8000)]
        [InlineData(15000)]
        public void Funcionario_Salario_FaixasSalariaisDevemRespeitarNivelProfissional(double salario)
        {
            // Arrange & Act
            var funcionario = new Funcionario("Fabricio", salario);

            // Assert
            if (funcionario.NivelProfissional == NivelProfissional.Junior)
                Assert.InRange(actual: funcionario.Salario, low: 500, high: 1999);

            if (funcionario.NivelProfissional == NivelProfissional.Pleno)
                Assert.InRange(actual: funcionario.Salario, low: 2000, high: 7999);

            if (funcionario.NivelProfissional == NivelProfissional.Senior)
                Assert.InRange(actual: funcionario.Salario, low: 8000, high: double.MaxValue);

            Assert.NotInRange(actual: funcionario.Salario, low: 0, high: 499);
        }
    }
}
