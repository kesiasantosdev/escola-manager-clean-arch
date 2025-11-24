using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interfaces;
using EscolaManager.Infrastructure.Data;

namespace EscolaManager.Infrastructure.Repositories
{
    public class ProvaRepository : Repository<Prova>, IProvaRepository
    {
        public ProvaRepository(EscolaDbContext context) : base(context) { }
    }
}
