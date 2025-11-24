using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interface;
using EscolaManager.Infrastructure.Data;

namespace EscolaManager.Infrastructure.Repositories
{
    public class RealizacaoProvaRepository : Repository<RealizacaoProva>, IRealizacaoProvaRepository
    {
        public RealizacaoProvaRepository(EscolaDbContext context) : base(context) { }
    }
}
