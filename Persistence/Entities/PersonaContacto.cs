using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class PersonaContacto
{
    public int Id { get; set; }

    public int? DipersonaFk { get; set; }

    public int? Telefono { get; set; }

    public int? TelefonoFijo { get; set; }

    public string Correo { get; set; }

    public virtual Persona DipersonaFkNavigation { get; set; }
}
