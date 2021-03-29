using Microsoft.Extensions.Configuration;
using Refit;
using SCJ.Calculo.API.Infra;
using System;
using System.Threading.Tasks;

namespace SCJ.Calculo.API.Services
{
    public class TaxaAPIService : ITaxaAPIService
    {
        private readonly IConfiguration _configuration;

        public TaxaAPIService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<decimal> GetTaxaJuros()
        {
            try
            {
                var taxaAPI = RestService.For<IExternalTaxaAPI>(_configuration["URLTaxaAPI"]);
                var taxa = await taxaAPI.GetTaxaJuros();

                return string.IsNullOrEmpty(taxa) ? 0m : Convert.ToDecimal(taxa);
            }
            catch (Exception)
            {
                // Efetuar Log...
                throw;
            }
        }
    }
}
