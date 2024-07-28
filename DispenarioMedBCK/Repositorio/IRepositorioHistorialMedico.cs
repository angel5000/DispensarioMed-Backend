using DispenarioMedBCK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DispenarioMedBCK.Repositorio.RepositorioAgenda;
using static DispenarioMedBCK.Repositorio.RepositorioHistorialMedico;

namespace DispenarioMedBCK.Repositorio
{
    public interface IRepositorioHistorialMedico
    {
        Task<List<HistorialMedic>> HistorialMed(int id);
    }
}
