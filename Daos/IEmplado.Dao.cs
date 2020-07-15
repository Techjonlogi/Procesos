using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoCursos.Logica.AddEnum;
using ProyectoCursos.Logica;
using ProyectoCursos.Pojos;
namespace ProyectoCursos.Daos
{
    interface IEmplado
    {

        List<Empleado> GetEmpleado();
        Empleado GetEmpleadoID(String idToSearch);
        AddResult AddEmpleado(Empleado  empleado);
    }
}
