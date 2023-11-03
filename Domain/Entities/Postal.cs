using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Postal : BaseEntity
{
    public int Codigo { get; set; }
    public string Zona { get; set; }
    public ICollection<Envio> Envios { get; set; }
    public ICollection<Ubicacion> Ubicaciones { get; set; }
    
}