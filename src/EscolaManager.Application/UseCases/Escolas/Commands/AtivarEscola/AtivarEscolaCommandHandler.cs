using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Escolas.Commands.AtivarEscola
{
    public class AtivarEscolaCommandHandler : IRequestHandler<AtivarEscolaCommand, Unit>
    {
        private readonly IEscolaRepository _repository;

        public AtivarEscolaCommandHandler(IEscolaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AtivarEscolaCommand request, CancellationToken cancellationToken)
        {
            var escola = await _repository.ObterPorIdAsync(request.Id);

            if (escola == null)
            {
                throw new Exception("Escola não encontrada.");
            }

            escola.Ativar();

            await _repository.AtualizarAsync(escola);

            return Unit.Value;
        }
    }
}