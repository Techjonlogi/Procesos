using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCursos.Daos;
using ProyectoCursos.Pojos;
using static ProyectoCursos.Logica.AddEnum;
using ProyectoCursos.Logica;

namespace ProyectoCursos.Controllers
{
    public class ControllerCurso
    {


        public enum OperationResult
        {
            Success,
            NullCoordinador,
            InvaliCoordinador,
            UnknowFail,
            SQLFail,
            ExistingRecord

        }


        public AddResult AñadirCurso(String cupo, String nrc, String nombre, String periodo)
        {
            CursoDao DAO = new CursoDao();
            

            Curso curso = new Curso(cupo, nrc,nombre,periodo);
           
           
            if (DAO.AddCurso(curso) == AddResult.Success)
            {
                return AddResult.Success;
            }
            return AddResult.UnknowFail;

        }










        public List<Curso> Getcurso()
        {
            CursoDao dao = new CursoDao();
            List<Curso> list = dao.GetCursos();
            return list;
        }

        public OperationResult DeleteCurso(String Matricula)
        {
            CursoDao dao = new CursoDao();
            return (OperationResult)dao.DeleteCursoByID(Matricula);
        }

    }
}
