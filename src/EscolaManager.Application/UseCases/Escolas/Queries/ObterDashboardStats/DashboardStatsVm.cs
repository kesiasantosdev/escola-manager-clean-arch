namespace EscolaManager.Application.UseCases.Escolas.Queries.ObterDashboardStats
{
    public class DashboardStatsVm
    {
        public int TotalEscolas { get; set; }
        public int EscolasAtivas { get; set; }
        public int EscolasEmAnalise { get; set; }
        public int EscolasBloqueadas { get; set; }
        public int EscolasCancelada { get; set; }
    }
}