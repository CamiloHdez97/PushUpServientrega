using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class EstadoDto : BaseEntity
{
    public string Descripcion { get; set; }
    
}