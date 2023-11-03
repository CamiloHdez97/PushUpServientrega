using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Ciudad
{
    public int Id { get; set; }

    public string NombreCiudad { get; set; }

    public int? IdRegionFk { get; set; }

    public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

    public virtual Region IdRegionFkNavigation { get; set; }
}
