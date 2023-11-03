using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Region
{
    public int Id { get; set; }

    public string NombreRegion { get; set; }

    public int? IdPaisFk { get; set; }

    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();

    public virtual Pai IdPaisFkNavigation { get; set; }
}
