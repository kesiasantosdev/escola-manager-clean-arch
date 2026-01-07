using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Permissoes.Command.CriarPermissoes
{
    public class CriarPermissoesCommandHandler : IRequestHandler<CriarPermissoesCommand, Guid>
    {
        private readonly IPermissaoRepository _permissaoRepository;

        public CriarPermissoesCommandHandler(IPermissaoRepository permissaoRepository)
        {
            _permissaoRepository = permissaoRepository;
        }

        public async Task<Guid> Handle(CriarPermissoesCommand request, CancellationToken cancellationToken)
        {
            var novaPermissao = new Permissao(request.NomePermissao);

            await _permissaoRepository.AdicionarAsync(novaPermissao);

            return novaPermissao.Id;



        }
    }
}
