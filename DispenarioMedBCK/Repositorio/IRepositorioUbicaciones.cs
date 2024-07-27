﻿using DispenarioMedBCK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispenarioMedBCK.Repositorio
{
    public interface IRepositorioUbicaciones
    {
        Task<List<string>> ObtenerTodos();
    }
}