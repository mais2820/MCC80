using MVCArchitecture.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MVCArchitecture.Model
{
    public class Countries
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }

        public List<Countries> GetAll()
        {
            var connection = Connection.Get();

            var countries = new List<Countries>();

            using SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM Countries";

            try
            {
                connection.Open();
                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Countries country = new Countries();
                        country.Id = reader.GetInt32(0);
                        country.Name = reader.GetString(1);
                        country.RegionId = reader.GetInt32(2);

                        countries.Add(country);
                    }
                }
                else
                {
                    reader.Close();
                    connection.Close();
                }

                return countries;
            }
            catch
            {
                return new List<Countries>();
            }
        }

        public int Insert(Countries countries)
        {
            var connection = Connection.Get();

            using SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "INSERT INTO Countries (id, name, region_id ) " +
                "VALUES (@id, @name, @region_id)";

            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.VarChar;
                pId.Value = countries.Id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = SqlDbType.VarChar;
                pName.Value = countries.Name;
                sqlCommand.Parameters.Add(pName);

                SqlParameter pRegion_id = new SqlParameter();
                pRegion_id.ParameterName = "@region_id";
                pRegion_id.SqlDbType = SqlDbType.Int;
                pRegion_id.Value = countries.RegionId;
                sqlCommand.Parameters.Add(pRegion_id);

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

        public int Update(Countries countries)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "UPDATE Countries SET name = @newName, region_id = newRegion_id " +
                "WHERE Id = @id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.VarChar;
                pId.Value = countries.Id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = SqlDbType.VarChar;
                pName.Value = countries.Name;
                sqlCommand.Parameters.Add(pName);

                SqlParameter pRegion_id = new SqlParameter();
                pRegion_id.ParameterName = "@region_id";
                pRegion_id.SqlDbType = SqlDbType.Int;
                pRegion_id.Value = countries.RegionId;
                sqlCommand.Parameters.Add(pRegion_id);

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
            sqlCommand.CommandText = "DELETE FROM Countries WHERE id = @id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;
            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = id;
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

        public Countries GetById(int id)
        {
            var countries = new Countries();

            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM Countries WHERE id = @id";
            sqlCommand.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    Countries country = new Countries();
                    country.Id = reader.GetInt32(0);
                    country.Name = reader.GetString(1);
                    country.RegionId = reader.GetInt32(2);
                }

                reader.Close();
                connection.Close();

                return new Countries();
            }
            catch
            {
                return new Countries();
            }
        }
    }

    
}
