using EscolaManager.Domain.Entities;

namespace EscolaManager.Domain.Interfaces
{
    public interface IPerguntaRepository
    {
        Task AdicionarAsync(Pergunta pergunta);
        Task<Pergunta?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Pergunta>> ObterTodosAsync();
        Task AtualizarAsync(Pergunta pergunta);
        Task DeletarAsync(Pergunta pergunta);
    }
}
