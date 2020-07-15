using ProyectoCursos.Pojos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCursos.Logica;
using static ProyectoCursos.Logica.AddEnum;
using System.Data.SqlClient;
using ProyectoCursos.Conection;

namespace ProyectoCursos.Daos
{
    public class CuentaPersonalDao : ICuentaPersonalDao
    {
        private AddResult CheckObjectAdministrador(CuentaPersonal cuenta)
        {
            CheckFields validarCampos = new CheckFields();
            AddResult result = AddResult.UnknowFail;
            if (cuenta.CuentaContraseña == String.Empty ||
                cuenta.CuentaUsuario == String.Empty ||
                cuenta.Tipo == String.Empty )
            {
                throw new FormatException("Existen campos vacíos ");
            }
            else
            if (validarCampos.ValidarUsuario(cuenta.CuentaUsuario) == CheckFields.ResultadosValidación.UsuarioInvalido)
            {
                throw new FormatException("Usuario inválido " + cuenta.CuentaUsuario);
            }
            else
                if (validarCampos.ValidarContraseña(cuenta.CuentaContraseña) == CheckFields.ResultadosValidación.ContraseñaInvalida)
            {
                throw new FormatException("Contraseña invalida " + cuenta.CuentaContraseña);
            }
            else
            {
                result = AddResult.Success;
            }
            return result;
        }




        public CuentaPersonal GetCuentaPersonal(String idToSearch) {


            CuentaPersonal cuenta = new CuentaPersonal();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.CuentaPErsonal WHERE Usuario = @idToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("idToSearch", idToSearch));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cuenta.CuentaContraseña = reader["Contraseña"].ToString();
                        cuenta.CuentaUsuario = reader["Usuario"].ToString();
                        cuenta.Tipo = reader["tipo"].ToString();
                        
                        
                    }
                }
                connection.Close();
            }
            return cuenta;





        }


       public  AddResult AddCuenta(CuentaPersonal cuenta) {

            AddResult resultado = AddResult.UnknowFail;
            Conection.Conection dbConnection = new Conection.Conection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjectAdministrador(cuenta);
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
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.CuentaPersonal VALUES(@ID, @Nombres, @ApellidoPaterno)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@contraseña", cuenta.CuentaContraseña));
                    command.Parameters.Add(new SqlParameter("@Nusuario", cuenta.CuentaUsuario));
                    command.Parameters.Add(new SqlParameter("@tipo", cuenta.Tipo));
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
