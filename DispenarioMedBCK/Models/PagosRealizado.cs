using System;
using System.Collections.Generic;

namespace DispenarioMedBCK.Models;

public partial class PagosRealizado
{
    public int IdMetPago { get; set; }

    public int? IdPaciente { get; set; }

    public int? IdMotivo { get; set; }

    public int? IdMetodoPago { get; set; }

    public virtual MetodoPago? IdMetodoPagoNavigation { get; set; }

    public virtual Paciente? IdPacienteNavigation { get; set; }
}
