using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCursos.Logica;
using static ProyectoCursos.Logica.AddEnum;
using static ProyectoCursos.Logica.CheckFields;
using ProyectoCursos.Pojos;
using ProyectoCursos.Conection;
using System.Data.SqlClient;

namespace ProyectoCursos.Daos
{
    class AdministradorDao : IAdministrador
    {
        private AddResult CheckObjectAdministrador(Administrador administrador)
        {
            CheckFields iCheckFields = new CheckFields();
            AddResult addResult = AddResult.UnknowFail;

            if (administrador.IdAdministrador == String.Empty )
            {
                throw new FormatException("Existen campos vacíos ");
            }
            if (iCheckFields.ValidarNumeropersonal(administrador.IdAdministrador) == CheckFields.ResultadosValidación.NúmeroInválido)
            {
                throw new FormatException("Nombre inválido " + administrador.IdAdministrador);
            }
            else
            {
                addResult = AddResult.Success;
            }
            return addResult;
        }


        public List<Administrador> GetAdministradores()
        {

            List<Administrador> ListaAdministrador = new List<Administrador>();
            Conection.Conection connection = new Conection.Conection();
            using (SqlConnection SqlConnection = connection.GetConnection())
            {
                try
                {
                   SqlConnection.Open();
                }
                catch (SqlException ex)
                {
                    throw (ex);
                }
                using (SqlCommand instanceSqlCommand = new SqlCommand("SELECT * FROM dbo.Administrador", SqlConnection))
                {
                    SqlDataReader reader = instanceSqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Administrador administrador = new Administrador();

                        administrador.Nombre = reader["Nombre"].ToString();
                        administrador.IdAdministrador = reader["Id"].ToString();
                        

                        ListaAdministrador.Add(administrador);
                    }
                }
                SqlConnection.Close();
            }
            return ListaAdministrador;
        }

        public Administrador GetAdministradorID(String id)
        {

            Administrador administrador = new Administrador();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Administrador WHERE idAdministrador = @idToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("idToSearch", id));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        administrador.IdAdministrador = reader["nombresAdministrador"].ToString();
                        
                       
                    }
                }
                connection.Close();
            }
            return administrador;
        }


        public AddResult AddAdministrador(Administrador administrador) {
            AddResult resultado = AddResult.UnknowFail;
            Conection.Conection dbConnection = new Conection.Conection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjectAdministrador(administrador);
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
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Administrador VALUES(@ID)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@ID", administrador.IdAdministrador));
                    ;
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
