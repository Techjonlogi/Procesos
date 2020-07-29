using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCursos.Pojos
{
    public class Curso
    {
        private String cupo;
        private String nrc;
        private String nombre;
        private String periodo;
        private String seccion;

        public Curso(string cupo, string nrc, string nombre, string periodo, String seccion)
        {
            this.cupo = cupo;
            this.nrc = nrc;
            this.nombre = nombre;
            this.periodo = periodo;
            this.seccion = seccion;
        }


        public Curso() { }
        public String  Cupo { get => cupo; set => cupo = value; }
        public String NRC { get =>nrc ; set => nrc = value; }
        public String Nombre{ get =>nombre; set => nombre = value; }
        public String Periodo { get =>periodo; set => periodo = value; }
        public String Seccion { get => seccion; set => seccion = value; }
    }
}
