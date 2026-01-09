using MediatR;

namespace EscolaManager.Application.UseCases.Permissoes.Queries.ObterPermissaoPorId
{
    public record ObterPermissaoPorIdQuery(Guid Id) : IRequest<PermissaoViewModel?>;

}
