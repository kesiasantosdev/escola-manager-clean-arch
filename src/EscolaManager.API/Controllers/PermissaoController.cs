using EscolaManager.Application.UseCases.Cargos.Queries.ObterCargoPorId;
using EscolaManager.Application.UseCases.Cargos.Queries.ObterTodosCargos;
using EscolaManager.Application.UseCases.Permissoes.Command.AtribuirPermissoes;
using EscolaManager.Application.UseCases.Permissoes.Command.AtualizarPermissoes;
using EscolaManager.Application.UseCases.Permissoes.Command.CriarPermissoes;
using EscolaManager.Application.UseCases.Permissoes.Command.DeletarPermissoes;
using EscolaManager.Application.UseCases.Permissoes.Command.RemoverPermissoes;
using EscolaManager.Application.UseCases.Permissoes.Queries.ObterPermissaoPorId;
using EscolaManager.Application.UseCases.Permissoes.Queries.ObterTodasPermissoes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EscolaManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var response = await _mediator.Send(new ObterTodasPermissoesQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var response = await _mediator.Send(new ObterPermissaoPorIdQuery(id));
            return response != null ? Ok(response) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Cria(CriarPermissaoCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpPost("AtribuirPermissão")]
        public async Task<IActionResult> AtribuirPermissoes(AtribuirPermissaoCommand command)
        {

            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpDelete("RemoverPermissão")]
        public async Task<IActionResult> RemoverPermissoes(Guid id, RemoverPermissaoCommand command)
        {

            command.Id = id;
            var sucesso = await _mediator.Send(command);
            return Ok(sucesso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, AtualizarPermissaoCommand command)
        {
            command.Id = id;
            var sucesso = await _mediator.Send(command);
            return sucesso ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id, DeletarPermissaoCommand command)
        {
            command.Id = id;
            var sucesso = await _mediator.Send(command);
            return sucesso ? NoContent() : NotFound();
        }
    }
}
