using System;
using System.Collections.Generic;

namespace DispenarioMedBCK.Models;

public partial class EjemploTabla
{
    public int Id { get; set; }

    public string? Datos { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
