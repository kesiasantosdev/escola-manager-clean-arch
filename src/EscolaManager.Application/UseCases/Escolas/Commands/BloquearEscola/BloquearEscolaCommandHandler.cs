using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Escolas.Commands.BloquearEscola
{
    public class BloquearEscolaCommandHandler : IRequestHandler<BloquearEscolaCommand, Unit>
    {
        private readonly IEscolaRepository _repository;

        public BloquearEscolaCommandHandler(IEscolaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(BloquearEscolaCommand request, CancellationToken ct)
        {
            var escola = await _repository.ObterPorIdAsync(request.Id);
            if (escola == null) throw new Exception("Escola não encontrada.");

            escola.Bloquear();

            await _repository.AtualizarAsync(escola);
            return Unit.Value;
        }
    }
}