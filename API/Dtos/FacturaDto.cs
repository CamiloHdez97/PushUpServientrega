using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class FacturaDto : BaseEntity
{
    public int IdEnvio { get; set; }
    public double Valor { get; set; }
    public double Impuesto { get; set; }
        
}