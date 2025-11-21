using EscolaManager.Domain.Entities;

namespace EscolaManager.Domain.Interface
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
