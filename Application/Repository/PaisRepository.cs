using Domain.Entities;
using Domain.Interfaces;
using Persistence;


namespace Application.Repository;
public class PaisRepository : GenericRepository<Pais>, IPais
{
    public PaisRepository(ApiDbContext context) : base(context)
    {
    }
}