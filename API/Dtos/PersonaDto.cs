using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class PersonaDto : BaseEntity
{
    public int IdTipoDocumento { get; set; }
    public string Nombres { get; set;}
    public string Apellidos { get; set; }

}