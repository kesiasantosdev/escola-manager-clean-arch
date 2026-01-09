using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Permissoes.Queries.ObterPermissaoPorId
{
    public class ObterPermissaoPorIdHandler : IRequestHandler<ObterPermissaoPorIdQuery, PermissaoViewModel?>
    {
        private readonly IPermissaoRepository _permissaoRepository;

        public ObterPermissaoPorIdHandler(IPermissaoRepository permissaoRepository)
        {
            _permissaoRepository = permissaoRepository;
        }

        public async Task<PermissaoViewModel?> Handle(ObterPermissaoPorIdQuery request, CancellationToken cancellationToken)
        {
            var permissao = await _permissaoRepository.ObterPorIdAsync(request.Id);

            if (permissao == null)
            {
                return null;
            }

            return new PermissaoViewModel(permissao.Id, permissao.NomePermissao);

        }
    }
}
