using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCArchitecture.Model;

namespace MVCArchitecture.View
{
    public class RegionView
    {
        public int Menu()
        {
            Console.WriteLine("== REGION ==");
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
        public void GetAll(List<Region> regions)
        {
            foreach (var region in regions)
            {
                GetById(region);
            }
        }

        public void GetById(Region region)
        {
            Console.WriteLine("==========================");
            Console.WriteLine("Id   : " + region.Id);
            Console.WriteLine("Name : " + region.Name);
        }       

        public int InputById()
        {
            Console.WriteLine("Masukkan ID:");
            int inputId = Convert.ToInt32(Console.ReadLine());
            return inputId;

        }

        public Region InsertMenu()
        {
            Console.WriteLine("Id yang ingin di insert: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Masukan Nama: ");
            string inputName = Console.ReadLine();

            return new Region
            {
                Id = id,
                Name = inputName
            };
        }

        public Region UpdateMenu()
        {
            Console.WriteLine("Id yang ingin diubah: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nama: ");
            string name = Console.ReadLine();

            return new Region
            {
                Id = id,
                Name = name
            };
        }

        public Region DeleteMenu()
        {
            Console.WriteLine("Id yang ingin dihapus: ");
            int id = Convert.ToInt32(Console.ReadLine());

            return new Region
            {
                Id = id,
                Name = ""
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
