using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MVCArchitecture.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int ManagerId { get; set; }

        public List<Department> GetAll()
        {
            var connection = Connection.Get();

            var departments = new List<Department>();

            using SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM Department";

            try
            {
                connection.Open();
                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Department department = new Department();
                        department.Id = reader.GetInt32(0);
                        department.Name = reader.GetString(1);
                        department.LocationId = reader.GetInt32(2);
                        department.ManagerId = reader.GetInt32(3);

                        departments.Add(department);
                    }
                }
                else
                {
                    reader.Close();
                    connection.Close();
                }

                return departments;
            }
            catch
            {
                return new List<Department>();
            }
        }

        public int Insert(Department department)
        {
            var connection = Connection.Get();

            using SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "INSERT INTO Department (id, name, location_id, manager_id) " +
                "VALUES (@id, @name, @location_id, manager_id)";

            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = department.Id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = SqlDbType.VarChar;
                pName.Value = department.Name;
                sqlCommand.Parameters.Add(pName);

                SqlParameter pLocationId = new SqlParameter();
                pLocationId.ParameterName = "@location_id";
                pLocationId.SqlDbType = SqlDbType.Int;
                pLocationId.Value = department.LocationId;
                sqlCommand.Parameters.Add(pLocationId);

                SqlParameter pManagerId = new SqlParameter();
                pManagerId.ParameterName = "@manager_id";
                pManagerId.SqlDbType = SqlDbType.Int;
                pManagerId.Value = department.ManagerId;
                sqlCommand.Parameters.Add(pManagerId);

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

        public int Update(Department department)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "UPDATE Department SET Name = @name, " +
                "location_id = @location_id, manager_id = @manager_id  WHERE id = @id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = department.Id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pNewName = new SqlParameter();
                pNewName.ParameterName = "@name";
                pNewName.SqlDbType = SqlDbType.VarChar;
                pNewName.Value = department.Name;
                sqlCommand.Parameters.Add(pNewName);

                SqlParameter pNewLocationId = new SqlParameter();
                pNewLocationId.ParameterName = "@location_id";
                pNewLocationId.SqlDbType = SqlDbType.Int;
                pNewLocationId.Value = department.LocationId;
                sqlCommand.Parameters.Add(pNewLocationId);

                SqlParameter pNewManagerId = new SqlParameter();
                pNewManagerId.ParameterName = "@manager_id";
                pNewManagerId.SqlDbType = SqlDbType.Int;
                pNewManagerId.Value = department.ManagerId;
                sqlCommand.Parameters.Add(pNewManagerId);

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

        public int Delete(Department department)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "DELETE FROM Department WHERE id = @id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = department.Id;
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

        public Department GetById(int id)
        {
            var department = new Department();

            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM Department WHERE id = @id";
            sqlCommand.Parameters.AddWithValue("@region_id", id);

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    department.Id = reader.GetInt32(0);
                    department.Name = reader.GetString(1);
                    department.LocationId = reader.GetInt32(2);
                    department.ManagerId = reader.GetInt32(3);
                }

                reader.Close();
                connection.Close();

                return department;
            }
            catch
            {
                return null;
            }
        }
    }
}
