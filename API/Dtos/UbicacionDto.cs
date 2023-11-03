using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using iText.Layout.Element;

namespace API.Dtos;

public class UbicacionDto : BaseEntity
{
    public string Descripcion { get; set; }
    public string IdPrefijoVia { get; set; }
    public int IdPostal { get; set; }
}