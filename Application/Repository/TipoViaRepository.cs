using Domain.Entities;
using Domain.Interfaces;
using Persistence;


namespace Application.Repository;
public class TipoViaRepository : GenericRepository<TipoVia>, ITipoVia
{
    public TipoViaRepository(ApiDbContext context) : base(context)
    {
    }
}