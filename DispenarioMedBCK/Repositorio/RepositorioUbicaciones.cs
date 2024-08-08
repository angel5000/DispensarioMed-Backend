using DispenarioMedBCK.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispenarioMedBCK.Repositorio
{
    public class RepositorioUbicaciones : IRepositorioUbicaciones
    {
        private readonly DispensarioMedContext context;
        public RepositorioUbicaciones(DispensarioMedContext context)
        {
            this.context = context;
        }
        public async Task<List<string>> ObtenerTodos()
        {
            return await context.Ubicacions
           .Select(x => x.Sector)
           .ToListAsync();
        }
    }
}
