using EscolaManager.Domain.Entities;

namespace EscolaManager.Domain.Interfaces
{
    public interface IPermissaoRepository
    {
        Task AdicionarAsync(Permissao permissao);
        Task<Permissao?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Permissao>> ObterTodosAsync();
        Task AtualizarAsync(Permissao permissao);
    }
}
