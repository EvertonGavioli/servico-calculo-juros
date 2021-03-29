using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.AutoMock;
using SCJ.Calculo.API.Controllers;
using SCJ.Calculo.API.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace SCJ.Calculo.Tests
{
    public class CalculoJurosItegrationTests
    {
        public HttpClient _httpClient;

        public CalculoJurosItegrationTests()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5000");
        }

        [Fact(DisplayName = "Taxa API Service Retornar Taxa")]
        [Trait("Categoria", "Integração - Calculo de Juros")]
        public async Task TaxaAPIService_GetTaxaJuros_DeveRetornarTaxaJurosComSucesso()
        {
            // Arrange
            var mocker = new AutoMocker();
            var taxaApiService = mocker.CreateInstance<TaxaAPIService>();

            mocker.GetMock<IConfiguration>().Setup(f => f["URLTaxaAPI"]).Returns("http://localhost:5002");
                          
            // Act
            var taxa = await taxaApiService.GetTaxaJuros();

            // Assert
            Assert.Equal(0.01m, taxa);
        }

        [Fact(DisplayName = "Calcular Resultado Final Juros")]
        [Trait("Categoria", "Integração - Calculo de Juros")]
        public async Task CalcularJurosController_Get_DeveRetornarValorFinalCalculado()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            configurationMock.Setup(f => f["URLTaxaAPI"]).Returns("http://localhost:5002");

            var taxaApiService = new TaxaAPIService(configurationMock.Object);
            var controller = new CalcularJurosController(taxaApiService, configurationMock.Object);

            // Act
            var valorFinal = await controller.Get(100, 5);

            // Assert       
            Assert.IsType<OkObjectResult>(valorFinal.Result);
            
            var objectResult = valorFinal.Result as OkObjectResult;
            Assert.Equal("105,10", objectResult.Value);
        }

        [Fact(DisplayName = "Validar Parâmetros de entrada")]
        [Trait("Categoria", "Integração - Calculo de Juros")]
        public async Task CalcularJurosController_Get_DeveRetornarValorValidacao()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var taxaApiService = new TaxaAPIService(configurationMock.Object);

            var controller = new CalcularJurosController(taxaApiService, configurationMock.Object);

            // Act
            var valorFinal = await controller.Get(-100, -100);

            // Assert
            Assert.IsType<BadRequestObjectResult>(valorFinal.Result);

            var objectResult = valorFinal.Result as BadRequestObjectResult;
            Assert.Contains("Valor inicial deve estar no intervalo entre", objectResult.Value.ToString());
        }

        [Fact(DisplayName = "Exibir URL do repositório")]
        [Trait("Categoria", "Integração - Calculo de Juros")]
        public void CalcularJurosController_GetRepoURL_DeveRetornarURLdoRepositorio()
        {      
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            configurationMock.Setup(f => f["URLRepoGitHub"]).Returns("https://github.com/");

            var taxaApiService = new TaxaAPIService(configurationMock.Object);
            var controller = new CalcularJurosController(taxaApiService, configurationMock.Object);

            // Act
            var valorFinal = controller.GetRepoURL();

            // Assert       
            Assert.IsType<OkObjectResult>(valorFinal.Result);

            var objectResult = valorFinal.Result as OkObjectResult;
            Assert.Contains("https://github.com/", objectResult.Value.ToString());
        }

        [Fact(DisplayName = "E2E - Calcular Resultado Final Juros")]
        [Trait("Categoria", "Integração - Calculo de Juros")]
        public async Task CalcularJurosE2E_Get_DeveRetornarValorFinalCalculado()
        {
            // Arrange

            // Act
            var response = await _httpClient.GetAsync("api/v1/calculaJuros?valorinicial=100&meses=5");
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert       
            response.EnsureSuccessStatusCode();
            Assert.Equal("105,10", responseString);
        }

        [Fact(DisplayName = "E2E - Exibir URL do repositório")]
        [Trait("Categoria", "Integração - Calculo de Juros")]
        public async Task CalcularJurosE2E_GetRepoURL_DeveRetornarURLdoRepositorio()
        {
            // Arrange

            // Act
            var response = await _httpClient.GetAsync("api/v1/showmethecode");
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert       
            response.EnsureSuccessStatusCode();
            Assert.Contains("https://github.com/", responseString);
        }
    }
}
