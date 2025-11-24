using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interfaces;
using EscolaManager.Infrastructure.Data;

namespace EscolaManager.Infrastructure.Repositories
{
    public class PerguntaRepository : Repository<Pergunta>, IPerguntaRepository
    {
        public PerguntaRepository(EscolaDbContext context) : base(context) { }
    }
}