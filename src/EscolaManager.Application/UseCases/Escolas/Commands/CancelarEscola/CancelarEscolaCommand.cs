using MediatR;

namespace EscolaManager.Application.UseCases.Escolas.Commands.CancelarEscola
{
    public class CancelarEscolaCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public CancelarEscolaCommand(Guid id) => Id = id;
    }
}