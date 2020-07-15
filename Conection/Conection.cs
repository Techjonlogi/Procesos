using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProyectoCursos.Conection
{
    public class Conection
    {
        private SqlConnection connection;
        private string connectionString;



        public Conection() {
            connectionString = "Server=localhost;Database=Cursos;Integrated Security=true";
            connection = new SqlConnection(connectionString);



        }


        public SqlConnection GetConnection()
        {
            return connection;
        }

        public void CloseConnection()
        {
            if (connection != null)
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }



}

