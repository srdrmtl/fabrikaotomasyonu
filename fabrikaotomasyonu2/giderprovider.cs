using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace fabrikaotomasyonu2
{
    class giderprovider
    {



        public DataTable getgider()
        {
            DataTable dt = null;
            using (var conn = Database.GetConnection())
            {
                var command = new SqlCommand("Select * from gelir_gider");
                command.Connection = conn;
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                dt = new DataTable();
                da.Fill(dt);
                conn.Close();
            }
            return dt;
        }


    }
}
