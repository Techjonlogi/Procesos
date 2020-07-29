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
        private String curso;
        
        public String reporte { get => Reporte; set => reporte= value; }
        public String Id { get => id; set => id = value; }
        public String Curso { get => curso; set => curso = value; }
    }
}
