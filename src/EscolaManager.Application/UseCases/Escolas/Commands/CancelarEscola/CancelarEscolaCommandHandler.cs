using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Escolas.Commands.CancelarEscola
{
    public class CancelarEscolaCommandHandler : IRequestHandler<CancelarEscolaCommand, Unit>
    {
        private readonly IEscolaRepository _repository;

        public CancelarEscolaCommandHandler(IEscolaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CancelarEscolaCommand request, CancellationToken ct)
        {
            var escola = await _repository.ObterPorIdAsync(request.Id);
            if (escola == null) throw new Exception("Escola não encontrada.");

            escola.Cancelar();

            await _repository.AtualizarAsync(escola);

            return Unit.Value;
        }
    }
}