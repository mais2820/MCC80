using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCArchitecture.Model;

namespace MVCArchitecture.View
{
    public class CountriesView
    {
        public int Menu()
        {
            Console.WriteLine("== COUNTRIES ==");
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

        public void GetAll(List<Countries> countriess)
        {
            foreach (var Countries in countriess)
            {
                GetById(Countries);
            }
        }

        public void GetById(Countries countries)
        {
            Console.WriteLine("Id: " + countries.Id);
            Console.WriteLine("Name: " + countries.Name);
            Console.WriteLine("Region ID: " + countries.RegionId);
            Console.WriteLine("==========================");
        }

        public Countries InsertMenu()
        {
            Console.WriteLine("Masukan ID: ");
            string inputId = Console.ReadLine();

            Console.WriteLine("Masukan Nama: ");
            string? inputName = Console.ReadLine();

            Console.WriteLine("Masukan Region ID: ");
            int inputRegionId = Convert.ToInt32(Console.ReadLine()); 

            return new Countries
            {
                Id = inputId,
                Name = inputName,
                RegionId = inputRegionId
            };
        }

        public Countries UpdateMenu()
        {
            Console.WriteLine("Id yang ingin diubah: ");
            string id = Console.ReadLine();
            
            Console.WriteLine("Nama: ");
            string name = Console.ReadLine();

            Console.WriteLine("Region ID: ");
            int inputRegionId = Convert.ToInt32(Console.ReadLine());

            return new Countries
            {
                Id = id,
                Name = name,
                RegionId= inputRegionId
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

