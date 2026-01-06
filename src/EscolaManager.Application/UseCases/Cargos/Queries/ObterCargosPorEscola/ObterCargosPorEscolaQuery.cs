using MediatR;

namespace EscolaManager.Application.UseCases.Cargos.Queries.ObterCargosPorEscola
{
    public record ObterCargosPorEscolaQuery(Guid EscolaId) : IRequest<IEnumerable<CargoViewModel>>;
}
