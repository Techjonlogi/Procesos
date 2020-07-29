using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCursos.Logica;
using static ProyectoCursos.Logica.AddEnum;
using ProyectoCursos.Pojos;
using System.Data.SqlClient;

namespace ProyectoCursos.Daos
{
   public  class UsuarioDao : IUsuarioDao
    {


        public AddResult doLoging(String username, String password)
        {

            AddResult resultado = AddResult.UnknowFail;
           Conection.Conection dbConnection = new Conection.Conection();
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException)
                {
                    resultado = AddResult.SQLFail;
                    return resultado;
                }

                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Usuarios WHERE UserName = @usuario AND Contraseña = @contraseña", connection))
                {
                    command.Parameters.Add(new SqlParameter("@usuario", username));
                    command.Parameters.Add(new SqlParameter("@contraseña", password));

                    try
                    {

                        SqlDataReader reader = command.ExecuteReader();
                        Usuario usuario = new Usuario();
                        while (reader.Read())
                        {

                            usuario.Password = reader["Contraseña"].ToString();
                            usuario.UserName = reader["UserName"].ToString();
                            resultado = AddResult.Success;
                            Properties.Settings.Default.tipoUsuario = reader["Tipo"].ToString();
                        }

                        if (usuario.UserName == null)
                        {
                            resultado = AddResult.InvalidOrganization;

                        }

                    }
                    catch (SqlException)
                    {

                        resultado = AddResult.NullObject;

                    }
                    catch (Exception e)
                    {

                        resultado = AddResult.SQLFail;
                    }


                }
                connection.Close();
            }
            return resultado;


        }


        public AddResult AddUsuario(Usuario usuario)
        {
            AddResult resultado = AddResult.UnknowFail;
            Conection.Conection dbConnection = new Conection.Conection();
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException)
                {
                    resultado = AddResult.SQLFail;
                    return resultado;
                }

                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Usuarios VALUES(@UserName,@Contraseña,@Tipo)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@UserName", usuario.UserName));
                    command.Parameters.Add(new SqlParameter("@Contraseña", usuario.Password));
                    command.Parameters.Add(new SqlParameter("@Tipo", usuario.UserType));
                    
                    
                    try
                    {
                        command.ExecuteNonQuery();



                    }
                    catch (Exception e)
                    {

                        resultado = AddResult.SQLFail;
                    }




                    resultado = AddResult.Success;
                }
                connection.Close();
            }
            return resultado;
        }











    }
}
