using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Permissoes.Command.DeletarPermissoes
{
    public class DeletarPermissaoCommandHandler : IRequestHandler<DeletarPermissaoCommand, bool>
    {
        private readonly IPermissaoRepository _permissaoRepository;

        public DeletarPermissaoCommandHandler(IPermissaoRepository permissaoRepository)
        {
            _permissaoRepository = permissaoRepository;
        }

        public async Task<bool> Handle(DeletarPermissaoCommand request, CancellationToken cancellationToken)
        {
            var deletarPermissao = await _permissaoRepository.ObterPorIdAsync(request.Id);

            if (deletarPermissao == null)
            {
                return false;
            }

            await _permissaoRepository.DeletarAsync(deletarPermissao);
            return true;
        }
    }
}
