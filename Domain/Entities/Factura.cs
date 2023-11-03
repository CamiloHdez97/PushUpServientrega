using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Factura : BaseEntity
{
    public int IdEnvio { get; set; }
    public Envio Envio { get; set; }
    public double Valor { get; set; }
    public double Impuesto { get; set; }
        
}