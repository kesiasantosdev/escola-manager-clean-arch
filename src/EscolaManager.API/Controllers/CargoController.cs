using EscolaManager.Application.UseCases.Cargos.Command.AtualizarCargos;
using EscolaManager.Application.UseCases.Cargos.Command.DeletarCargos;
using EscolaManager.Application.UseCases.Cargos.Commands.CriarCargos;
using EscolaManager.Application.UseCases.Cargos.Queries.ObterCargoPorId;
using EscolaManager.Application.UseCases.Cargos.Queries.ObterCargosPorEscola;
using EscolaManager.Application.UseCases.Cargos.Queries.ObterTodosCargos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EscolaManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CargoController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> Criar(CriarCargoCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var response = await _mediator.Send(new ObterTodosCargosQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var response = await _mediator.Send(new ObterCargoPorIdQuery(id));
            return response != null ? Ok(response) : NotFound();
        }

        [HttpGet("escola/{escolaId}")]
        public async Task<IActionResult> ObterPorEscola(Guid escolaId)
        {
            var response = await _mediator.Send(new ObterCargosPorEscolaQuery(escolaId));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(Guid id, AtualizarCargoCommand command)
        {
            command.Id = id;
            var sucesso = await _mediator.Send(command);
            return sucesso ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var sucesso = await _mediator.Send(new DeletarCargoCommand { Id = id });
            return sucesso ? NoContent() : NotFound();
        }

    }
}
