using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DispenarioMedBCK.Repositorio.RepositorioFacturareg;

namespace DispenarioMedBCK.Repositorio
{
    public interface IRepositorioFacturareg
    {
        public Task<List<Facturasreg>> Facturasregs(int id);
    }
}
