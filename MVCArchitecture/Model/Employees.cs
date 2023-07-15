using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Model
{
    public class Employees
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public int? Salary { get; set; }
        public decimal? ComissionPct { get; set; }
        public int? ManagerId { get; set; }
        public string? JobId { get; set; }
        public int DepartmentId { get; set; }

        public List<Employees> GetAll()
        {
            var connection = Connection.Get();

            var employees = new List<Employees>();

            using SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM Employees";

            try
            {
                connection.Open();
                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employees employee = new Employees();
                        employee.Id =  reader.GetInt32(0);
                        employee.FirstName = reader.GetString(1);
                        employee.LastName = reader.GetString(2);
                        employee.Email = reader.GetString(3);
                        employee.PhoneNumber = reader.GetString(4);
                        employee.HireDate = reader.GetDateTime(5);
                        employee.Salary = reader.GetInt32(6);
                        employee.ComissionPct = reader.GetDecimal(7);
                        employee.ManagerId = reader.GetInt32(8);
                        employee.JobId = reader.GetString(9);
                        employee.DepartmentId = reader.GetInt32(10);

                        employees.Add(employee);
                    }
                }
                else
                {
                    reader.Close();
                    connection.Close();
                }

                return employees;
            }
            catch
            {
                return new List<Employees>();
            }
        }

        public int Insert(Employees employees)
        {
            var connection = Connection.Get();

            using SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "INSERT INTO Employees (id, first_name, last_name, email, phone_number, hire_date, salary, commission_pct, manager_id, job_id, department_id) " +
                "VALUES (@id, @first_name, @last_name, @email, @phone_number, @hire_date, @salary, @commission_pct, @manager_id, @job_id, @department_id)";

            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                sqlCommand.Parameters.AddWithValue("@id", employees.Id);
                sqlCommand.Parameters.AddWithValue("@first_name", employees.FirstName);
                sqlCommand.Parameters.AddWithValue("@last_name", employees.LastName);
                sqlCommand.Parameters.AddWithValue("@email", employees.Email);
                sqlCommand.Parameters.AddWithValue("@phone_number", employees.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@hire_date", employees.HireDate);
                sqlCommand.Parameters.AddWithValue("@salary", employees.Salary);
                sqlCommand.Parameters.AddWithValue("@commission_pct", employees.ComissionPct);
                sqlCommand.Parameters.AddWithValue("@manager_id", employees.ManagerId);
                sqlCommand.Parameters.AddWithValue("@job_id", employees.JobId);
                sqlCommand.Parameters.AddWithValue("@department_id", employees.DepartmentId);

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

        public int Update(Employees employees)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "UPDATE Employees SET first_name = @first_name, last_name = @last_name, email = @email, phone_number = @phone_number, hire_date = @hire_date, salary = @salary, commission_pct = @commission_pct, manager_id = @manager_id, job_id = @job_id, department_id = @department_id " +
                "WHERE id = @id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                sqlCommand.Parameters.AddWithValue("@id", employees.Id);
                sqlCommand.Parameters.AddWithValue("@first_name", employees.FirstName);
                sqlCommand.Parameters.AddWithValue("@last_name", employees.LastName);
                sqlCommand.Parameters.AddWithValue("@email", employees.Email);
                sqlCommand.Parameters.AddWithValue("@phone_number", employees.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@hire_date", employees.HireDate);
                sqlCommand.Parameters.AddWithValue("@salary", employees.Salary);
                sqlCommand.Parameters.AddWithValue("@commission_pct", employees.ComissionPct);
                sqlCommand.Parameters.AddWithValue("@manager_id", employees.ManagerId);
                sqlCommand.Parameters.AddWithValue("@job_id", employees.JobId);
                sqlCommand.Parameters.AddWithValue("@department_id", employees.DepartmentId);

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

        public int Delete(Employees employees)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "DELETE FROM Employees WHERE id = @id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = employees.Id;
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

        public Employees GetById(int id)
        {
            var employee = new Employees();

            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM Employees WHERE id = @id";
            sqlCommand.Parameters.AddWithValue("@region_id", id);

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    employee.Id = reader.GetInt32(0);
                    employee.FirstName = reader.GetString(1);
                    employee.LastName = reader.GetString(2);
                    employee.Email = reader.GetString(3);
                    employee.PhoneNumber = reader.GetString(4);
                    employee.HireDate = reader.GetDateTime(5);
                    employee.Salary = reader.GetInt32(6);
                    employee.ComissionPct = reader.GetDecimal(7);
                    employee.ManagerId = reader.GetInt32(8);
                    employee.JobId = reader.GetString(9);
                    employee.DepartmentId = reader.GetInt32(10);
                }

                reader.Close();
                connection.Close();

                return employee;
            }
            catch
            {
                return null;
            }
        }
    }
}
