using EscolaManager.Application.Gateways;
using Microsoft.AspNetCore.Mvc;

namespace EscolaManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeraisController : ControllerBase
    {
        private readonly ICnpjService _cnpjService;

        public GeraisController(ICnpjService cnpjService)
        {
            _cnpjService = cnpjService;
        }

        [HttpGet("consulta-cnpj/{cnpj}")]
        public async Task<IActionResult> Consultar(string cnpj)
        {
            var dados = await _cnpjService.BuscarDadosCnpjAsync(cnpj);
            if (dados == null) return NotFound("CNPJ não encontrado.");
            return Ok(dados);
        }
    }
}