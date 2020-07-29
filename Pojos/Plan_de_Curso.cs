using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCursos.Pojos
{
   public  class Plan_de_Curso
    {
        private String Actividades;
        private String Descripcion;
        private String Periodo;
        private String Temas;
        private String id;

        public Plan_de_Curso(string actividades, string descripcion, string periodo, string temas, string id)
        {
            this.Actividades = actividades;
            this.Descripcion = descripcion;
            this.Periodo = periodo;
            this.Temas = temas;
            this.Id = id;
        }
        public Plan_de_Curso() { }

        public String actividades { get => Actividades; set => Actividades = value; }
        public String descripcion { get => Descripcion; set => Descripcion = value; }
        public String periodo { get => Periodo; set => Periodo = value; }
        public String temas { get => Temas; set => Temas = value; }
        public String Id { get => id; set => id = value; }
    }
}
