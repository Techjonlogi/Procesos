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
        protected String fechaDeNacimiento;
        protected String genero;
        protected String iD;
        protected String nombre;
        protected String perfilProfecional;
        protected String rfc;
        protected String tipo;

        public Empleado(string años, string materno, string paterno, string correo, string curp, string nacimiento, string genero, string id, string nombre, string perfil, string rfc,string tipo)
        {
            this.añosdeexperiencia = años;
            this.apellidoMaterno = materno;
            this.apellidoPaterno = paterno;
            this.correo = correo;
            this.curp = curp;
            this.fechaDeNacimiento = nacimiento;
            this.genero = genero;
            this.iD = id;
            this.nombre = nombre;
            this.perfilProfecional = perfil;
            this.rfc = rfc;
            this.tipo = tipo;
       
        }

        public Empleado() { }
        public string AñosDeExperiencia{ get => añosdeexperiencia; set => añosdeexperiencia = value; }
        public String ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
        public String ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        public String Correo { get => correo; set => correo = value; }
        public String Curp { get => curp; set => curp = value; }
        public String FechadeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public String Genero { get => genero; set => genero = value; }
        public String IdEmpleado { get => iD; set => iD = value; }
        public String Nombre { get => nombre; set => nombre = value; }
        public String PerfilProfecional { get => perfilProfecional; set => perfilProfecional = value; }
        public String Rfc { get => rfc; set => rfc = value; }
        public String Tipo { get => tipo; set => tipo = value; }
    }
}
