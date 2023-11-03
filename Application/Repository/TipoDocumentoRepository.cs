using Domain.Entities;
using Domain.Interfaces;
using Persistence;


namespace Application.Repository;
public class TipoDocumentoRepository : GenericRepository<TipoDocumento>, ITipoDocumento
{
    public TipoDocumentoRepository(ApiDbContext context) : base(context)
    {
    }
}