using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Cargos.Command.DeletarCargos
{
    public class DeletarCargoCommandHadler : IRequestHandler<DeletarCargoCommand, bool>
    {
        private readonly ICargoRepository _cargoRepository;

        public DeletarCargoCommandHadler(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public async Task<bool> Handle(DeletarCargoCommand request, CancellationToken cancellationToken)
        {
            var cargo = await _cargoRepository.ObterPorIdAsync(request.Id);
            if (cargo == null)
            {
                return false;

            }
            await _cargoRepository.DeletarAsync(cargo);

            return true;
        }
    }
}
