using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interfaces;
using EscolaManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EscolaManager.Infrastructure.Repositories
{
    public class EscolaRepository : Repository<Escola>, IEscolaRepository
    {
        public EscolaRepository(EscolaDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistePeloCnpjAsync(string cnpj)
        {
            return await _dbSet.AnyAsync(e => e.Cnpj == cnpj);
        }

        public async Task<Usuario?> ObterResponsavelPelaEscolaAsync(Guid escolaId)
        {
            return await _context.Set<Usuario>()
                .FirstOrDefaultAsync(u => u.EscolaId == escolaId);
        }
    }
}