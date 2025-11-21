using EscolaManager.Domain.Entities;

namespace EscolaManager.Domain.Interfaces
{
    public interface ITipoPerguntaRepository
    {
        Task AdicionarAsync(TipoPergunta tipoPergunta);
        Task<TipoPergunta?> ObterPorId(Guid id);
        Task<IEnumerable<TipoPergunta>> ObterTodos();
    }
}
