using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCJ.Taxa.API.Models;

namespace SCJ.Taxa.API.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class TaxaJurosController : ControllerBase
    {
        [Route("taxaJuros")]
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public string Get()
        {
            return TaxaJuros.Taxa.ToString("N2");
        }
    }
}
