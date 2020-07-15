using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCursos.Pojos;
using static ProyectoCursos.Logica.AddEnum;

namespace ProyectoCursos.Daos
{
    interface IDocenteDao
    {
        List<Docente> GetDocente();
        Curso GetDocenteid(String idTosearch);
        AddResult AddDocente(Docente docente);
    }
}
