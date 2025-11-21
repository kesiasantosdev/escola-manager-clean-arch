using EscolaManager.Domain.Entities;

namespace EscolaManager.Domain.Interface
{
    public interface ICargoRepository
    {
        Task AdicionarAsync(Cargo cargo);
        Task<Cargo?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Cargo>> ObterTodosAsync();
        Task AtualizarAsync(Cargo cargo);
        Task DeletarAsync(Cargo cargo);
    }
}
