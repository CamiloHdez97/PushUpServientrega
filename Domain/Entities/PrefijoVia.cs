using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class PrefijoVia : BaseEntity
{
    public int IdTipoDocumento { get; set; }
    public string Descripcion { get; set; }
    public ICollection<TipoVia> TipoVia { get; set; }
}