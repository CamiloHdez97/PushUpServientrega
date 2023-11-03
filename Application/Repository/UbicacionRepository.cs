using Domain.Entities;
using Domain.Interfaces;
using Persistence;


namespace Application.Repository;
public class UbicacionRepository : GenericRepository<Ubicacion>, IUbicacion
{
    public UbicacionRepository(ApiDbContext context) : base(context)
    {
    }
}