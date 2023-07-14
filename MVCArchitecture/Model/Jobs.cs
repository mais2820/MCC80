using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCArchitecture.Controller;

namespace MVCArchitecture.Model
{
    public class Jobs
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }

        public List<Jobs> GetAll()
        {
            var connection = Connection.Get();

            var jobs = new List<Jobs>();

            using SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM Jobs";

            try
            {
                connection.Open();
                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Jobs job = new Jobs();
                        job.Id = reader.GetString(0);
                        job.Title = reader.GetString(1);
                        job.MinSalary = reader.GetInt32(2);
                        job.MaxSalary = reader.GetInt32(3);

                        jobs.Add(job);
                    }
                }
                else
                {
                    reader.Close();
                    connection.Close();
                }

                return jobs;
            }
            catch
            {
                return new List<Jobs>();
            }
        }

        public int Insert(Jobs jobs)
        {
            var connection = Connection.Get();

            using SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "INSERT INTO Jobs(id, title, min_salary, max_salary) " +
                "VALUES(@id, @title, @min_salary, @max_salary)";

            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Char;
                pId.Value = Id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pTitle = new SqlParameter();
                pTitle.ParameterName = "@title";
                pTitle.SqlDbType = SqlDbType.VarChar;
                pTitle.Value = Title;
                sqlCommand.Parameters.Add(pTitle);

                SqlParameter pMinSalary = new SqlParameter();
                pMinSalary.ParameterName = "@min_salary";
                pMinSalary.SqlDbType = SqlDbType.Int;
                pMinSalary.Value = MinSalary;
                sqlCommand.Parameters.Add(pMinSalary);

                SqlParameter pMaxSalary = new SqlParameter();
                pMaxSalary.ParameterName = "@max_salary";
                pMaxSalary.SqlDbType = SqlDbType.Int;
                pMaxSalary.Value = MaxSalary;
                sqlCommand.Parameters.Add(pMaxSalary);

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

        public int Update(Jobs jobs)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "UPDATE Jobs SET title = @newTitle, min_salary = @newMin_salary, max_salary = @newMax_salary " +
                "WHERE Id = @id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Char;
                pId.Value = Id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pTitle = new SqlParameter();
                pTitle.ParameterName = "@title";
                pTitle.SqlDbType = SqlDbType.VarChar;
                pTitle.Value = Title;
                sqlCommand.Parameters.Add(pTitle);

                SqlParameter pMinSalary = new SqlParameter();
                pMinSalary.ParameterName = "@min_salary";
                pMinSalary.SqlDbType = SqlDbType.Int;
                pMinSalary.Value = MinSalary;
                sqlCommand.Parameters.Add(pMinSalary);

                SqlParameter pMaxSalary = new SqlParameter();
                pMaxSalary.ParameterName = "@max_salary";
                pMaxSalary.SqlDbType = SqlDbType.Int;
                pMaxSalary.Value = MaxSalary;
                sqlCommand.Parameters.Add(pMaxSalary);

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


        public int Delete(int id)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "DELETE FROM Jobs WHERE Id = @id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = Id;
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

        public Jobs GetById(int id)
        {
            var jobs = new Jobs();

            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM Jobs WHERE ID = @id";
            sqlCommand.Parameters.AddWithValue("@region_id", id);

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    jobs.Id = reader.GetString(0);
                    jobs.Title = reader.GetString(1);
                    jobs.MinSalary = reader.GetInt32(2);
                    jobs.MaxSalary = reader.GetInt32(3);
                }

                reader.Close();
                connection.Close();

                return new Jobs();
            }
            catch
            {
                return new Jobs();
            }
        }
    }
    
}
