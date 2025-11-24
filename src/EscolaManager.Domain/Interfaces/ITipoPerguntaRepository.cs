using EscolaManager.Domain.Entities;

namespace EscolaManager.Domain.Interfaces
{
    public interface ITipoPerguntaRepository
    {
        Task AdicionarAsync(TipoPergunta tipoPergunta);
        Task<TipoPergunta?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<TipoPergunta>> ObterTodosAsync();
    }
}
