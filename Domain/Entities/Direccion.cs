using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Direccion : BaseEntity
{
    public int IdPersona { get; set; }
    public Persona Persona { get; set; }
    public int IdCiudad { get; set; }
    public Ciudad Ciudad { get; set; }
    public int IdTipoVIa { get; set; }
    public TipoVia TipoVia { get; set; }
    public string NumeroCasa { get; set; }
    public ICollection<Envio> Envios { get; set;}

}