using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace API.Dtos;

public class RegionDto : BaseEntity
{
    public string NombreRegion { get; set; }
    public int IdPais { get; set; }
}