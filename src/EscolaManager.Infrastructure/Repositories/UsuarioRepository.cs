using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interfaces;
using EscolaManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EscolaManager.Infrastructure.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(EscolaDbContext context) : base(context) { }
        public async Task<Usuario?> ObterPorEmailAsync(string email)
        {
            return await _dbSet
         .Include(u => u.Escola)
         .Include(u => u.Cargo)
         .FirstOrDefaultAsync(p => p.Email == email);
        }
    }
}