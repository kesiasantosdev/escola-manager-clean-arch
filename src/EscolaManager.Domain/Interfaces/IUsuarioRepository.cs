using EscolaManager.Domain.Entities;

namespace EscolaManager.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AdicionarAsync(Usuario usuario);
        Task<Usuario?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Usuario>> ObterTodosAsync();
        Task AtualizarAsync(Usuario usuario);
        Task DeletarAsync(Usuario usuario);
    }
}
