using MediatR;

namespace EscolaManager.Application.UseCases.Escolas.Commands.BloquearEscola
{
    public class BloquearEscolaCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public BloquearEscolaCommand(Guid id) => Id = id;
    }
}