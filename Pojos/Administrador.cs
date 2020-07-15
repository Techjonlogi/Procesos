using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;


namespace ProyectoCursos.Pojos
{
    public class Administrador : Empleado
    {
        private String id;

        public String IdAdministrador { get => id; set => IdAdministrador = value; }



    }
}
