using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class DireccionDto : BaseEntity
{
    public int IdPersona { get; set; }
    public int IdCiudad { get; set; }    
    public int IdTipoVIa { get; set; }
    public string NumeroCasa { get; set; }

}