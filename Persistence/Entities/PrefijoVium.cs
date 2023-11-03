using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class PrefijoVium
{
    public int Id { get; set; }

    public string Descripcion { get; set; }

    public virtual ICollection<TipoVium> TipoVia { get; set; } = new List<TipoVium>();
}
