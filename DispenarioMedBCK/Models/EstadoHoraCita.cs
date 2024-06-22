using System;
using System.Collections.Generic;

namespace DispenarioMedBCK.Models;

public partial class EstadoHoraCita
{
    public int IdEstadhocita { get; set; }

    public string? Disponibilidad { get; set; }

    public virtual ICollection<CitasCanceladasHistorial> CitasCanceladasHistorials { get; set; } = new List<CitasCanceladasHistorial>();

    public virtual ICollection<HorariosCita> HorariosCita { get; set; } = new List<HorariosCita>();
}
