using EscolaManager.Application.UseCases.Usuarios.Commands.AtualizarPessoa;
using EscolaManager.Application.UseCases.Usuarios.Commands.CriarUsuario;
using EscolaManager.Application.UseCases.Usuarios.Commands.DeletarUsuario;
using EscolaManager.Application.UseCases.Usuarios.Commands.Login;
using EscolaManager.Application.UseCases.Usuarios.Queries.ObterTodosUsuarios;
using EscolaManager.Application.UseCases.Usuarios.Queries.ObterUsuarioPorId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EscolaManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var response = await _mediator.Send(new ObterTodosUsuariosQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var response = await _mediator.Send(new ObterUsuarioPorIdQuery(id));
            return response != null ? Ok(response) : NotFound();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        [Authorize(Roles = "Adm, Gestão")]
        [HttpPost]
        public async Task<IActionResult> Criar(CriarUsuarioCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(ObterPorId), new { id = id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, AtualizarUsuarioCommand command)
        {
            command.Id = id;
            var sucesso = await _mediator.Send(command);
            return sucesso ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var sucesso = await _mediator.Send(new DeletarUsuarioCommand { Id = id });
            return sucesso ? NoContent() : NotFound();
        }
    }
}