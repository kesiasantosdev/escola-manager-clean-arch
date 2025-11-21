using EscolaManager.Domain.Entities;

namespace EscolaManager.Domain.Interface
{
    public interface IProvaRepository
    {
        Task AdicionarAsync(Prova prova);
        Task<Prova?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Prova>> ObterTodosAsync();
        Task AtualizarAsync(Prova prova);
        Task DeletarAsync(Prova prova);
    }
}
