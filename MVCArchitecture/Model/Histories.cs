using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Model
{
    public class Histories
    {
        public DateTime StartDate { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? EndDate { get; set; }
        public int DepartmentId { get; set; }
        public int JobId { get; set; }

        public List<Histories> GetAll()
        {
            var connection = Connection.Get();

            var histories = new List<Histories>();

            using SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM Histories";

            try
            {
                connection.Open();
                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Histories history = new Histories();
                        history.StartDate = reader.GetDateTime(0);
                        history.EmployeeId = reader.GetInt32(1);
                        history.EndDate = reader.GetDateTime(2);
                        history.DepartmentId = reader.GetInt32(3);
                        history.JobId = reader.GetInt32(4);

                        histories.Add(history);
                    }
                }
                else
                {
                    reader.Close();
                    connection.Close();
                }

                return histories;
            }
            catch
            {
                return new List<Histories>();
            }
        }

        public int Insert(Histories histories)
        {
            var connection = Connection.Get();

            using SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "INSERT INTO Histories (start_date, employee_id, end_date, department_id, job_id) " +
                "VALUES (@start_date, @employee_id, @end_date, @department_id, @job_id)";

            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            sqlCommand.Parameters.AddWithValue("@StartDate", histories.StartDate);
            sqlCommand.Parameters.AddWithValue("@EmployeeID", histories.EmployeeId);
            sqlCommand.Parameters.AddWithValue("@EndDate", histories.EndDate);
            sqlCommand.Parameters.AddWithValue("@DepartmentID", histories.DepartmentId);
            sqlCommand.Parameters.AddWithValue("@JobID", histories.JobId);

            try
            {             
                int result = sqlCommand.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();

                return result; // 0 gagal, >= 1 berhasil
            }
            catch
            {
                transaction.Rollback();
                return -1; // Kesalahan terjadi pada database
            }
        }

        public int Update(Histories histories)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "UPDATE Histories SET start_date = @start_date, employee_id = employee_id, end_date = end_date, job_id = job_id, department_id = department_id " +
                "WHERE employee_id = @employee_id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            sqlCommand.Parameters.AddWithValue("@StartDate", histories.StartDate);
            sqlCommand.Parameters.AddWithValue("@EmployeeID", histories.EmployeeId);
            sqlCommand.Parameters.AddWithValue("@EndDate", histories.EndDate);
            sqlCommand.Parameters.AddWithValue("@DepartmentID", histories.DepartmentId);
            sqlCommand.Parameters.AddWithValue("@JobID", histories.JobId);

            try
            {              
                int result = sqlCommand.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();

                return result;

            }
            catch
            {
                transaction.Rollback();
                return -1;
            }
        }

        public int Delete(Histories histories)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "DELETE FROM Histories WHERE employee_id = @employee_id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@employee_id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = histories.EmployeeId;
                sqlCommand.Parameters.Add(pId);

                int result = sqlCommand.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();

                return result;
            }
            catch
            {
                transaction.Rollback();
                return -1;
            }
        }

        public Histories GetById(int employee_id)
        {
            var history = new Histories();

            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM Histories WHERE employee_id = @employee_id";
            sqlCommand.Parameters.AddWithValue("@employee_id", employee_id);

            connection.Open();

            try
            { 
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    history.StartDate = reader.GetDateTime(0);
                    history.EmployeeId = reader.GetInt32(1);
                    history.EndDate = reader.GetDateTime(2);
                    history.DepartmentId = reader.GetInt32(3);
                    history.JobId = reader.GetInt32(4);
                }

                reader.Close();
                connection.Close();

                return new Histories();
            }
            catch
            {
                return new Histories();
            }
        }
    }
}
