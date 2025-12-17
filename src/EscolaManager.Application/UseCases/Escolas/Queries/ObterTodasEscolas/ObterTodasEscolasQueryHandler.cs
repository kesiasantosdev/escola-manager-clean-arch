using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interfaces;
using MediatR;

namespace EscolaManager.Application.UseCases.Escolas.Queries.ObterTodasEscolas
{
    public class ObterTodasEscolasQueryHandler : IRequestHandler<ObterTodasEscolasQuery, IEnumerable<Escola>>
    {
        private readonly IEscolaRepository _repository;

        public ObterTodasEscolasQueryHandler(IEscolaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Escola>> Handle(ObterTodasEscolasQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObterTodosAsync();
        }
    }
}