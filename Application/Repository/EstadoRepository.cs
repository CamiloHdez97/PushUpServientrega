using Domain.Entities;
using Domain.Interfaces;
using Persistence;


namespace Application.Repository;
public class EstadoRepository : GenericRepository<Estado>, IEstado
{
    public EstadoRepository(ApiDbContext context) : base(context)
    {
    }
}