using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCursos.Pojos;
using ProyectoCursos.Daos;

namespace ProyectoCursos.Controllers
{
    class RegistroController
    {




        public List<Registro> GetReporte()
        {
            RegistroDao dao = new RegistroDao();
            List<Registro> list = dao.Getregistro();
            return list;
        }










    }

}
