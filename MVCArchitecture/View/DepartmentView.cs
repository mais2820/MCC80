using MVCArchitecture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.View
{
    public class DepartmentView
    {
        public int Menu()
        {
            Console.WriteLine("== DEPARTMENT ==");
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

        public void GetAll(List<Department> departments)
        {
            foreach (var department in departments)
            {
                GetById(department);
            }
        }
        public void GetById(Department department)
        {
            Console.WriteLine("Id: " + department.Id);
            Console.WriteLine("Name: " + department.Name);
            Console.WriteLine("Location Id: " + department.LocationId);
            Console.WriteLine("Manager Id: " + department.ManagerId);
            Console.WriteLine("==========================");
        }

        public Department InsertMenu()
        {
            Console.WriteLine("Masukan Nama: ");
            string? inputName = Console.ReadLine();

            Console.WriteLine("Masukan Location ID: ");
            int locationId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Masukan Manager ID: ");
            int managerId = Convert.ToInt32(Console.ReadLine());

            return new Department
            {
                Id = 0,
                Name = inputName,
                LocationId = locationId,
                ManagerId = managerId
            };
        }

        public Department UpdateMenu()
        {
            Console.WriteLine("Id yang ingin diubah: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Masukan Nama: ");
            string? inputName = Console.ReadLine();

            Console.WriteLine("Masukan Location ID: ");
            int locationId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Masukan Manager ID: ");
            int managerId = Convert.ToInt32(Console.ReadLine());

            return new Department
            {
                Id = id,
                Name = inputName,
                LocationId = locationId,
                ManagerId = managerId               
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
