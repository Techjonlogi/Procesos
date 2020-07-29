using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCursos.Pojos;
using static ProyectoCursos.Logica.AddEnum;
using ProyectoCursos.Daos;

namespace ProyectoCursos.Controllers
{
    class MaestroController
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


        public AddResult AñadirMaestro(String años,String materno,String paterno, string  correo, string curp, string nacimiento, String genero, String id, String nombre, String perfil, String rfc)
        {
            DocenteDao DAO = new DocenteDao();
            String tipo = "Maestro";
            Empleado curso = new Empleado(años, materno, paterno,  correo,  curp,  nacimiento,  genero,  id,  nombre,  perfil, rfc,  tipo);


            if (DAO.AddDirectivo(curso) == AddResult.Success)
            {
                return AddResult.Success;
            }
            return AddResult.UnknowFail;

        }






        public List<Empleado> GetMensajeid(String receptor)
        {
            EmpleadoDao mensaje = new EmpleadoDao();
            List<Empleado> list = mensaje.GetMensajesbyReceptor(receptor);
            return list;
        }



        public List<Docente> GetProfesor()
        {
            DocenteDao dao = new DocenteDao();
            List<Docente> list = dao.GetDirectivo();
            return list;
        }

        public OperationResult DeleteProfesor(String Matricula)
        {
            EmpleadoDao dao = new EmpleadoDao();
            return (OperationResult)dao.DeleteEmpleadoByID(Matricula);
        }



    }
}
