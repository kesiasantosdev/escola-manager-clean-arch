using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Permissoes.Command.RemoverPermissoes
{
    public class RemoverPermissaoCommandHandler : IRequestHandler<RemoverPermissaoCommand, Guid>
    {
        private readonly IPermissaoRepository _permissaoRepository;
        private readonly ICargoRepository _cargoRepository;

        public RemoverPermissaoCommandHandler(IPermissaoRepository permissaoRepository, ICargoRepository cargoRepository)
        {
            _permissaoRepository = permissaoRepository;
            _cargoRepository = cargoRepository;
        }

        public async Task<Guid> Handle(RemoverPermissaoCommand request, CancellationToken cancellationToken)
        {
            var cargo = await _cargoRepository.ObterCargoPorId(request.CargoId);
            var permissao = await _permissaoRepository.ObterPorIdAsync(request.PermissaoId);

            if (cargo == null || permissao == null)
            {
                throw new Exception("Não encontrei o cargo ou a permissão!");
            }
            cargo.RemoverPermissao(permissao);
            await _cargoRepository.AtualizarAsync(cargo);
            return cargo.Id;
        }
    }
}
