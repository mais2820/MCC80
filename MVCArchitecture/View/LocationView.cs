using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCArchitecture.Model;

namespace MVCArchitecture.View
{
    public class LocationView
    {
        public int Menu()
        {
            Console.WriteLine("== LOCATION ==");
            Console.WriteLine("1. Get All");
            Console.WriteLine("2. GetById");
            Console.WriteLine("3. Insert");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Back");
            Console.WriteLine("Pilih: ");

            int input = Int32.Parse(Console.ReadLine());
            return input;
        }
        public void GetAll(List<Location> locations)
        {
            foreach (var location in locations)
            {
                GetById(location);
            }
        }

        public void GetById(Location location)
        {
            Console.WriteLine("Id: " + location.Id);
            Console.WriteLine("Street Address: " + location.StreetAddress);
            Console.WriteLine("Postal Code: " + location.PostalCode);
            Console.WriteLine("City: " + location.City);
            Console.WriteLine("State Province: " + location.StateProvince);
            Console.WriteLine("Country Id: " + location.CountryId);
            Console.WriteLine("==========================");
        }

        public Location InsertMenu()
        {
            Console.WriteLine("Masukan ID: ");
            int inputId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Street Address: ");
            string streetAddress = Console.ReadLine();

            Console.WriteLine("Postal Code: ");
            string postalCode = Console.ReadLine();

            Console.WriteLine("City: ");
            string city = Console.ReadLine();

            Console.WriteLine("State Province: ");
            string stateProvince = Console.ReadLine();

            Console.WriteLine("Country ID: ");
            string countryId = Console.ReadLine();

            return new Location
            {
                Id = 0,
                StreetAddress = streetAddress,
                PostalCode = postalCode,
                City = city,
                StateProvince = stateProvince, 
                CountryId = countryId
            };
        }

        public Location UpdateMenu()
        {
            Console.WriteLine("Masukan ID: ");
            int inputId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Street Address: ");
            string streetAddress = Console.ReadLine();

            Console.WriteLine("Postal Code: ");
            string postalCode = Console.ReadLine();

            Console.WriteLine("City: ");
            string city = Console.ReadLine();

            Console.WriteLine("State Province: ");
            string stateProvince = Console.ReadLine();

            Console.WriteLine("Country ID: ");
            string countryId = Console.ReadLine();

            return new Location
            {
                Id = inputId,
                StreetAddress = streetAddress,
                PostalCode = postalCode,
                City = city,
                StateProvince = stateProvince,
                CountryId = countryId
            };
        }

        public void DataEmpty()
        {
            Console.WriteLine("Data Not Found!");
        }
        public void Success()
        {
            Console.WriteLine("Success!");
        }
        public void Failure()
        {
            Console.WriteLine("Fail, Id not found!");
        }
        public void Error()
        {
            Console.WriteLine("Error retrieving from database!");
        }
    }
}
