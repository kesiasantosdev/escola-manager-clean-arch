using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interface;
using EscolaManager.Infrastructure.Data;

namespace EscolaManager.Infrastructure.Repositories
{
    public class BimestreRepository : Repository<Bimestre>, IBimestreRepository
    {
        public BimestreRepository(EscolaDbContext context) : base(context) { }
    }
}
