using EscolaManager.Domain.Entities;

namespace EscolaManager.Domain.Interface
{
    public interface IRealizacaoProvaRepository
    {
        Task AdicionarAsync(RealizacaoProva realizacaoProva);
        Task<RealizacaoProva?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<RealizacaoProva>> ObterTodosAsync();
        Task AtualizarAsync(RealizacaoProva realizacaoProva);
        Task DeletarAsync(RealizacaoProva realizacaoProva);
    }
}
