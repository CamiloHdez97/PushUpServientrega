using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class PaqueteDto : BaseEntity
{
    public string Descripcion { get; set; }
    public int idTipoPaquete { get; set; }
    public string Dimension { get; set; }
    public double Peso { get; set; }
    
}