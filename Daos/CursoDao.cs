using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCursos.Pojos;
using static ProyectoCursos.Logica.AddEnum;
using ProyectoCursos.Logica;
using System.Data.SqlClient;
using ProyectoCursos.Conection;

namespace ProyectoCursos.Daos
{
    public class CursoDao : ICursoDao
    {
        private AddResult CheckObjectCurso(Curso curso)
        {
            CheckFields validarCampos = new CheckFields();
            AddResult result = AddResult.UnknowFail;
            if (curso.Cupo == String.Empty ||
                curso.NRC== String.Empty ||
                curso.Nombre == String.Empty ||
                curso.Periodo == String.Empty)
            {
                throw new FormatException("Existen campos vacíos ");
            }
            else
            if (validarCampos.ValidarNRC(curso.NRC) == CheckFields.ResultadosValidación.NRCInvalido)
            {
                throw new FormatException("NRC inválido " + curso.NRC);
            }
            else
            {
                result = AddResult.Success;
            }
            return result;
        }



        public List<Curso> GetCursos()
        {

            List<Curso> listaCursos = new List<Curso>();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Curso", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Curso administrador = new Curso();

                        administrador.Cupo = reader["cupo"].ToString();
                        administrador.NRC = reader["NRC"].ToString();
                        administrador.Nombre = reader["Nombre"].ToString();
                        administrador.Periodo = reader["Periodo"].ToString();
                        
                        listaCursos.Add(administrador);
                    }
                }
                connection.Close();
            }
            return listaCursos;
        }




        public Curso GetCursoporNRC(String nrcTosearch) {
            Curso curso = new Curso();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Cursos WHERE NRC = @idToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("idToSearch", nrcTosearch));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        curso.Cupo = reader["cupo"].ToString();
                        curso.NRC = reader["NRC"].ToString();
                        curso.Nombre = reader["Nombre"].ToString();
                        curso.Periodo = reader["Periodo"].ToString();
                       
                    }
                }
                connection.Close();
            }
            return curso;


        }



        public AddResult AddCurso(Curso curso) {
            AddResult resultado = AddResult.UnknowFail;
            Conection.Conection dbConnection = new Conection.Conection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjectCurso(curso);
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
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Curso VALUES(@cupo, @nrc, @nombre, @periodo,@seccion)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@cupo", curso.Cupo));
                    command.Parameters.Add(new SqlParameter("@nrc", curso.NRC));
                    command.Parameters.Add(new SqlParameter("@nombre", curso.Nombre));
                    command.Parameters.Add(new SqlParameter("@periodo", curso.Periodo));
                    command.Parameters.Add(new SqlParameter("@seccion", curso.Seccion));

                    ;
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




        public AddResult DeleteCursoByID(String toSearchInBD)
        {
            AddResult result = AddResult.UnknowFail;
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
                using (SqlCommand command = new SqlCommand("DELETE FROM dbo.Curso WHERE NRC = @NumdePersonalToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("NumdePersonalToSearch", toSearchInBD));
                    command.ExecuteNonQuery();
                    result = AddResult.Success;
                }
                connection.Close();
            }
            return result;
        }






    }
}
