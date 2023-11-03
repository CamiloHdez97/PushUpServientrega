using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string Correo { get; set; }

    public string Contrasena { get; set; }

    public string TokenAccess { get; set; }

    public string TokenRefresh { get; set; }
}
