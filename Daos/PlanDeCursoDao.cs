using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ProyectoCursos.Pojos;
using static ProyectoCursos.Logica.AddEnum;
using ProyectoCursos.Logica;
using System.Threading.Tasks;

namespace ProyectoCursos.Daos
{
    class PlanDeCursoDao:IplandeCurso
    {


        private AddResult CheckObjectPlan(Plan_de_Curso administrador)
        {
            CheckFields validarCampos = new CheckFields();
            AddResult result = AddResult.UnknowFail;
            if (administrador.actividades == String.Empty ||
                administrador.descripcion == String.Empty ||
                administrador.periodo == String.Empty ||
                administrador.temas == String.Empty)
            {
                throw new FormatException("Existen campos vacíos ");
            }
            else
            {
                result = AddResult.Success;
            }
            return result;
        }


        public List<Plan_de_Curso> GetPlan() {
            List<Plan_de_Curso> listaPlan = new List<Plan_de_Curso>();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.PlandeCurso", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Plan_de_Curso administrador = new Plan_de_Curso();

                        administrador.actividades = reader["Actividades"].ToString();
                        administrador.descripcion = reader["Descripcion"].ToString();
                        administrador.periodo = reader["Periodo"].ToString();
                        administrador.temas = reader["Temas"].ToString();
                        administrador.Id = reader["idPlanCurso"].ToString();
                        listaPlan.Add(administrador);
                    }
                }
                connection.Close();
            }
            return listaPlan;


        }






        public Plan_de_Curso GetPlanID(String idToSearch) {
            Plan_de_Curso administrador = new Plan_de_Curso();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.PlandeCurso WHERE idPlanCurso = @idToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("idToSearch", idToSearch));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        administrador.actividades = reader["Actividades"].ToString();
                        administrador.descripcion = reader["Descripcion"].ToString();
                        administrador.periodo = reader["Periodo"].ToString();
                        administrador.temas = reader["Temas"].ToString();
                        administrador.Id = reader["idPlanCurso"].ToString();
                    }
                }
                connection.Close();
            }
            return administrador;

        }

        
        public AddResult AddPlan(Plan_de_Curso plan) {
            AddResult resultado = AddResult.UnknowFail;
            Conection.Conection dbConnection = new Conection.Conection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjectPlan(plan);
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
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.PlandeCurso VALUES(@ID, @Nombres, @ApellidoPaterno, @ApellidoMaterno, @Usuario)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@ID", plan.actividades));
                    command.Parameters.Add(new SqlParameter("@Nombres", plan.descripcion));
                    command.Parameters.Add(new SqlParameter("@ApellidoPaterno", plan.periodo));
                    command.Parameters.Add(new SqlParameter("@ApellidoMaterno", plan.temas));
                    command.Parameters.Add(new SqlParameter("@Usuario", plan.Id));
                    
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
