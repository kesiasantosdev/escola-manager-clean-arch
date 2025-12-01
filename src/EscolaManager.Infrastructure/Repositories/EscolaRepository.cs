using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interfaces;
using EscolaManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore; // Necessário para o AnyAsync

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
    }
}