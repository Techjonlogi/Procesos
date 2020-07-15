using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCursos.Pojos
{
    public class Docente : Empleado
    {
        private int añosdandoClases;

        public int AñosDandoClases{ get => añosdandoClases; set => AñosDandoClases = value; }
    
    }
}
