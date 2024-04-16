using System;
using System.Collections.Generic;

namespace Proyecto1.Models;

public partial class RegistrosGlucosa
{
    public int IdregistroGlucosa { get; set; }

    public int? Idpaciente { get; set; }

    public DateTime? FechaHoraRegistro { get; set; }

    public decimal? NivelGlucosa { get; set; }

    public string? Comentarios { get; set; }

    public virtual Paciente? IdpacienteNavigation { get; set; }
}
