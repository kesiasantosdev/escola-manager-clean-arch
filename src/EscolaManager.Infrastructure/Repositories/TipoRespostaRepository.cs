using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interfaces;
using EscolaManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EscolaManager.Infrastructure.Repositories
{
    public class TipoRespostaRepository : ITipoRespostaRepository
    {
        private readonly EscolaDbContext _context;

        public TipoRespostaRepository(EscolaDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(TipoResposta tipoResposta)
        {
            await _context.TiposRespostas.AddAsync(tipoResposta);
            await _context.SaveChangesAsync();
        }

        public async Task<TipoResposta?> ObterPorIdAsync(Guid id)
        {
            return await _context.TiposRespostas
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<TipoResposta>> ObterTodosAsync()
        {
            return await _context.TiposRespostas
                                 .AsNoTracking()
                                 .ToListAsync();
        }
    }
}
