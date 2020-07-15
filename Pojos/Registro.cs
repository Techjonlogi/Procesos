using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCursos.Pojos
{
   public class Registro
    {
        private String id;
        private String Reporte;
        
        public String reporte { get => Reporte; set => reporte= value; }
        public String Id { get => id; set => id = value; }
    }
}
