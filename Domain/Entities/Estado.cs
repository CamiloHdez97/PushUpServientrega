using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Estado : BaseEntity
{
    public string Descripcion { get; set; }
    public ICollection<Envio> Envios { get; set;}
    
}