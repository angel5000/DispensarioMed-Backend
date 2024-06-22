using System;
using System.Collections.Generic;

namespace DispenarioMedBCK.Models;

public partial class UsuariosinactivosHistorial
{
    public int Id { get; set; }

    public int? Pacientes { get; set; }

    public int? Medicos { get; set; }

    public int? Estado { get; set; }

    public virtual Estado? EstadoNavigation { get; set; }

    public virtual Medico? MedicosNavigation { get; set; }

    public virtual Paciente? PacientesNavigation { get; set; }
}
