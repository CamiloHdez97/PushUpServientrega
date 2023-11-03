using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class TipoVia : BaseEntity
{
    public string Descripcion { get; set; }
    public int IdPrefijoVia { get; set; }
    public PrefijoVia PrefijoVia { get; set; }
    public ICollection<Direccion> Direcciones { get; set; }
}