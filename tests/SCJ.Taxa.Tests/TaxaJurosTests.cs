using SCJ.Taxa.API.Controllers;
using SCJ.Taxa.API.Models;
using Xunit;

namespace SCJ.Taxa.Tests
{
    public class TaxaJurosTests
    {
        [Fact(DisplayName = "Retornar taxa de juros")]
        [Trait("Categoria", "Unidade - Taxa de Juros")]
        public void TaxaJuros_Taxa_DeveRetornarTaxaDeJurosComSucesso()
        {
            // Arrange

            // Act
            var taxa = TaxaJuros.Taxa;

            // Assert
            Assert.Equal(0.01m, taxa);
        }

        [Fact(DisplayName = "Controller Retornar taxa de juros")]
        [Trait("Categoria", "Unidade - Taxa de Juros")]
        public void TaxaJuros_Taxa_ControllerDeveRetornarTaxaDeJurosComSucesso()
        {
            // Arrange
            var controller = new TaxaJurosController();

            // Act
            var taxa = controller.Get();

            // Assert
            Assert.Equal("0,01", taxa);
        }
    }
}
