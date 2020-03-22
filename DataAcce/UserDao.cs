using ProyectoFinalVersion1.DataAcce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataAcce
{
    public class UserDao : connexionSql
    {
        public bool LoginUsu(string cedula)
        {
            using (var conecion = GetConnecionSql())
            {
                conecion.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = conecion;
                    command.CommandText = "Select * from Ciudadanos where Cedula = @cedula";
                    command.Parameters.AddWithValue("@cedula", cedula);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    command.Parameters.Clear();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }


        public bool LoginAdmin(string user, string pass)
        {
            using (var conecion = GetConnecionSql())
            {
                conecion.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = conecion;
                    command.CommandText = "Select * from administrador where Usuario=@user and Password=@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    command.Parameters.Clear();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }
    }
}
