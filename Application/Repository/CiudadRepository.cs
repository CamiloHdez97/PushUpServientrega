using Domain.Entities;
using Domain.Interfaces;
using Persistence;


namespace Application.Repository;
public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
{
    public CiudadRepository(ApiDbContext context) : base(context)
    {
    }
}