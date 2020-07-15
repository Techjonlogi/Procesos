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
            this.actividades = actividades;
            this.descripcion = descripcion;
            this.periodo = periodo;
            this.temas = temas;
            this.id = id;
        }
        public Plan_de_Curso() { }
        public String actividades { get => Actividades; set => actividades = value; }
        public String descripcion { get => Descripcion; set => descripcion = value; }
        public String periodo { get => periodo; set => periodo = value; }
        public String temas { get => Temas; set => temas = value; }
        public String Id { get => id; set => id = value; }
    }
}
