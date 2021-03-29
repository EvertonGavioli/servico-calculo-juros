using System.Threading.Tasks;

namespace SCJ.Calculo.API.Services
{
    public interface ITaxaAPIService
    {
        Task<decimal> GetTaxaJuros();
    }
}
