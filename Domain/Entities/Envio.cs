using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Envio : BaseEntity
{
    public int IdRemitente { get; set; }
    public Persona PersonaR { get; set; }
    public int IdDestinatario { get; set; }
    public Persona PersonaD { get; set; }
    public int IdDireccion { get; set; }
    public Direccion Direccion { get; set; }
    public int IdPostalEntrega { get; set; }
    public Postal Postal { get; set; }
    public int IdPaquete { get; set; }
    public Paquete Paquete { get; set; }
    public int IdEstado { get; set; }
    public Estado Estado {get; set; }
    public int IdUbicacion { get; set; }
    public Ubicacion Ubicacion {get; set; }
    public ICollection<Factura> Factura { get; set;}
    
}