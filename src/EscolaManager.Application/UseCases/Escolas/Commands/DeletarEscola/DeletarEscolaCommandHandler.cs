using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Escolas.Commands.DeletarEscola
{
    public class DeletarEscolaCommandHandler : IRequestHandler<DeletarEscolaCommand, Unit>
    {
        private readonly IEscolaRepository _repository;

        public DeletarEscolaCommandHandler(IEscolaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletarEscolaCommand request, CancellationToken ct)
        {
            var escola = await _repository.ObterPorIdAsync(request.Id);
            if (escola == null) throw new Exception("Escola não encontrada.");

            // Manda a ordem de EXTERMÍNIO para o banco
            await _repository.DeletarAsync(escola);

            return Unit.Value;
        }
    }
}