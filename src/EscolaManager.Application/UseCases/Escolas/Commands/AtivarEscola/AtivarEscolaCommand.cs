using MediatR;

namespace EscolaManager.Application.UseCases.Escolas.Commands.AtivarEscola
{
    public class AtivarEscolaCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public AtivarEscolaCommand(Guid id)
        {
            Id = id;
        }
    }
}