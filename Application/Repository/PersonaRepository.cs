using Domain.Entities;
using Domain.Interfaces;
using Persistence;


namespace Application.Repository;
public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    public PersonaRepository(ApiDbContext context) : base(context)
    {
    }
}