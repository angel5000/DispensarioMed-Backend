using System;
using System.Collections.Generic;

namespace DispenarioMedBCK.Models;

public partial class Estado
{
    public int Id { get; set; }

    public string? Estados { get; set; }

    public virtual ICollection<CitasCanceladasHistorial> CitasCanceladasHistorials { get; set; } = new List<CitasCanceladasHistorial>();

    public virtual ICollection<UsuariosinactivosHistorial> UsuariosinactivosHistorials { get; set; } = new List<UsuariosinactivosHistorial>();
}
