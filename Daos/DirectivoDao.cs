using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCursos.Pojos;
using System.Data.SqlClient;
using static ProyectoCursos.Logica.AddEnum;
using ProyectoCursos.Logica;

namespace ProyectoCursos.Daos
{
    class DirectivoDao:IDirectivoDao
    {


        private AddResult CheckObjecDirectivo(Directivo administrador)
        {
            CheckFields validarCampos = new CheckFields();
            AddResult result = AddResult.UnknowFail;
            if (administrador.Tipo == String.Empty ||
                administrador.añosDeExperiencia == String.Empty ||
                administrador.ApellidoPaterno == String.Empty ||
                administrador.ApellidoMaterno == String.Empty ||
                administrador.Correo == String.Empty)
            {
                throw new FormatException("Existen campos vacíos ");
            }
            
            else
            {
                result = AddResult.Success;
            }
            return result;
        }










        public List<Directivo> GetDirectivo() {

            List<Directivo> listaDirectivo = new List<Directivo>();
            Conection.Conection dbconnection = new Conection.Conection();
            using (SqlConnection connection = dbconnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    throw (ex);
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Empleado INNER JOIN  dbo.Directivo ON dbo.Empleado.ID=dbo.Directivo.ID", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Directivo directivo = new Directivo();

                        directivo.añosDeExperiencia = reader["AñosExperiencia"].ToString();
                        directivo.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                        directivo.ApellidoMaterno = reader["ApellidoMAterno"].ToString();
                        directivo.Correo = reader["Correo"].ToString();
                        directivo.Curp = reader["FechaNacimimiento"].ToString();
                        directivo.genero = reader["Genero"].ToString();
                        directivo.idEmpleado = reader["ID"].ToString();
                        directivo.nombre = reader["Nombre"].ToString();
                        directivo.PerfilProfecional = reader["PerfilProfesional"].ToString();
                        directivo.rfc = reader["RFC"].ToString();
                        directivo.Tipo = reader["Tipo"].ToString();
                        
                        listaDirectivo.Add(directivo);
                    }
                }
                connection.Close();
            }
            return listaDirectivo;

        }


        public Directivo GetDirectivoID(String idToSearch) {
            Directivo directivo = new Directivo();
            Conection.Conection dbconnection = new Conection.Conection();
            using (SqlConnection connection = dbconnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    throw (ex);
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Empleado WHERE ID = @idToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("idToSearch", idToSearch));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        directivo.añosDeExperiencia = reader["AñosExperiencia"].ToString();
                        directivo.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                        directivo.ApellidoMaterno = reader["ApellidoMAterno"].ToString();
                        directivo.Correo = reader["Correo"].ToString();
                        directivo.Curp = reader["FechaNacimimiento"].ToString();
                        directivo.genero = reader["Genero"].ToString();
                        directivo.idEmpleado = reader["ID"].ToString();
                        directivo.nombre = reader["Nombre"].ToString();
                        directivo.PerfilProfecional = reader["PerfilProfesional"].ToString();
                        directivo.rfc = reader["RFC"].ToString();
                        directivo.Tipo = reader["Tipo"].ToString();
                    }
                }
                connection.Close();
            }
            return directivo;



        }

        public AddResult AddDirectivo(Directivo directivo) {


            AddResult resultado = AddResult.UnknowFail;
            Conection.Conection dbConnection = new Conection.Conection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjecDirectivo(directivo);
            }
            catch (ArgumentNullException)
            {
                resultado = AddResult.NullObject;
                return resultado;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Empleado VALUES(@años, @paterno, @materno, @correo, @curp, @genero, @id, @nombre, @perfil, @rfc, null)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@años", directivo.añosDeExperiencia));
                    command.Parameters.Add(new SqlParameter("@paterno", directivo.ApellidoPaterno));
                    command.Parameters.Add(new SqlParameter("@materno", directivo.ApellidoMaterno));
                    command.Parameters.Add(new SqlParameter("@correo", directivo.Correo));
                    command.Parameters.Add(new SqlParameter("@curp", directivo.Curp));
                    command.Parameters.Add(new SqlParameter("@genero", directivo.genero));
                    command.Parameters.Add(new SqlParameter("@id",  directivo.idEmpleado));
                    command.Parameters.Add(new SqlParameter("@nombre", directivo.nombre));
                    command.Parameters.Add(new SqlParameter("@perfil", directivo.PerfilProfecional));
                    command.Parameters.Add(new SqlParameter("@rfc", directivo.rfc));
                    
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        resultado = AddResult.SQLFail;
                        return resultado;
                    }
                    resultado = AddResult.Success;
                }
                connection.Close();
            }
            return resultado;

        }

    }
}
