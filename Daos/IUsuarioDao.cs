using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCursos.Logica;
using static ProyectoCursos.Logica.AddEnum;
using ProyectoCursos.Pojos;

namespace ProyectoCursos.Daos
{
    public interface IUsuarioDao
    {

        AddResult AddUsuario(Usuario usuario);
    }
}
