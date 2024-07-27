using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DispenarioMedBCK.Models;

public partial class Especialidad
{
    public int Idespecialidad { get; set; }

    public string? Especialidad1 { get; set; }
    [JsonIgnore]
    public virtual ICollection<MotivosCitasMedica> MotivosCitasMedicas { get; set; } = new List<MotivosCitasMedica>();
}
