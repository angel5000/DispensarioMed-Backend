﻿using DispenarioMedBCK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DispenarioMedBCK.Repositorio.RepositorioRegistrar;

namespace DispenarioMedBCK.Repositorio
{
  public interface IRepositorioRegistrar
    {
        public Task<bool> RegistrarPaciente(Paciente usuarioDto);
        public Task<bool> RegistrarUsuariocContra(UsuarioPacienteDto userDto);
    }
}
