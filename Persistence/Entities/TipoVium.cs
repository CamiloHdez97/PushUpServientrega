using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class TipoVium
{
    public int Id { get; set; }

    public string Descripcion { get; set; }

    public int? IdPrefijoFk { get; set; }

    public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

    public virtual PrefijoVium IdPrefijoFkNavigation { get; set; }
}
