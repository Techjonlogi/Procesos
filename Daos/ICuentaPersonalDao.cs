using ProyectoCursos.Pojos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoCursos.Logica.AddEnum;

namespace ProyectoCursos.Daos
{
    public interface ICuentaPersonalDao
    {
        CuentaPersonal GetCuentaPersonal(String idToSearch);
        AddResult AddCuenta(CuentaPersonal cuenta);


    }
}
