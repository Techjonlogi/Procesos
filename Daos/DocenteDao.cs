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
    public class DocenteDao
    {

        private AddResult CheckObjecDocente(Empleado administrador)
        {
            CheckFields validarCampos = new CheckFields();
            AddResult result = AddResult.UnknowFail;
            if (
                administrador.AñosDeExperiencia == String.Empty ||
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










        public List<Docente> GetDirectivo()
        {

            List<Docente> listaDocente = new List<Docente>();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Empleado WHERE Tipo='Maestro'", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Docente directivo = new Docente();

                        directivo.AñosDeExperiencia = reader["AñosExperiencia"].ToString();
                        directivo.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                        directivo.ApellidoMaterno = reader["ApellidoMAterno"].ToString();
                        directivo.Correo = reader["Correo"].ToString();
                        directivo.Curp = reader["Curp"].ToString();
                        directivo.FechadeNacimiento = reader["FechaNacimiento"].ToString();
                        directivo.Genero = reader["Genero"].ToString();
                        directivo.IdEmpleado = reader["ID"].ToString();
                        directivo.Nombre = reader["Nombre"].ToString();
                        directivo.PerfilProfecional = reader["PerfilProfesional"].ToString();
                        directivo.Rfc = reader["RFC"].ToString();


                        listaDocente.Add(directivo);
                    }
                }
                connection.Close();
            }
            return listaDocente;

        }


        public Docente GetDirectivoID(String idToSearch)
        {
            Docente directivo = new Docente();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Empleado WHERE ID = @idToSearch AND Tipo='Maestro'", connection))
                {
                    command.Parameters.Add(new SqlParameter("idToSearch", idToSearch));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        directivo.AñosDeExperiencia = reader["AñosExperiencia"].ToString();
                        directivo.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                        directivo.ApellidoMaterno = reader["ApellidoMAterno"].ToString();
                        directivo.Correo = reader["Correo"].ToString();
                        directivo.Curp = reader["Curp"].ToString();
                        directivo.FechadeNacimiento = reader["FechaNacimiento"].ToString();
                        directivo.Genero = reader["Genero"].ToString();
                        directivo.IdEmpleado = reader["ID"].ToString();
                        directivo.Nombre = reader["Nombre"].ToString();
                        directivo.PerfilProfecional = reader["PerfilProfesional"].ToString();
                        directivo.Rfc = reader["RFC"].ToString();
                        
                    }
                }
                connection.Close();
            }
            return directivo;



        }

        public AddResult AddDirectivo(Empleado directivo)
        {


            AddResult resultado = AddResult.UnknowFail;
            Conection.Conection dbConnection = new Conection.Conection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjecDocente(directivo);
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
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Empleado VALUES(@años, @paterno, @materno, @correo, @curp, @fechanac,@genero,@id,@nombre,@perfil,@rfc,@tipo)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@años", directivo.AñosDeExperiencia));
                    command.Parameters.Add(new SqlParameter("@paterno", directivo.ApellidoPaterno));
                    command.Parameters.Add(new SqlParameter("@materno", directivo.ApellidoMaterno));
                    command.Parameters.Add(new SqlParameter("@correo", directivo.Correo));
                    command.Parameters.Add(new SqlParameter("@curp", directivo.Curp));
                    command.Parameters.Add(new SqlParameter("@genero", directivo.Genero));
                    command.Parameters.Add(new SqlParameter("@id", directivo.IdEmpleado));
                    command.Parameters.Add(new SqlParameter("@nombre", directivo.Nombre));
                    command.Parameters.Add(new SqlParameter("@perfil", directivo.PerfilProfecional));
                    command.Parameters.Add(new SqlParameter("@rfc", directivo.Rfc));
                    command.Parameters.Add(new SqlParameter("@tipo",directivo.Tipo ));
                    command.Parameters.Add(new SqlParameter("@fechanac", directivo.FechadeNacimiento));


                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
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
