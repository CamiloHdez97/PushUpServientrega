using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Pais : BaseEntity
{
    public int NombrePais { get; set; }
    
}