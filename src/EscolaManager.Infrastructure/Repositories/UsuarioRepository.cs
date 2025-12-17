using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interfaces;
using EscolaManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EscolaManager.Infrastructure.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(EscolaDbContext context) : base(context) { }
        public async Task<Usuario?> ObterPorPessoaIdAsync(Guid pessoaId)
        {
            return await _dbSet
                .Include(u => u.Cargo)
                .Include(u => u.Escola)
                .FirstOrDefaultAsync(u => u.PessoaId == pessoaId);
        }
    }
}