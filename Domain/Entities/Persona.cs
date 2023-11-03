using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Persona : BaseEntity
{
    public int IdTipoDocumento { get; set; }
    public TipoDocumento TipoDocumento { get; set; }
    public string Nombres { get; set;}
    public string Apellidos { get; set; }
    public ICollection<Envio> Envios { get; set; }
    public ICollection<PersonaContacto> PersonaContactos { get; set; }
    public ICollection<Direccion> Direcciones { get; set; }
}