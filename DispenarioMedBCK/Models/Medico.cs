using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DispenarioMedBCK.Models;

public partial class Medico
{
    public int IdMedico { get; set; }

    public string? CodigoMedico { get; set; }

    public string? Cedula { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? Especialidad { get; set; }

    public string? Telefono { get; set; }

    public string? NumCelular { get; set; }

    public string? DireccionDomicilio { get; set; }

    public int? UbicacionDisp { get; set; }

    public string? Genero { get; set; }

    public string? CorreoElectronico { get; set; }

    public int? Especialidadid { get; set; }
    [JsonIgnore]
    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();
    [JsonIgnore]
    public virtual ICollection<CitasMedica> CitasMedicas { get; set; } = new List<CitasMedica>();
    [JsonIgnore]
    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    [JsonIgnore]
    public virtual ICollection<HistorialMedico> HistorialMedicos { get; set; } = new List<HistorialMedico>();
    [JsonIgnore]
    public virtual ICollection<HorariosCita> HorariosCita { get; set; } = new List<HorariosCita>();
    [JsonIgnore]
    public virtual Ubicacion? UbicacionDispNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<UsuariosMedico> UsuariosMedicos { get; set; } = new List<UsuariosMedico>();
    [JsonIgnore]
    public virtual ICollection<UsuariosinactivosHistorial> UsuariosinactivosHistorials { get; set; } = new List<UsuariosinactivosHistorial>();
}
