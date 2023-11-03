using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Estado
{
    public int Id { get; set; }

    public string Descripcion { get; set; }

    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();
}
