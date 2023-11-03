using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class PrefijoViaDto : BaseEntity
{
    public int IdTipoDocumento { get; set; }
    public string Descripcion { get; set; }

}