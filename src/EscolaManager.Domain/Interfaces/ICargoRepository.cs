using EscolaManager.Domain.Entities;

namespace EscolaManager.Domain.Interfaces
{
    public interface ICargoRepository
    {
        Task AdicionarAsync(Cargo cargo);
        Task<Cargo?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Cargo>> ObterTodosAsync();
        Task<IEnumerable<Cargo>> ObterPorEscolaAsync(Guid escolaId);
        Task AtualizarAsync(Cargo cargo);
        Task DeletarAsync(Cargo cargo);
    }
}
