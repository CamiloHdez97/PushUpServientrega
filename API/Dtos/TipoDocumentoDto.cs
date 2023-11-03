using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class TipoDocumentoDto : BaseEntity
{
    public string Descripcion { get; set; }
    
}