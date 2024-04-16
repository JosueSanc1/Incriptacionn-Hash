using System;
using System.Collections.Generic;

namespace Proyecto1.Models;

public partial class Receta
{
    public int Idreceta { get; set; }

    public int? Idconsulta { get; set; }

    public int? Idmedicamento { get; set; }

    public int? Cantidad { get; set; }

    public string? Frecuencia { get; set; }

    public virtual Consulta? IdconsultaNavigation { get; set; }

    public virtual Medicamento? IdmedicamentoNavigation { get; set; }
}
