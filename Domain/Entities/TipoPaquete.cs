using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class TipoPaquete : BaseEntity
{
    public string Descripcion { get; set; }
    public ICollection<Paquete> Paquetes { get; set; }
}