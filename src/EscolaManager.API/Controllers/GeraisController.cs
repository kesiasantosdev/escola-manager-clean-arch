using EscolaManager.Application.Gateways;
using EscolaManager.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EscolaManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeraisController : ControllerBase
    {
        private readonly ICnpjService _cnpjService;
        private readonly IPasswordService _passwordService;

        public GeraisController(ICnpjService cnpjService, IPasswordService passwordService)
        {
            _cnpjService = cnpjService;
            _passwordService = passwordService;
        }

        [HttpGet("consulta-cnpj/{cnpj}")]
        public async Task<IActionResult> Consultar(string cnpj)
        {
            var dados = await _cnpjService.BuscarDadosCnpjAsync(cnpj);
            if (dados == null) return NotFound("CNPJ não encontrado.");
            return Ok(dados);
        }

        /*[HttpGet("gerar-hash/{senha}")]
        public IActionResult GerarHash(string senha)
        {
            var hash = _passwordService.Hash(senha);
            return Ok(new { Senha = senha, Hash = hash });
        }*/
    }
}