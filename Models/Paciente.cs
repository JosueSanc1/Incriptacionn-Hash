using System;
using System.Collections.Generic;

namespace Proyecto1.Models;

public partial class Paciente
{
    public int Idpaciente { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Genero { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? TipoDiabetes { get; set; }

    public string? Dpi { get; set; }

    public virtual ICollection<Cita> Cita { get; } = new List<Cita>();

    public virtual ICollection<Consulta> Consulta { get; } = new List<Consulta>();

    public virtual ICollection<RegistrosGlucosa> RegistrosGlucosas { get; } = new List<RegistrosGlucosa>();

    public virtual ICollection<RegistrosMedico> RegistrosMedicos { get; } = new List<RegistrosMedico>();
}
