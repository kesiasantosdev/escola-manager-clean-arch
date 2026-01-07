using EscolaManager.Application.UseCases.Permissoes.Command.AtribuirPermissoes;
using EscolaManager.Application.UseCases.Permissoes.Command.AtualizarPermissoes;
using EscolaManager.Application.UseCases.Permissoes.Command.CriarPermissoes;
using EscolaManager.Application.UseCases.Usuarios.Commands.AtualizarPessoa;
using MediatR;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public async Task<IActionResult> Cria(CriarPermissoesCommand command)
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, AtualizarPermissoesCommand command)
        {
            command.Id = id;
            var sucesso = await _mediator.Send(command);
            return sucesso ? NoContent() : NotFound();
        }
    }
}
