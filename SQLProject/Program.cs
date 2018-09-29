using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace SQLProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
#if DEBUG
                .AddJsonFile("appsettings.Debug.json")
#else
                .AddJsonFile("appsettings.Release.json")
#endif
                .Build();

            string connString = configuration.GetConnectionString("DefaultConnection");


            var repo = new LocationRepository(connString);

            var list1 = repo.GetLocations();

            foreach(Location locs in list1)
            {
                Console.WriteLine($"{locs.DepartmentId} {locs.Name} {locs.Group} {locs.ModifiedDate}");
            }

            //Console.WriteLine("Creating Product...");
            //var newLocation = new Location { DepartmentId = 17, Name = "Customer Service", Group = "Quality Assurance", ModifiedDate = DateTime.Now };
            //repo.CreateLocation(newLocation);
            //Console.WriteLine("Product Created!");

            //Console.WriteLine("Updating Location...");
            //repo.UpdateLocation(17, "Customer Support", "Client Success", DateTime.Now);
            //Console.WriteLine("Product Updated!");

            //Console.WriteLine("Deleting Location...");
            //repo.DeleteLocation(17);
            //Console.WriteLine(" Location Deleted!");
        }
    }
}
