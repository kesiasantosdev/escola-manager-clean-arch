using EscolaManager.Domain.Entities;
using EscolaManager.Domain.Interface;
using EscolaManager.Infrastructure.Data;

namespace EscolaManager.Infrastructure.Repositories
{
    public class CargoRepository : Repository<Cargo>, ICargoRepository
    {
        public CargoRepository(EscolaDbContext context) : base(context) { }
    }
}
