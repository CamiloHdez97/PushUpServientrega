using Domain.Entities;
using Domain.Interfaces;
using Persistence;


namespace Application.Repository;
public class EnvioRepository : GenericRepository<Envio>, IEnvio
{
    public EnvioRepository(ApiDbContext context) : base(context)
    {
    }
}