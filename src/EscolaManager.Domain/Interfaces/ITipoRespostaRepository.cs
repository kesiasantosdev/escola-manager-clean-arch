using EscolaManager.Domain.Entities;

namespace EscolaManager.Domain.Interfaces
{
    public interface ITipoRespostaRepository
    {
        Task AdicionarAsync(TipoResposta tipoResposta);
        Task<TipoResposta?> ObterPorId(Guid id);
        Task<IEnumerable<TipoResposta>> ObterTodos();
    }
}
