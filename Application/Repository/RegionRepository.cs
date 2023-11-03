using Domain.Entities;
using Domain.Interfaces;
using Persistence;


namespace Application.Repository;
public class RegionRepository : GenericRepository<Region>, IRegion
{
    public RegionRepository(ApiDbContext context) : base(context)
    {
    }
}