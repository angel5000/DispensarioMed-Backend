using DispenarioMedBCK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace DispenarioMedBCK.Repositorio
{
    public class RepositorioEspecialidad:IRepositorioEspecialidad
    {
        private readonly DispensarioMedContext context;
        public RepositorioEspecialidad(DispensarioMedContext context)
        {
            this.context = context;
        }
        public async Task<List<Especialidad>> ObtenerTodos()
        {
            return await context.Especialidads.ToListAsync();
        }

    }
}
