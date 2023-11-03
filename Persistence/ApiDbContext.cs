using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ApiDbContext : DbContext
{
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }

            public DbSet<User> Users { get; set; }
            public DbSet<Rol>  Rols { get; set; }
            public DbSet<UserRol> UsersRols { get; set; }
            public DbSet<Ciudad> Ciudads { get; set; }

            public DbSet<Direccion> Direccions { get; set; }

            public DbSet<Envio> Envios { get; set; }

            public DbSet<Estado> Estados { get; set; }

            public DbSet<Pais> Pais { get; set; }

            public DbSet<Paquete> Paquetes { get; set; }

            public DbSet<Persona> Personas { get; set; }

            public DbSet<PersonaContacto> PersonaContactos { get; set; }

            public DbSet<Postal> Postals { get; set; }

            public DbSet<PrefijoVia> PrefijoVia { get; set; }

            public DbSet<Region> Regions { get; set; }

            public DbSet<TipoDocumento> TipoDocumentos { get; set; }

            public DbSet<TipoPaquete> TipoPaquetes { get; set; }

            public DbSet<TipoVia> TipoVia { get; set; }

            public DbSet<Ubicacion> Ubicacions { get; set; }


    public Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

}