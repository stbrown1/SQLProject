using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SQLProject
{
    public class LocationRepository
    {
        private static string connectionString;

        public LocationRepository(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public List<Location> GetLocations()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT DepartmentID AS id, name, GroupName AS group, ModifiedDate AS modDate FROM location;";
                MySqlDataReader reader = cmd.ExecuteReader();

                List<Location> locations = new List<Location>();
                while (reader.Read())
                {
                    Location loc = new Location();
                    loc.DepartmentId = (int)reader["id"];
                    loc.Name = (string)reader["name"];
                    loc.Group = (string)reader["group"];
                    loc.ModifiedDate = (DateTime)reader["modDate"];
                    locations.Add(loc);
                }

                return locations;

            }
        }

        public void CreateLocation(Location l)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO location(DepartmentID, Name, GroupName, ModifiedDate) VALUES (@id, @name, @group, @modDate);";
                cmd.Parameters.AddWithValue("DepartmentID", l.DepartmentId);
                cmd.Parameters.AddWithValue("Name", l.Name);
                cmd.Parameters.AddWithValue("GroupName", l.Group);
                cmd.Parameters.AddWithValue("ModifiedDate", l.ModifiedDate);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateLocation(int dId, string n, string gn, DateTime dm)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE location SET DepartmentID = @id, Name = '@name', GroupName = '@group', ModifiedDate = @modDate);";
                cmd.Parameters.AddWithValue("DepartmentID", dId);
                cmd.Parameters.AddWithValue("Name", n);
                cmd.Parameters.AddWithValue("GroupName", gn);
                cmd.Parameters.AddWithValue("ModifiedDate", dm);
                cmd.ExecuteNonQuery();
                
            }
        }
    }
}
