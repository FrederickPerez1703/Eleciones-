using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalVersion1.DataAcce
{
 
    public abstract class connexionSql
    {
        private readonly string ConnecionString;

        public connexionSql()
        {
            ConnecionString = "Data Source=.;Initial Catalog=Final_Eleccion;Integrated Security=True";
        }
        protected SqlConnection GetConnecionSql()
        {
            return new SqlConnection(ConnecionString);
        }

    }
}
