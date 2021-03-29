using SCJ.Calculo.API.Models;
using System;
using Xunit;

namespace SCJ.Calculo.Tests
{
    public class CalculoJurosTests
    {
        [Theory(DisplayName = "Calcular Juros Compostos")]
        [Trait("Categoria", "Unidade - Calculo de Juros")]
        [InlineData(0, 0, 0, 0)]
        [InlineData(100, 0.01, 5, 105.10)]
        [InlineData(1000, 0.01, 5, 1051.01)]
        [InlineData(10000, 0.01, 5, 10510.10)]
        [InlineData(100000, 0.01, 5, 105101.00)]
        [InlineData(100, 0.01, 12, 112.68)]
        [InlineData(1000, 0.01, 12, 1126.82)]
        [InlineData(10000, 0.01, 12, 11268.25)]
        [InlineData(100000, 0.01, 12, 112682.50)]
        public void CalculadoraJuros_CalcularJurosCompostos_DeveRetornarValorCalculado(decimal valorInicial, decimal juros, int tempo, decimal resultado)
        {
            // Arrange

            // Act
            var valorCalculado = CalculadoraJuros.CalcularJurosCompostos(valorInicial, juros, tempo);

            // Assert
            Assert.Equal(resultado, valorCalculado);
        }

        [Theory(DisplayName = "Validar Parâmetros de entrada")]
        [Trait("Categoria", "Unidade - Calculo de Juros")]
        [InlineData(-100, -100)]
        [InlineData(99999999999999, 5)]
        [InlineData(1000, 99999)]
        [InlineData(99999999999999, 99999)]
        public void CalculadoraJuros_ValidarParametros_DeveRetornarValidacao(decimal valorInicial, int tempo)
        {
            // Arrange

            // Act
            var validacao = CalculadoraJuros.ValidarParametros(valorInicial, tempo);

            // Assert
            Assert.NotEqual(string.Empty, validacao);
        }
    }
}
