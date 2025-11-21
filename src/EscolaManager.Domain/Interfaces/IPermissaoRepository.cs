using EscolaManager.Domain.Entities;

namespace EscolaManager.Domain.Interfaces
{
    public interface IPermissaoRepository
    {
        Task AdicionarAsync(Permissao permissao);
        Task<IEnumerable<Permissao>> ObterTodosAsync();
    }
}
