using DispenarioMedBCK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DispenarioMedBCK.Repositorio.RepositorioAgenda;

namespace DispenarioMedBCK.Repositorio
{
    public interface IRepositorioAgenda
    {
        Task<List<HorarioCitaDTO>> ObtenerDisponible(string sector, string especialidad);
        public Task<HorarioCitaDTO2> ObtenerHorarioPorIdAsync(int idHorario);

    }
}
