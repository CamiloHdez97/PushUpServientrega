using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class CiudadDto : BaseEntity
{
    public string NombreCiudad { get; set; }
    public int IdRegion { get; set; }
}
