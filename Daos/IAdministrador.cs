using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCursos.Pojos;
using static ProyectoCursos.Logica.AddEnum;

namespace ProyectoCursos.Daos
{
    interface IAdministrador
    {
        List<Administrador> GetAdministradores();
        Administrador GetAdministradorID(String idToSearch);
        AddResult AddAdministrador(Administrador administrador);
    }
}
