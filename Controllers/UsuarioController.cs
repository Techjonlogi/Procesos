using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCursos.Daos;
using ProyectoCursos.Logica;
using static ProyectoCursos.Logica.AddEnum;

namespace ProyectoCursos.Controllers
{
    public class UsuarioController
    {

        public AddResult doLoging(String username, String password)
        {
            UsuarioDao dao = new UsuarioDao();
            AddResult resultado = new AddResult();
            resultado = dao.doLoging(username, password);

            return resultado;




        }



    }
}
