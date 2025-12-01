using MediatR;

namespace EscolaManager.Application.UseCases.Escolas.Commands.DeletarEscola
{
    public class DeletarEscolaCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public DeletarEscolaCommand(Guid id) => Id = id;
    }
}