using System;
using System.Collections.Generic;

namespace Proyecto1.Models;

public partial class Medicamento
{
    public int Idmedicamento { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Receta> Receta { get; } = new List<Receta>();
}
