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
        private String NRC;
        private String Nombre;
        private String Periodo;

        public Curso(string cupo, string nrc, string nombre, string periodo)
        {
            this.cupo = cupo;
            this.nrc = nrc;
            this.nombre = nombre;
            this.periodo = periodo;
        }


        public Curso() { }
        public String  Cupo { get => cupo; set => Cupo = value; }
        public String nrc { get => NRC; set => NRC = value; }
        public String nombre{ get =>Nombre; set => nombre = value; }
        public String periodo { get =>Periodo; set => periodo = value; }
    }
}
