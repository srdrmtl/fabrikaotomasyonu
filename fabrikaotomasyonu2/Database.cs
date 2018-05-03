using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace fabrikaotomasyonu2
{
    class Database
    {

        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=SERDAR;Initial Catalog=fabrika;Integrated Security=True";
            return new SqlConnection(connectionString);
        }
    }
}
