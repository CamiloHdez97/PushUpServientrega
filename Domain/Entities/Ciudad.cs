using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Ciudad : BaseEntity
{
    public string NombreCiudad { get; set; }
    public int IdRegion { get; set; }
    public Region Region { get; set; }
    public ICollection<Direccion> Direcciones { get; set; }
}
