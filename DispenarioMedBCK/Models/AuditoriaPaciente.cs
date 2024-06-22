using System;
using System.Collections.Generic;

namespace DispenarioMedBCK.Models;

public partial class AuditoriaPaciente
{
    public int IdPaciente { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string FechaNacimiento { get; set; } = null!;

    public string Provincia { get; set; } = null!;

    public string Canton { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Genero { get; set; } = null!;
}
