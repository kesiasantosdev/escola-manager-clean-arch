using EscolaManager.Domain.Entities;

namespace EscolaManager.Domain.Interfaces
{
    public interface IBimestreRepository
    {
        Task AdicionarAsync(Bimestre bimestre);
        Task<Bimestre?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Bimestre>> ObterTodosAsync();
        Task AtualizarAsync(Bimestre bimestre);
        Task DeletarAsync(Bimestre bimestre);
    }
}
