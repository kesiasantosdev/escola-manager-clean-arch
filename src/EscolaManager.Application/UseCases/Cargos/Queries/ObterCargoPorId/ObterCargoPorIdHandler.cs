using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Cargos.Queries.ObterCargoPorId
{
    public class ObterCargoPorIdHandler : IRequestHandler<ObterCargoPorIdQuery, CargoViewModel?>
    {
        private readonly ICargoRepository _cargoRepository;

        public ObterCargoPorIdHandler(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public async Task<CargoViewModel?> Handle(ObterCargoPorIdQuery request, CancellationToken cancellationToken)
        {
            var cargo = await _cargoRepository.ObterPorIdAsync(request.Id);

            if (cargo == null) return null;

            return new CargoViewModel(cargo.Id, cargo.EscolaId, cargo.NomeCargo);
        }
    }
}
