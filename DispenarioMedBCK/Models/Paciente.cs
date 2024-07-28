using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
    [JsonIgnore]
    public virtual ICollection<CitasMedica> CitasMedicas { get; set; } = new List<CitasMedica>();
    [JsonIgnore]
    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    [JsonIgnore]
    public virtual ICollection<HistorialMedico> HistorialMedicos { get; set; } = new List<HistorialMedico>();
    [JsonIgnore]
    public virtual ICollection<PagosRealizado> PagosRealizados { get; set; } = new List<PagosRealizado>();
    [JsonIgnore]
    public virtual ICollection<TelefonosPaciente> TelefonosPacientes { get; set; } = new List<TelefonosPaciente>();
    [JsonIgnore]
    public virtual ICollection<UsuariosPaciente> UsuariosPacientes { get; set; } = new List<UsuariosPaciente>();
    [JsonIgnore]
    public virtual ICollection<UsuariosinactivosHistorial> UsuariosinactivosHistorials { get; set; } = new List<UsuariosinactivosHistorial>();
}
