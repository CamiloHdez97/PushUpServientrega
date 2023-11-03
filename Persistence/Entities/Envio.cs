using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Envio
{
    public int Id { get; set; }

    public int? IdRemitenteFk { get; set; }

    public int? IdDestinatarioFk { get; set; }

    public int? IdDireccionEntregaFk { get; set; }

    public int? PostalEntregaFk { get; set; }

    public int? IdPaqueteFk { get; set; }

    public int? IdEstadoFk { get; set; }

    public int? IdUbicacion { get; set; }

    public virtual Persona IdDestinatarioFkNavigation { get; set; }

    public virtual Direccion IdDireccionEntregaFkNavigation { get; set; }

    public virtual Estado IdEstadoFkNavigation { get; set; }

    public virtual Paquete IdPaqueteFkNavigation { get; set; }

    public virtual Persona IdRemitenteFkNavigation { get; set; }

    public virtual Ubicacion IdUbicacionNavigation { get; set; }

    public virtual Postal PostalEntregaFkNavigation { get; set; }
}
