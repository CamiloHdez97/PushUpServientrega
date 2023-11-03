using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class TipoViaDto : BaseEntity
{
    public string Descripcion { get; set; }
    public int IdPrefijoVia { get; set; }

}