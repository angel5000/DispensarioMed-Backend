using System;
using System.Collections.Generic;

namespace DispenarioMedBCK.Models;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public string Cedula { get; set; } = null!;

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? FechaNacimiento { get; set; }

    public string? Provincia { get; set; }

    public string? Direccion { get; set; }

    public string? NumCelular { get; set; }

    public string? Canton { get; set; }

    public string? Genero { get; set; }

    public string? CorreoElectronico { get; set; }

    public int? Telefonoid { get; set; }

    public virtual ICollection<CitasMedica> CitasMedicas { get; set; } = new List<CitasMedica>();

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<HistorialMedico> HistorialMedicos { get; set; } = new List<HistorialMedico>();

    public virtual ICollection<PagosRealizado> PagosRealizados { get; set; } = new List<PagosRealizado>();

    public virtual ICollection<TelefonosPaciente> TelefonosPacientes { get; set; } = new List<TelefonosPaciente>();

    public virtual ICollection<UsuariosPaciente> UsuariosPacientes { get; set; } = new List<UsuariosPaciente>();

    public virtual ICollection<UsuariosinactivosHistorial> UsuariosinactivosHistorials { get; set; } = new List<UsuariosinactivosHistorial>();
}
