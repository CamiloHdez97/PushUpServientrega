using Domain.Entities;
using Domain.Interfaces;
using Persistence;


namespace Application.Repository;
public class PostalRepository : GenericRepository<Postal>, IPostal
{
    public PostalRepository(ApiDbContext context) : base(context)
    {
    }
}