using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;


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

                return conn.Query<Location>("SELECT DepartmentID AS DepartmentId, name, GroupName AS `group`, ModifiedDate AS modDate FROM department;").ToList();

                //MySqlCommand cmd = conn.CreateCommand();
                //cmd.CommandText = "SELECT DepartmentID AS id, name, GroupName AS group, ModifiedDate AS modDate FROM location;";
                //MySqlDataReader reader = cmd.ExecuteReader();

                //List<Location> locations = new List<Location>();
                //while (reader.Read())
                //{
                //    Location loc = new Location();
                //    loc.DepartmentId = (int)reader["id"];
                //    loc.Name = (string)reader["name"];
                //    loc.Group = (string)reader["group"];
                //    loc.ModifiedDate = (DateTime)reader["modDate"];
                //    locations.Add(loc);
                //}

                //return locations;

            }
        }

        public void CreateLocation(Location l)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                conn.Execute("INSERT INTO department(DepartmentID, Name, GroupName, ModifiedDate) VALUES (@id, @name, @group, @modDate);", new { id = l.DepartmentId, name = l.Name, group = l.Group, modDate = l.ModifiedDate });

                //MySqlCommand cmd = conn.CreateCommand();
                //cmd.CommandText = "INSERT INTO location(DepartmentID, Name, GroupName, ModifiedDate) VALUES (@id, @name, @group, @modDate);";
                //cmd.Parameters.AddWithValue("id", l.DepartmentId);
                //cmd.Parameters.AddWithValue("name", l.Name);
                //cmd.Parameters.AddWithValue("group", l.Group);
                //cmd.Parameters.AddWithValue("modDate", l.ModifiedDate);
                //cmd.ExecuteNonQuery();
            }
        }

        public void UpdateLocation(int deptID, string deptName, string groupName, DateTime dateMod)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                conn.Execute("UPDATE department SET Name = @name, GroupName = @group, ModifiedDate = @modDate WHERE DepartmentID = @id;", new { name = deptName, group = groupName, modDate = dateMod, id = deptID });

                //MySqlCommand cmd = conn.CreateCommand();
                //cmd.CommandText = "UPDATE location SET DepartmentID = @id, Name = '@name', GroupName = '@group', ModifiedDate = @modDate;";
                //cmd.Parameters.AddWithValue("DepartmentID", dId);
                //cmd.Parameters.AddWithValue("Name", n);
                //cmd.Parameters.AddWithValue("GroupName", gn);
                //cmd.Parameters.AddWithValue("ModifiedDate", dm);
                //cmd.ExecuteNonQuery();
            }
        }

        public void DeleteLocation(int dId)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                conn.Execute("DELETE FROM department WHERE DepartmentID = @id;", new { id = dId });

                //MySqlCommand cmd = conn.CreateCommand();
                //cmd.CommandText = "DELETE FROM location WHERE DepartmentID = @id;";
                //cmd.Parameters.AddWithValue("DepartmentID", dId);
                //cmd.ExecuteNonQuery();
            }
        }

        public void DeleteLocation(string n)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                conn.Execute("DELETE FROM department WHERE Name = '@name';", new { name = n });

                //MySqlCommand cmd = conn.CreateCommand();
                //cmd.CommandText = "DELETE FROM location WHERE Name = '@name';";
                //cmd.Parameters.AddWithValue("Name", n);
                //cmd.ExecuteNonQuery();
            }
        }
    }
}
