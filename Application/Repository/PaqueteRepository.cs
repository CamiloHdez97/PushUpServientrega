using Domain.Entities;
using Domain.Interfaces;
using Persistence;


namespace Application.Repository;
public class PaqueteRepository : GenericRepository<Paquete>, IPaquete
{
    public PaqueteRepository(ApiDbContext context) : base(context)
    {
    }
}