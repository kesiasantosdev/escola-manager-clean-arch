using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interfaces;
using MediatR;


namespace EscolaManager.Application.UseCases.Escolas.Queries.ObterDashboardStats
{
    public class ObterDashboardStatsQueryHandler : IRequestHandler<ObterDashboardStatsQuery, DashboardStatsVm>
    {
        private readonly IEscolaRepository _repository;

        public ObterDashboardStatsQueryHandler(IEscolaRepository repository)
        {
            _repository = repository;
        }

        public async Task<DashboardStatsVm> Handle(ObterDashboardStatsQuery request, CancellationToken cancellationToken)
        {
            var todasEscolas = await _repository.ObterTodosAsync();


            var stats = new DashboardStatsVm
            {
                TotalEscolas = todasEscolas.Count(),

                EscolasAtivas = todasEscolas.Count(e => e.Status == StatusEscola.Ativa),
                EscolasEmAnalise = todasEscolas.Count(e => e.Status == StatusEscola.EmAnalise),
                EscolasBloqueadas = todasEscolas.Count(e => e.Status == StatusEscola.Bloqueada),
                EscolasCancelada = todasEscolas.Count(e => e.Status == StatusEscola.Cancelada)
            };

            return stats;
        }
    }
}