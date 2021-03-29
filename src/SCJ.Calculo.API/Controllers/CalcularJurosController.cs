using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SCJ.Calculo.API.Models;
using SCJ.Calculo.API.Services;
using System;
using System.Threading.Tasks;

namespace SCJ.Calculo.API.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class CalcularJurosController : ControllerBase
    {       
        private readonly ITaxaAPIService _taxaAPIService;
        private readonly IConfiguration _configuration;

        public CalcularJurosController(ITaxaAPIService taxaAPIService,
                                       IConfiguration configuration)
        {
            _taxaAPIService = taxaAPIService;
            _configuration = configuration;
        }

        [HttpGet("calculaJuros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> Get([FromQuery] decimal valorinicial, [FromQuery] int meses)
        {
            var validacao = CalculadoraJuros.ValidarParametros(valorinicial, meses);
            if (!String.IsNullOrEmpty(validacao)) return BadRequest(validacao);

            return Ok(CalculadoraJuros.CalcularJurosCompostos(valorinicial, await GetTaxaJuros(), meses).ToString("N2"));
        }

        [HttpGet("showmethecode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<string> GetRepoURL()
        {        
            return Ok(_configuration["URLRepoGitHub"]);
        }

        private async Task<decimal> GetTaxaJuros()
        {
            return await _taxaAPIService.GetTaxaJuros();
        }
    }
}
