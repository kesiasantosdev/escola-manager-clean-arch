using MediatR;

namespace EscolaManager.Application.UseCases.Cargos.Queries.ObterTodosCargos
{
    public record ObterTodosCargosQuery() : IRequest<IEnumerable<CargoViewModel>>;
}
