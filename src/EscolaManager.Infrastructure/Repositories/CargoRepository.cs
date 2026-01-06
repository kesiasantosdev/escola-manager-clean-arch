using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interfaces;
using EscolaManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EscolaManager.Infrastructure.Repositories
{
    public class CargoRepository : Repository<Cargo>, ICargoRepository
    {
        public CargoRepository(EscolaDbContext context) : base(context) { }

        public async Task<IEnumerable<Cargo>> ObterPorEscolaAsync(Guid escolaId)
        {
            return await _context.Cargos
                                 .AsNoTracking()
                                 .Where(c => c.EscolaId == escolaId)
                                 .ToListAsync();
        }
    }
}
