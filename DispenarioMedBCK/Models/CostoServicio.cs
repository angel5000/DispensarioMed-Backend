using System;
using System.Collections.Generic;

namespace DispenarioMedBCK.Models;

public partial class CostoServicio
{
    public int IdcostServi { get; set; }

    public int? Idmcm { get; set; }

    public double? Costos { get; set; }

    public double? Descuentos { get; set; }

    public virtual MotivosCitasMedica? IdmcmNavigation { get; set; }
}
