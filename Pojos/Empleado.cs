using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCursos.Pojos
{
    public class Empleado
    {
        protected string añosdeexperiencia;
        protected String apellidoMaterno;
        protected String apellidoPaterno;
        protected String correo;
        protected String curp;
        protected DateTime fechaDeNacimiento;
        protected String Genero;
        protected String ID;
        protected String Nombre;
        protected String perfilProfecional;
        protected String RFC;
        private string años;
        private string materno;
        private string paterno;
        private string fechaNacimiento;
        private string perfil;

        public Empleado(string años, string materno, string paterno, string correo, string curp, string fechaNacimiento, string genero, string id, string nombre, string perfil, string rfc)
        {
            this.años = años;
            this.materno = materno;
            this.paterno = paterno;
            this.correo = correo;
            this.curp = curp;
            this.fechaNacimiento = fechaNacimiento;
            this.genero = genero;
            ID = id;
            this.nombre = nombre;
            this.perfil = perfil;
            this.rfc = rfc;
        }

        public Empleado() { }
        public string añosDeExperiencia{ get => añosdeexperiencia; set => añosDeExperiencia = value; }
        public String ApellidoMaterno { get => apellidoMaterno; set => ApellidoMaterno = value; }
        public String ApellidoPaterno { get => apellidoPaterno; set => ApellidoPaterno = value; }
        public String Correo { get => correo; set => Correo = value; }
        public String Curp { get => curp; set => Curp = value; }
        public DateTime FechadeNacimiento { get => fechaDeNacimiento; set => FechadeNacimiento = value; }
        public String genero { get => Genero; set => genero = value; }
        public String idEmpleado { get => ID; set => idEmpleado = value; }
        public String nombre { get => Nombre; set => nombre = value; }
        public String PerfilProfecional { get => perfilProfecional; set => PerfilProfecional = value; }
        public String rfc { get => RFC; set => rfc = value; }
    }
}
