using System;
using System.Collections.Generic;

namespace DispenarioMedBCK.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public int? IdPaciente { get; set; }

    public int? IdMedico { get; set; }

    public int? FechaVisita { get; set; }

    public int? Motivo { get; set; }

    public double? Subtotal { get; set; }

    public double? Total { get; set; }

    public double? Iva { get; set; }

    public double? Costo { get; set; }

    public virtual HorariosCita? FechaVisitaNavigation { get; set; }

    public virtual Medico? IdMedicoNavigation { get; set; }

    public virtual Paciente? IdPacienteNavigation { get; set; }

    public virtual MotivosCitasMedica? MotivoNavigation { get; set; }
}
