using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCursos.Logica;
using static ProyectoCursos.Logica.AddEnum;
using ProyectoCursos.Pojos;
using ProyectoCursos.Daos;

namespace ProyectoCursos.Controllers
{
    public class ControllerPlan
    {


        public AddResult añadirPlan(String actividades, String descripcion, String periodo, String temas, String id)
        {
            PlanDeCursoDao DAO = new PlanDeCursoDao();


            Plan_de_Curso curso = new Plan_de_Curso(actividades,descripcion,periodo,temas,id);


            if (DAO.AddPlan(curso) == AddResult.Success)
            {
                return AddResult.Success;
            }
            return AddResult.UnknowFail;

        }







    }

}
