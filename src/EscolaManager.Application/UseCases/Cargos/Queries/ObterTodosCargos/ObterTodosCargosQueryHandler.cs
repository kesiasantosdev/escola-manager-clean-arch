using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Cargos.Queries.ObterTodosCargos
{
    public class ObterTodosCargosHandler : IRequestHandler<ObterTodosCargosQuery, IEnumerable<CargoViewModel>>
    {
        private readonly ICargoRepository _cargoRepository;

        public ObterTodosCargosHandler(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public async Task<IEnumerable<CargoViewModel>> Handle(ObterTodosCargosQuery request, CancellationToken cancellationToken)
        {
            var cargos = await _cargoRepository.ObterTodosAsync();

            return cargos.Select(c => new CargoViewModel(c.Id, c.EscolaId, c.NomeCargo));
        }
    }
}
