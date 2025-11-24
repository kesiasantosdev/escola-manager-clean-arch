
using EscolaManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore; // Usa o EF Core

namespace EscolaManager.Infrastructure.Repositories
{
    // <T> significa: "Isso funciona para QUALQUER entidade"
    public abstract class Repository<T> where T : class
    {
        protected readonly EscolaDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(EscolaDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        // Adicionar
        public async Task AdicionarAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // Buscar por ID
        public async Task<T?> ObterPorIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Listar Todos
        public async Task<IEnumerable<T>> ObterTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }

        // Atualizar
        public async Task AtualizarAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        // Deletar
        public async Task DeletarAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}