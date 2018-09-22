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

            }
        }
    }
}
