using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interfaces;
using EscolaManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EscolaManager.Infrastructure.Repositories
{
    public class PermissaoRepository : IPermissaoRepository
    {
        private readonly EscolaDbContext _context;

        public PermissaoRepository(EscolaDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Permissao permissao)
        {
            await _context.Permissoes.AddAsync(permissao);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Permissao>> ObterTodosAsync()
        {
            return await _context.Permissoes
                                 .AsNoTracking()
                                 .ToListAsync();
        }
    }
}
