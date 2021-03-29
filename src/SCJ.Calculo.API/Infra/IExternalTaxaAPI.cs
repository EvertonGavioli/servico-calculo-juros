using Refit;
using System.Threading.Tasks;

namespace SCJ.Calculo.API.Infra
{
    public interface IExternalTaxaAPI
    {
        [Get("/api/v1/taxaJuros")]
        Task<string> GetTaxaJuros();
    }
}
