using MediatR;

namespace EscolaManager.Application.UseCases.Permissoes.Queries.ObterTodasPermissoes
{
    public record ObterTodasPermissoesQuery() : IRequest<IEnumerable<PermissaoViewModel>>;

}
