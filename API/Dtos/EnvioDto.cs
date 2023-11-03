using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class EnvioDto : BaseEntity
{
    public int IdRemitente { get; set; }
    public int IdDestinatario { get; set; }
    public int IdDireccion { get; set; }
    public int IdPostalEntrega { get; set; }
    public int IdPaquete { get; set; }
    public int IdEstado { get; set; }
    public int IdUbicacion { get; set; }
    
}