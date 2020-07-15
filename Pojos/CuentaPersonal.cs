using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCursos.Pojos
{
    public class CuentaPersonal
    {
        private String Contraseña;
        private String Usuario;
        private String tipo;

        public String Tipo { get => tipo; set => tipo = value; }
        public String CuentaContraseña { get => Contraseña; set => CuentaContraseña = value; }
        public String CuentaUsuario { get => Usuario; set => CuentaUsuario = value; }
    }
}
