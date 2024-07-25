using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DispenarioMedBCK.Models;

public partial class Ubicacion
{
    public int Idubicacion { get; set; }

    public string? Sector { get; set; }

    public string? Direccion { get; set; }
    [JsonIgnore]
    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();
    [JsonIgnore]
    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}
