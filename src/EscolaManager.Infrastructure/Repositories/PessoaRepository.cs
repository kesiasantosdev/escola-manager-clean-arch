using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interface;
using EscolaManager.Infrastructure.Data;

namespace EscolaManager.Infrastructure.Repositories
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(EscolaDbContext context) : base(context) { }
    }
}
