using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class PostalDto : BaseEntity
{
    public int Codigo { get; set; }
    public string Zona { get; set; }
    
}