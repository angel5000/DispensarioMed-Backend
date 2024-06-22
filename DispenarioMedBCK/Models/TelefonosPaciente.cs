using System;
using System.Collections.Generic;

namespace DispenarioMedBCK.Models;

public partial class TelefonosPaciente
{
    public int IdTelefono { get; set; }

    public int? IdPaciente { get; set; }

    public string? NumeroTelefono { get; set; }

    public virtual Paciente? IdPacienteNavigation { get; set; }
}
