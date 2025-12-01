using EscolaManager.Domain.Entities;

namespace EscolaManager.Domain.Interfaces
{
    public interface IEscolaRepository
    {
        Task AdicionarAsync(Escola escola);
        Task<Escola?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Escola>> ObterTodosAsync();
        Task AtualizarAsync(Escola escola);
        Task DeletarAsync(Escola escola);
        Task<bool> ExistePeloCnpjAsync(string cnpj);
    }
}