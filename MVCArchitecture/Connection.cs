using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MVCArchitecture
{
    public class Connection
    {
        private static string _connectionString = "Data Source=LAPTOP-6G2JJTAJ;" +
            "Database=db_datakaryawan;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;";

        private static SqlConnection _connection;

        public static SqlConnection Get()
        {
            try
            {
                _connection = new SqlConnection(_connectionString);
                return _connection;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
