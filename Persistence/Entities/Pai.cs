using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Pai
{
    public int Id { get; set; }

    public string NombrePais { get; set; }

    public virtual ICollection<Region> Regions { get; set; } = new List<Region>();
}
