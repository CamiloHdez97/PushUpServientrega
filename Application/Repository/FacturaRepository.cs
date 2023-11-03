using Domain.Entities;
using Domain.Interfaces;
using Persistence;


namespace Application.Repository;
public class FacturaRepository : GenericRepository<Factura>, IFactura
{
    public FacturaRepository(ApiDbContext context) : base(context)
    {
    }
}