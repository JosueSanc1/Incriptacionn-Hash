using System;
using System.Collections.Generic;

namespace Proyecto1.Models;

public partial class Consulta
{
    public int Idconsulta { get; set; }

    public int? Idpaciente { get; set; }

    public int? Iddoctor { get; set; }

    public DateTime? FechaConsulta { get; set; }

    public decimal? Glucosa { get; set; }

    public decimal? Peso { get; set; }

    public string? PresionArterial { get; set; }

    public string? DescripcionConsulta { get; set; }

    public virtual Doctore? IddoctorNavigation { get; set; }

    public virtual Paciente? IdpacienteNavigation { get; set; }

    public virtual ICollection<Receta> Receta { get; } = new List<Receta>();
}
