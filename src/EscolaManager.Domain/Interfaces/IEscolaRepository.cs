using EscolaManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EscolaManager.Domain.Interfaces
{
    public interface IEscolaRepository
    {
        Task AdicionarAsync(Escola escola);
        Task<Escola?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Escola>> ObterTodosAsync();
        Task AtualizarAsync(Escola escola);
        Task DeletarAsync(Escola escola);
        Task<bool> ExistePeloCnpjAsync(string cnpj);
    }
}