using EscolaManager.Application.UseCases.Escolas.Commands.CriarEscola;
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
    }
}