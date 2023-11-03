using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Paquete
{
    public int Id { get; set; }

    public string Descripcion { get; set; }

    public int? IdTipoPaqueteFk { get; set; }

    public string Dimension { get; set; }

    public int? Peso { get; set; }

    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();

    public virtual TipoPaquete IdTipoPaqueteFkNavigation { get; set; }
}
