using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCursos.Pojos;
using ProyectoCursos.Logica;
using static ProyectoCursos.Logica.AddEnum;
namespace ProyectoCursos.Daos
{
   public  interface ICursoDao
    {
        List<Curso> GetCursos();
        Curso GetCursoporNRC(String nrcTosearch);
        AddResult AddCurso(Curso curso);


    }
}
