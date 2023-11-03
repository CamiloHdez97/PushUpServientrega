using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Ubicacion : BaseEntity
{
    public string Descripcion { get; set; }
    public string IdPrefijoVia { get; set; }
    public int IdPostal { get; set; }
    public Postal Postal{ get; set; }
    public ICollection<Direccion> Direcciones { get; set; }
}