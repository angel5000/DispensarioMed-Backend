using System;
using System.Collections.Generic;

namespace DispenarioMedBCK.Models;

public partial class CitasMedica
{
    public int Idcita { get; set; }

    public int Idpaciente { get; set; }

    public int Idmedico { get; set; }

    public int IdhorarioCitas { get; set; }

    public int? Motivo { get; set; }

    public virtual ICollection<CitasCanceladasHistorial> CitasCanceladasHistorials { get; set; } = new List<CitasCanceladasHistorial>();

    public virtual HorariosCita IdhorarioCitasNavigation { get; set; } = null!;

    public virtual Medico IdmedicoNavigation { get; set; } = null!;

    public virtual Paciente IdpacienteNavigation { get; set; } = null!;

    public virtual MotivosCitasMedica? MotivoNavigation { get; set; }
}
