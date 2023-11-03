using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Persona
{
    public int Id { get; set; }

    public int? IdTipoDocumentoFk { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

    public virtual ICollection<Envio> EnvioIdDestinatarioFkNavigations { get; set; } = new List<Envio>();

    public virtual ICollection<Envio> EnvioIdRemitenteFkNavigations { get; set; } = new List<Envio>();

    public virtual TipoDocumento IdTipoDocumentoFkNavigation { get; set; }

    public virtual ICollection<PersonaContacto> PersonaContactos { get; set; } = new List<PersonaContacto>();
}
