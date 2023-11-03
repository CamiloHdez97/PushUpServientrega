using Domain.Entities;
using Domain.Interfaces;
using Persistence;


namespace Application.Repository;
public class TipoPaqueteRepository : GenericRepository<TipoPaquete>, ITipoPaquete
{
    public TipoPaqueteRepository(ApiDbContext context) : base(context)
    {
    }
}