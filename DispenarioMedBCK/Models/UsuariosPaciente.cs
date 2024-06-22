﻿using System;
using System.Collections.Generic;

namespace DispenarioMedBCK.Models;

public partial class UsuariosPaciente
{
    public int Idusuario { get; set; }

    public int? IdDatosUsuario { get; set; }

    public string? Usuario { get; set; }

    public int? Rol { get; set; }

    public string? Activa { get; set; }

    public byte[] Salt { get; set; } = null!;

    public byte[] HashedContrasena { get; set; } = null!;

    public virtual Paciente? IdDatosUsuarioNavigation { get; set; }

    public virtual Rol? RolNavigation { get; set; }
}