using System;
using System.Collections.Generic;

namespace DispenarioMedBCK.Models;

public partial class MotivosCitasMedica
{
    public int Idmotivo { get; set; }

    public string? Servicio { get; set; }

    public int? EspecialiMed { get; set; }

    public virtual ICollection<CitasMedica> CitasMedicas { get; set; } = new List<CitasMedica>();

    public virtual ICollection<CostoServicio> CostoServicios { get; set; } = new List<CostoServicio>();

    public virtual Especialidad? EspecialiMedNavigation { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
