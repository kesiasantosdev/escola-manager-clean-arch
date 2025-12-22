using EscolaManager.Application.UseCases.Cargos.Commands.CriarCargos;
using EscolaManager.Domain.Interfaces;
using Entities = EscolaManager.Domain.Entities;
using MediatR;

namespace EscolaManager.Application.UseCases.Cargos.Command.CriarCargos
{
    public class CriarCargoCommandHandler : IRequestHandler<CriarCargoCommand, Guid>
    {
        private ICargoRepository _cargoRepository;

        public CriarCargoCommandHandler(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public async Task<Guid> Handle(CriarCargoCommand request, CancellationToken cancellationToken)
        {
            var novoCargo = new Entities.Cargo(request.NomeCargo, request.EscolaId);

            await _cargoRepository.AdicionarAsync(novoCargo);

            return novoCargo.Id;
        }
    }
}
