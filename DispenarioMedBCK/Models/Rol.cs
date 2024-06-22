using System;
using System.Collections.Generic;

namespace DispenarioMedBCK.Models;

public partial class Rol
{
    public int Idrol { get; set; }

    public string? Rol1 { get; set; }

    public virtual ICollection<UsuariosMedico> UsuariosMedicos { get; set; } = new List<UsuariosMedico>();

    public virtual ICollection<UsuariosPaciente> UsuariosPacientes { get; set; } = new List<UsuariosPaciente>();
}
