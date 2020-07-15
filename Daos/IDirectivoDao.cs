using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCursos.Pojos;
using static ProyectoCursos.Logica.AddEnum;

namespace ProyectoCursos.Daos
{
    interface IDirectivoDao
    {

        List<Directivo> GetDirectivo();
        Directivo GetDirectivoID(String idToSearch);
        AddResult AddDirectivo(Directivo directivo);
    }
}
