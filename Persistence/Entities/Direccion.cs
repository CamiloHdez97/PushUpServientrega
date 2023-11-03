using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Direccion
{
    public int Id { get; set; }

    public int? DipersonaFk { get; set; }

    public int? IdCiudadFk { get; set; }

    public int? IdTipoViaFk { get; set; }

    public string NumeroCasa { get; set; }

    public virtual Persona DipersonaFkNavigation { get; set; }

    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();

    public virtual Ciudad IdCiudadFkNavigation { get; set; }

    public virtual TipoVium IdTipoViaFkNavigation { get; set; }
}
