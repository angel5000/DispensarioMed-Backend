using System;
using System.Collections.Generic;

namespace DispenarioMedBCK.Models;

public partial class Ubicacion
{
    public int Idubicacion { get; set; }

    public string? Sector { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}
