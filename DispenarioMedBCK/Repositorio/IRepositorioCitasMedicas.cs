using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DispenarioMedBCK.Repositorio.RepositorioCitasMedicas;

namespace DispenarioMedBCK.Repositorio
{
   public interface IRepositorioCitasMedicas
    {

        public Task<List<CitasMedicas>> ObtenerCitasMedicas(int id);
        public  Task<bool> ReprogramarCitaAsync(int idPaciente, int idHorario, int idHorarioAnterior);
        public  Task<bool> CancelarCitaMedica(int idPaciente, int idHorario);
    }
}
