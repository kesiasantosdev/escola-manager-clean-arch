using EscolaManager.Application.UseCases.Escolas.Commands.AlterarEscola;
using EscolaManager.Application.UseCases.Escolas.Commands.AtivarEscola;
using EscolaManager.Application.UseCases.Escolas.Commands.BloquearEscola;
using EscolaManager.Application.UseCases.Escolas.Commands.CancelarEscola;
using EscolaManager.Application.UseCases.Escolas.Commands.CriarEscola;
using EscolaManager.Application.UseCases.Escolas.Commands.DeletarEscola;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Alterar(Guid id, AlterarEscolaCommand command)
        {
            command.Id = id;

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/ativar")]
        public async Task<IActionResult> Ativar(Guid id)
        {
            var command = new AtivarEscolaCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/bloquear")]
        public async Task<IActionResult> Bloquear(Guid id)
        {
            await _mediator.Send(new BloquearEscolaCommand(id));
            return NoContent();
        }

        [HttpPut("{id}/cancelar")]
        public async Task<IActionResult> Cancelar(Guid id)
        {
            await _mediator.Send(new CancelarEscolaCommand(id));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            await _mediator.Send(new DeletarEscolaCommand(id));
            return NoContent();
        }
    }
}