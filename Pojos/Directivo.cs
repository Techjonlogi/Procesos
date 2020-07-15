using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCursos.Pojos
{
    public class Directivo: Empleado
    {
        private String tipo;

        public String Tipo { get => tipo; set => Tipo = value; }
    
    }
}
