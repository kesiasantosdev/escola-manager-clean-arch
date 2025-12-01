using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interfaces;
using EscolaManager.Infrastructure.Data;
using EscolaManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
{
    public PessoaRepository(EscolaDbContext context) : base(context) { }
    public async Task<Pessoa?> ObterPorEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(p => p.Email == email);
    }
}