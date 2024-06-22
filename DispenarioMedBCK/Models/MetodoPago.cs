using System;
using System.Collections.Generic;

namespace DispenarioMedBCK.Models;

public partial class MetodoPago
{
    public int IdMetPago { get; set; }

    public string? Metodo { get; set; }

    public virtual ICollection<PagosRealizado> PagosRealizados { get; set; } = new List<PagosRealizado>();
}
