using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interface;
using EscolaManager.Infrastructure.Data;

namespace EscolaManager.Infrastructure.Repositories
{
    public class EscolaRepository : Repository<Escola>, IEscolaRepository
    {
        public EscolaRepository(EscolaDbContext context) : base(context) { }

    }
}
