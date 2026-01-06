using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Cargos.Command.AtualizarCargos
{
    public class AtualizarCargoCommandHandler : IRequestHandler<AtualizarCargoCommand, bool>
    {
        private readonly ICargoRepository _cargoRepository;

        public AtualizarCargoCommandHandler(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;

        }

        public async Task<bool> Handle(AtualizarCargoCommand request, CancellationToken cancellationToken)
        {
            var cargo = await _cargoRepository.ObterPorIdAsync(request.Id);
            if (cargo == null)
            {
                return false;

            }

            cargo.AlterarNome(request.novoNome);
            await _cargoRepository.AtualizarAsync(cargo);
            return true;
        }
    }
}
