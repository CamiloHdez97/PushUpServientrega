
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class PersonaContacto : BaseEntity
{
    public int idPersona { get; set; }
    public Persona Persona { get; set;}
    public int Telefono { get; set; }
    public int TelefonoFijo { get; set; }
    public string Correo { get; set; }
}