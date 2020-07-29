using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCursos.Pojos;
using ProyectoCursos.Logica;
using static ProyectoCursos.Logica.AddEnum;
using System.Data.SqlClient;
using ProyectoCursos.Conection;

namespace ProyectoCursos.Daos
{
    public class RegistroDao:IRegistroDao
    {

        private AddResult CheckObjectRegistro(Registro administrador)
        {
            CheckFields validarCampos = new CheckFields();
            AddResult result = AddResult.UnknowFail;
            if (administrador.reporte == String.Empty ||
                administrador.Id == String.Empty
               )
            {
                throw new FormatException("Existen campos vacíos ");
            }
            
            else
            {
                result = AddResult.Success;
            }
            return result;
        }


        public AddResult Addregistro(Registro registro) {

            AddResult resultado = AddResult.UnknowFail;
            Conection.Conection dbConnection = new Conection.Conection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjectRegistro(registro);
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
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Registro VALUES(@ID, @Nombres)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@ID", registro.Id));
                    command.Parameters.Add(new SqlParameter("@Nombres", registro.reporte));
                   
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
        public List<Registro> Getregistro() {
            List<Registro> listaAdministrador = new List<Registro>();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Registro", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Registro administrador = new Registro();

                        administrador.Id = reader["idRegistro"].ToString();
                        administrador.reporte = reader["Reporte"].ToString();
                        administrador.Curso = reader["Curso"].ToString();

                        listaAdministrador.Add(administrador);
                    }
                }
                connection.Close();
            }
            return listaAdministrador;


        }
        public Registro GetregistroID(String idToSearch) {

            Registro administrador = new Registro();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Registro WHERE idRegistro = @idToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("idToSearch", idToSearch));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        administrador.Id = reader["idRegistro"].ToString();
                        administrador.reporte = reader["Reporte"].ToString();
                        
                    }
                }
                connection.Close();
            }
            return administrador;


        }
        




    }
}
