using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DispenarioMedBCK.Models;

public partial class Area
{
    public int IdAreas { get; set; }

    public int IdDoctor { get; set; }

    public string? Habitacion { get; set; }

    public int? Ubicacionarea { get; set; }

    public virtual ICollection<HorariosCita> HorariosCita { get; set; } = new List<HorariosCita>();
    [JsonIgnore]
    public virtual Medico IdDoctorNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Ubicacion? UbicacionareaNavigation { get; set; }
}
