using MediatR;

namespace EscolaManager.Application.UseCases.Cargos.Queries.ObterCargoPorId
{
    public record ObterCargoPorIdQuery(Guid Id) : IRequest<CargoViewModel?>;

}
