using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCursos.Pojos;
using static ProyectoCursos.Logica.AddEnum;
namespace ProyectoCursos.Daos
{
    interface IplandeCurso
    {
        List<Plan_de_Curso> GetPlan();
        Plan_de_Curso GetPlanID(String idToSearch);
        AddResult AddPlan(Plan_de_Curso instanceActividad);
    }
}
