using EscolaManager.Domain.Entities;

namespace EscolaManager.Domain.Interface
{
    public interface IPessoaRepository
    {
        Task AdicionarAsync(Pessoa pessoa);
        Task<Pessoa?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Pessoa>> ObterTodosAsync();
        Task AtualizarAsync(Pessoa pessoa);
        Task DeletarAsync(Pessoa pessoa);
    }
}
