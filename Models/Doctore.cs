using System;
using System.Collections.Generic;

namespace Proyecto1.Models;

public partial class Doctore
{
    public int Iddoctor { get; set; }

    public string? NombreDoctor { get; set; }

    public string? Dpi { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Especialidad { get; set; }

    public virtual ICollection<Cita> Cita { get; } = new List<Cita>();

    public virtual ICollection<Consulta> Consulta { get; } = new List<Consulta>();
}
