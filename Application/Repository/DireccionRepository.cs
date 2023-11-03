using Domain.Entities;
using Domain.Interfaces;
using Persistence;


namespace Application.Repository;
public class DireccionRepository : GenericRepository<Direccion>, IDireccion
{
    public DireccionRepository(ApiDbContext context) : base(context)
    {
    }
}