using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Model
{
    public class Location
    {
        public int Id { get; set; }
        public string? StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? StateProvince { get; set; }
        public int CountryId { get; set; }

        public List<Location> GetAll()
        {
            var connection = Connection.Get();

            var locations = new List<Location>();

            using SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM Location";

            try
            {
                connection.Open();
                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Location location = new Location();
                        location.Id = reader.GetInt32(0);
                        location.StreetAddress =  reader.GetString(1);
                        location.PostalCode =  reader.GetString(2);
                        location.City = reader.GetString(3);
                        location.StateProvince =  reader.GetString(4);
                        location.CountryId =  reader.GetInt32(5);

                        locations.Add(location);
                    }
                }
                else
                {
                    reader.Close();
                    connection.Close();
                }

                return locations;
            }
            catch
            {
                return new List<Location>();
            }
        }

        public int Insert(Location location)
        {
            var connection = Connection.Get();

            using SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "INSERT INTO Location (id, street_address, postal_code, city, state_province, country_id) " +
                "VALUES (@id, @street_address, @postal_code, @city, @state_province, @country_id)";

            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            try
            {
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.VarChar;
                pId.Value = Id;
                sqlCommand.Parameters.Add(pId);

                SqlParameter pStreetAddress = new SqlParameter();
                pStreetAddress.ParameterName = "@street_address";
                pStreetAddress.SqlDbType = SqlDbType.VarChar;
                pStreetAddress.Value = StreetAddress;
                sqlCommand.Parameters.Add(pStreetAddress);

                SqlParameter pPostalCode = new SqlParameter();
                pPostalCode.ParameterName = "@postal_code";
                pPostalCode.SqlDbType = SqlDbType.Int;
                pPostalCode.Value = PostalCode;
                sqlCommand.Parameters.Add(pPostalCode);

                SqlParameter pCity = new SqlParameter();
                pCity.ParameterName = "@city";
                pCity.SqlDbType = SqlDbType.VarChar;
                pCity.Value = City;
                sqlCommand.Parameters.Add(pCity);

                SqlParameter pStateProvince = new SqlParameter();
                pStateProvince.ParameterName = "@state_province";
                pStateProvince.SqlDbType = SqlDbType.VarChar;
                pStateProvince.Value = StateProvince;
                sqlCommand.Parameters.Add(pStateProvince);

                SqlParameter pCountryId = new SqlParameter();
                pCountryId.ParameterName = "@country_id";
                pCountryId.SqlDbType = SqlDbType.Int;
                pCountryId.Value = CountryId;
                sqlCommand.Parameters.Add(pCountryId);

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

        public int Update(Location location)
        {
            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "UPDATE Location SET street_address = @newStreet_address, postal_code = @newPostal_code, " +
                "city = @newCity, state_province = @newState_province,country_id = @newCountry_id WHERE id = @id";

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            sqlCommand.Transaction = transaction;

            sqlCommand.Parameters.AddWithValue("@id", Id);
            sqlCommand.Parameters.AddWithValue("@newStreet_address", StreetAddress);
            sqlCommand.Parameters.AddWithValue("@newPostal_code", PostalCode);
            sqlCommand.Parameters.AddWithValue("@newCity", City);
            sqlCommand.Parameters.AddWithValue("@newState_province", StateProvince);
            sqlCommand.Parameters.AddWithValue("@newCountry_id", CountryId);

            try { 
                 
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
            sqlCommand.CommandText = "DELETE FROM Location WHERE Id = @id";

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

        public Location GetById(int id)
        {
            var location = new Location();

            var connection = Connection.Get();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "SELECT * FROM Location WHERE ID = @id";
            sqlCommand.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    location.Id = reader.GetInt32(0);
                    location.StreetAddress = reader.GetString(1);
                    location.PostalCode = reader.GetString(2);
                    location.City = reader.GetString(3);
                    location.StateProvince = reader.GetString(4);
                    location.CountryId = reader.GetInt32(5);
                }

                reader.Close();
                connection.Close();

                return new Location();
            }
            catch
            {
                return new Location();
            }
        }
    }   
}
