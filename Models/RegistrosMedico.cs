using System;
using System.Collections.Generic;

namespace Proyecto1.Models;

public partial class RegistrosMedico
{
    public int IdregistroMedico { get; set; }

    public int? Idpaciente { get; set; }

    public DateTime? FechaHoraRegistro { get; set; }

    public string? TipoRegistro { get; set; }

    public string? Descripcion { get; set; }

    public virtual Paciente? IdpacienteNavigation { get; set; }
}
