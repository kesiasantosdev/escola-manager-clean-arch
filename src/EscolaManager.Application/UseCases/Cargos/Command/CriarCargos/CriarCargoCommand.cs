using MediatR;

namespace EscolaManager.Application.UseCases.Cargos.Commands.CriarCargos
{
    public class CriarCargoCommand : IRequest<Guid>
    {
        public string NomeCargo { get; set; } = string.Empty;
        public Guid EscolaId { get; set; }
    }
}