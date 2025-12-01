using EscolaManager.Domain.Entities;

namespace EscolaManager.Domain.Interfaces
{
    public interface IPessoaRepository
    {
        Task AdicionarAsync(Pessoa pessoa);
        Task<Pessoa?> ObterPorIdAsync(Guid id);
        Task<Pessoa?> ObterPorEmailAsync(string email);
        Task<IEnumerable<Pessoa>> ObterTodosAsync();
        Task AtualizarAsync(Pessoa pessoa);
        Task DeletarAsync(Pessoa pessoa);
    }
}
