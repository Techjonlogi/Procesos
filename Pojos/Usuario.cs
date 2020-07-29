using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCursos.Pojos
{
   public class Usuario
    {
        
        public String UserType { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }




        public Usuario(string UserName, string Password, string UserType)
        {
            this.UserName = UserName;
            this.Password = Password;
            this.UserType = UserType;
           
        }

        public Usuario()
        {

        }



    }
}
