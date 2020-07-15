using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCursos.Pojos;
using static ProyectoCursos.Logica.AddEnum;
using ProyectoCursos.Logica;

namespace ProyectoCursos.Daos
{
    interface IRegistroDao
    {
        List<Registro> Getregistro();
        Registro GetregistroID(String idToSearch);
        AddResult Addregistro(Registro instanceActividad);

    }
}
