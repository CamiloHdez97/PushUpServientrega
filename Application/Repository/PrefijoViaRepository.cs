using Domain.Entities;
using Domain.Interfaces;
using Persistence;


namespace Application.Repository;
public class PrefijoViaRepository : GenericRepository<PrefijoVia>, IPrefijoVia
{
    public PrefijoViaRepository(ApiDbContext context) : base(context)
    {
    }
}