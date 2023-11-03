using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class PaisDto : BaseEntity
{
    public int NombrePais { get; set; }
    
}