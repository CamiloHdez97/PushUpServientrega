using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Postal
{
    public int Codigo { get; set; }

    public string Zona { get; set; }

    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();

    public virtual ICollection<Ubicacion> Ubicacions { get; set; } = new List<Ubicacion>();
}
