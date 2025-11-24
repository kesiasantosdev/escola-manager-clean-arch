using EscolaManager.Domain.Entities;

namespace EscolaManager.Domain.Interface
{
    public interface IEscolaRepository
    {
        Task AdicionarAsync(Escola escola);
        Task<Escola?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Escola>> ObterTodosAsync();
        Task AtualizarAsync(Escola escola);
        Task DeletarAsync(Escola escola);
    }
}
