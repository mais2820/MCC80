using MVCArchitecture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.View
{
    public class JobsView
    {
        public int Menu()
        {
            Console.WriteLine("== JOBS ==");
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

        public void GetAll(List<Jobs> jobs)
        {
            foreach (var job in jobs)
            {
                GetById(job);
            }
        }

        public void GetById(Jobs jobs)
        {
            Console.WriteLine("Id           : " + jobs.Id);
            Console.WriteLine("Name         : " + jobs.Title);
            Console.WriteLine("Min Salary   : " + jobs.MinSalary);
            Console.WriteLine("Max Salary   : " + jobs.MaxSalary);
            Console.WriteLine("==========================");
        }

        public int InputById()
        {
            Console.WriteLine("Masukkan ID:");
            int inputId = Convert.ToInt32(Console.ReadLine());
            return inputId;

        }

        public Jobs InsertMenu()
        {
            Console.WriteLine("Masukkan Id : ");
            string? id = Console.ReadLine();
            Console.WriteLine("Masukan Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Masukan Min Salary: ");
            int minSalary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Masukan Max Salary: ");
            int maxSalary = Convert.ToInt32(Console.ReadLine());

            return new Jobs
            {
                Id = id,
                Title = title,
                MinSalary = minSalary,
                MaxSalary = maxSalary
            };
        }

        public Jobs UpdateMenu()
        {
            Console.WriteLine("Id yang ingin diubah: ");
            string id = Console.ReadLine();
            Console.WriteLine("Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Masukan Min Salary: ");
            int minSalary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Masukan Max Salary: ");
            int maxSalary = Convert.ToInt32(Console.ReadLine());

            return new Jobs
            {
                Id = id,
                Title = title,
                MinSalary = minSalary,
                MaxSalary = maxSalary
            };
        }

        public Jobs DeleteMenu()
        {
            Console.WriteLine("Id yang ingin dihapus: ");
            string id = Console.ReadLine();

            return new Jobs
            {
                Id = id,
                Title = "",
                MinSalary = 0,
                MaxSalary = 0
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
