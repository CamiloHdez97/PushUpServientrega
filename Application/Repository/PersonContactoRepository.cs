using Domain.Entities;
using Domain.Interfaces;
using Persistence;


namespace Application.Repository;
public class PersonaContactoRepository : GenericRepository<PersonaContacto>, IPersonaContacto
{
    public PersonaContactoRepository(ApiDbContext context) : base(context)
    {
    }
}