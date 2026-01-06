using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Cargos.Queries.ObterCargosPorEscola
{
    public class ObterCargosPorEscolaQueryHandler : IRequestHandler<ObterCargosPorEscolaQuery, IEnumerable<CargoViewModel>>
    {
        private readonly ICargoRepository _cargoRepository;

        public ObterCargosPorEscolaQueryHandler(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public async Task<IEnumerable<CargoViewModel>> Handle(ObterCargosPorEscolaQuery request, CancellationToken cancellationToken)
        {
            var cargos = await _cargoRepository.ObterPorEscolaAsync(request.EscolaId);

            return cargos.Select(c => new CargoViewModel(
                c.Id,
                c.EscolaId,
                c.NomeCargo
            ));
        }
    }
}
