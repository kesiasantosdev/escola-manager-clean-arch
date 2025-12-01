using EscolaManager.Application.UseCases.Escolas.Commands.CriarEscola;
using EscolaManager.Application.UseCases.Escolas.Queries.ObterEscolaPorId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EscolaManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EscolaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CriarEscolaCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(Criar), new { id = id }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var query = new ObterEscolaPorIdQuery(id);
            var escola = await _mediator.Send(query);

            if (escola == null)
            {
                return NotFound("Escola não encontrada.");
            }

            return Ok(escola);
        }
    }
}