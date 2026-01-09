using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Permissoes.Command.AtualizarPermissoes
{
    public class AtualizarPermissaoCommandHandler : IRequestHandler<AtualizarPermissaoCommand, bool>
    {
        private readonly IPermissaoRepository _permissaoRepository;

        public AtualizarPermissaoCommandHandler(IPermissaoRepository permissaoRepository)
        {
            _permissaoRepository = permissaoRepository;
        }

        public async Task<bool> Handle(AtualizarPermissaoCommand request, CancellationToken cancellationToken)
        {
            var atualizarPermissao = await _permissaoRepository.ObterPorIdAsync(request.Id);
            if (atualizarPermissao == null)
            {
                return false;
            }
            atualizarPermissao.AlterarNome(request.AlterarPermissao);

            await _permissaoRepository.AtualizarAsync(atualizarPermissao);
            return true;


        }
    }
}
