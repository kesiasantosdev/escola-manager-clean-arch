using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interface;
using EscolaManager.Infrastructure.Data;

namespace EscolaManager.Infrastructure.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(EscolaDbContext context) : base(context) { }
    }
}
