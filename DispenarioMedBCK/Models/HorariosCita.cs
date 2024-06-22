using System;
using System.Collections.Generic;

namespace DispenarioMedBCK.Models;

public partial class HorariosCita
{
    public int IdHorario { get; set; }

    public int? IdDoctor { get; set; }

    public int? Areas { get; set; }

    public DateTime? FechaHora { get; set; }

    public int? Disponibeid { get; set; }

    public DateTime? FechaFin { get; set; }

    public virtual Area? AreasNavigation { get; set; }

    public virtual ICollection<CitasMedica> CitasMedicas { get; set; } = new List<CitasMedica>();

    public virtual EstadoHoraCita? Disponibe { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<HistorialMedico> HistorialMedicos { get; set; } = new List<HistorialMedico>();

    public virtual Medico? IdDoctorNavigation { get; set; }
}
