using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Ubicacion
{
    public int Id { get; set; }

    public string Latitud { get; set; }

    public string Longitud { get; set; }

    public int? PostalActual { get; set; }

    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();

    public virtual Postal PostalActualNavigation { get; set; }
}
