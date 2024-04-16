using System;
using System.Collections.Generic;

namespace Proyecto1.Models;

public partial class Cita
{
    public int Idcita { get; set; }

    public int? Idpaciente { get; set; }

    public int? Iddoctor { get; set; }

    public DateTime? FechaHoraCita { get; set; }

    public TimeSpan? Duracion { get; set; }

    public string? EstadoCita { get; set; }

    public string? NotasCita { get; set; }

    public virtual Doctore? IddoctorNavigation { get; set; }

    public virtual Paciente? IdpacienteNavigation { get; set; }
}
