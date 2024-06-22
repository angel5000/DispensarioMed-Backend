using System;
using System.Collections.Generic;

namespace DispenarioMedBCK.Models;

public partial class CitasCanceladasHistorial
{
    public int Id { get; set; }

    public int? CitaMedica { get; set; }

    public int? EstadoCita { get; set; }

    public int? Estado { get; set; }

    public virtual CitasMedica? CitaMedicaNavigation { get; set; }

    public virtual EstadoHoraCita? EstadoCitaNavigation { get; set; }

    public virtual Estado? EstadoNavigation { get; set; }
}
