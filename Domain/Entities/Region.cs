using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Region : BaseEntity
{
    public string NombreRegion { get; set; }
    public int IdPais { get; set; }
    public ICollection<Ciudad> Ciudades { get; set; }
}