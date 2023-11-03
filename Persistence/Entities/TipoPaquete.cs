using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class TipoPaquete
{
    public int Id { get; set; }

    public string Descripcion { get; set; }

    public virtual ICollection<Paquete> Paquetes { get; set; } = new List<Paquete>();
}
