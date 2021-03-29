using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace SCJ.Taxa.Tests
{
    public class TaxaJurosIntegrationTests
    {
        public HttpClient _httpClient;

        public TaxaJurosIntegrationTests()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5002");
        }

        [Fact(DisplayName = "Integração - Retornar taxa de juros")]
        [Trait("Categoria", "Integração - Taxa Juros")]
        public async Task TaxaJuros_Taxa_DeveRetornaTaxaComSucesso()
        {
            // Arrage

            // Act
            var response = await _httpClient.GetAsync("api/v1/taxaJuros");
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("0,01", responseString);
        }
    }
}
