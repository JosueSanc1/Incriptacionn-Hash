using System;
using System.Collections.Generic;

namespace Proyecto1.Models;

public partial class Usuario
{
    public int Idusuario { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Contraseña { get; set; }

    public string? TipoUsuario { get; set; }

    public int? Iddoctor { get; set; }

    public int? Idpaciente { get; set; }
}
