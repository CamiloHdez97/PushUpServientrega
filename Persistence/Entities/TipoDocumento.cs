﻿using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class TipoDocumento
{
    public int Id { get; set; }

    public string Descripcion { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
