
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class PersonaContactoDto : BaseEntity
{
    public int IdPersona { get; set; }
    public int Telefono { get; set; }
    public int TelefonoFijo { get; set; }
    public string Correo { get; set; }
}