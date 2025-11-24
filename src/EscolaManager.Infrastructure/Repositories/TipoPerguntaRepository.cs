using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interfaces;
using EscolaManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EscolaManager.Infrastructure.Repositories
{
    public class TipoPerguntaRepository : ITipoPerguntaRepository
    {
        private readonly EscolaDbContext _context;

        public TipoPerguntaRepository(EscolaDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(TipoPergunta tipoPergunta)
        {
            await _context.TiposPerguntas.AddAsync(tipoPergunta);
            await _context.SaveChangesAsync();
        }

        public async Task<TipoPergunta?> ObterPorIdAsync(Guid id)
        {
            return await _context.TiposPerguntas
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<TipoPergunta>> ObterTodosAsync()
        {
            return await _context.TiposPerguntas
                                 .AsNoTracking()
                                 .ToListAsync();
        }
    }
}
