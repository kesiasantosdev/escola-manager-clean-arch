using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Permissoes.Queries.ObterTodasPermissoes
{
    public class ObterTodasPermissoesHandler : IRequestHandler<ObterTodasPermissoesQuery, IEnumerable<PermissaoViewModel>>
    {
        private readonly IPermissaoRepository _permissaoRepository;

        public ObterTodasPermissoesHandler(IPermissaoRepository permissaoRepository)
        {
            _permissaoRepository = permissaoRepository;
        }

        public async Task<IEnumerable<PermissaoViewModel>> Handle(ObterTodasPermissoesQuery request, CancellationToken cancellationToken)
        {
            var permissoes = await _permissaoRepository.ObterTodosAsync();
            return permissoes.Select(c => new PermissaoViewModel(c.Id, c.NomePermissao));
        }
    }
}
