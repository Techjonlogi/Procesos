﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProyectoCursos.Pojos;
using static ProyectoCursos.Logica.AddEnum;
using ProyectoCursos.Logica;

namespace ProyectoCursos.Daos
{
    class EmpleadoDao:IEmplado
    {
        private AddResult CheckObjecDocente(Empleado administrador)
        {
            CheckFields validarCampos = new CheckFields();
            AddResult result = AddResult.UnknowFail;
            if (
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










        public List<Empleado> GetEmpleado()
        {

            List<Empleado> listaDocente = new List<Empleado>();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Empleado INNER JOIN  dbo.Docente ON dbo.Empleado.ID=dbo.Docente.ID", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Docente docente = new Docente();

                        docente.añosDeExperiencia = reader["AñosExperiencia"].ToString();
                        docente.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                        docente.ApellidoMaterno = reader["ApellidoMAterno"].ToString();
                        docente.Correo = reader["Correo"].ToString();
                        docente.Curp = reader["FechaNacimimiento"].ToString();
                        docente.genero = reader["Genero"].ToString();
                        docente.idEmpleado = reader["ID"].ToString();
                        docente.nombre = reader["Nombre"].ToString();
                        docente.PerfilProfecional = reader["PerfilProfesional"].ToString();
                        docente.rfc = reader["RFC"].ToString();


                        listaDocente.Add(docente);
                    }
                }
                connection.Close();
            }
            return listaDocente;

        }


        public Empleado GetEmpleadoID(String idToSearch)
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

                    }
                }
                connection.Close();
            }
            return directivo;



        }

        public AddResult AddEmpleado(Empleado directivo)
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
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Empleado VALUES(@años, @paterno, @materno, @correo, @curp, @genero, @id, @nombre, @perfil, @rfc, null)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@años", directivo.añosDeExperiencia));
                    command.Parameters.Add(new SqlParameter("@paterno", directivo.ApellidoPaterno));
                    command.Parameters.Add(new SqlParameter("@materno", directivo.ApellidoMaterno));
                    command.Parameters.Add(new SqlParameter("@correo", directivo.Correo));
                    command.Parameters.Add(new SqlParameter("@curp", directivo.Curp));
                    command.Parameters.Add(new SqlParameter("@genero", directivo.genero));
                    command.Parameters.Add(new SqlParameter("@id", directivo.idEmpleado));
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

        public AddResult DeleteEmpleadoByID(String toSearchInBD)
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
                using (SqlCommand command = new SqlCommand("DELETE FROM dbo.Empleado WHERE ID = @NumdePersonalToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("NumdePersonalToSearch", toSearchInBD));
                    command.ExecuteNonQuery();
                    result = AddResult.Success;
                }
                connection.Close();
            }
            return result;
        }


        public List<Empleado> GetMensajesbyReceptor(String toSearchInBD)
        {
            List<Empleado> listaMensaje = new List<Empleado>();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Empleado WHERE ID = @receptorParaBuscar", connection))
                {
                    command.Parameters.Add(new SqlParameter("receptorParaBuscar", toSearchInBD));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Empleado directivo = new Empleado();

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
                        listaMensaje.Add(directivo);


                    }
                }
                connection.Close();
            }
            return listaMensaje;
        }



    }
}
