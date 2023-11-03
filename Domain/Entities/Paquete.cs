using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Paquete : BaseEntity
{
    public string Descripcion { get; set; }
    public int idTipoPaquete { get; set; }
    public TipoPaquete TipoPaquete { get; set;}
    public string Dimension { get; set; }
    public double Peso { get; set; }
    public ICollection<Envio> Envios { get; set; }
    
}