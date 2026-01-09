using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Permissoes.Command.AtribuirPermissoes
{
    public class AtribuirPermissaoCommandHandler : IRequestHandler<AtribuirPermissaoCommand, Guid>
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly IPermissaoRepository _permissaoRepository;

        public AtribuirPermissaoCommandHandler(ICargoRepository cargoRepository, IPermissaoRepository permissaoRepository)
        {
            _cargoRepository = cargoRepository;
            _permissaoRepository = permissaoRepository;
        }

        public async Task<Guid> Handle(AtribuirPermissaoCommand request, CancellationToken cancellationToken)
        {
            var cargo = await _cargoRepository.ObterPorIdAsync(request.CargoId);
            var permissao = await _permissaoRepository.ObterPorIdAsync(request.PermissaoId);

            if (cargo == null || permissao == null)
            {
                throw new Exception("Não encontrei o cargo ou a permissão!");
            }

            cargo.AdicionarPermissao(permissao);

            await _cargoRepository.AtualizarAsync(cargo);

            return cargo.Id;
        }
    }
}
