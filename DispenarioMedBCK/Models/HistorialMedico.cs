using System;
using System.Collections.Generic;

namespace DispenarioMedBCK.Models;

public partial class HistorialMedico
{
    public int IdHistorial { get; set; }

    public int? IdPaciente { get; set; }

    public int? IdMedico { get; set; }

    public int? FechaVisita { get; set; }

    public string? Sintomas { get; set; }

    public string? Diagnostico { get; set; }

    public string? Tratamiento { get; set; }

    public string? Receta { get; set; }

    public virtual HorariosCita? FechaVisitaNavigation { get; set; }

    public virtual Medico? IdMedicoNavigation { get; set; }

    public virtual Paciente? IdPacienteNavigation { get; set; }
}
