using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class TipoPaqueteDto : BaseEntity
{
    public string Descripcion { get; set; }
    
}