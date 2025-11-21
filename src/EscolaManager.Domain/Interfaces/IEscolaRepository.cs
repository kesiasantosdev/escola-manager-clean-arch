using EscolaManager.Domain.Entities;

namespace EscolaManager.Domain.Interface
{
    public interface IEscolaRepository
    {
        Task AdicionarAsync(Escola escola);
        Task<Escola?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Escola>> ObterTodasAsync();
        Task AtualizarAsync(Escola escola);
        Task DeletarAsync(Escola escola);
    }
}
