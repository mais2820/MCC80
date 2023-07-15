using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCArchitecture.Model;

namespace MVCArchitecture.View
{
    public class EmployeesView
    {
        public int Menu()
        {
            Console.WriteLine("== EMPLOYEES ==");
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

        public void GetAll(List<Employees> employeess)
        {
            foreach (var employee in employeess)
            {
                GetById(employee);
            }
        }

        public void GetById(Employees employees)
        {
            Console.WriteLine("==========================");
            Console.WriteLine("Id: " + employees.Id);
            Console.WriteLine("Name: " + employees.FirstName);
            Console.WriteLine("Id: " + employees.LastName);
            Console.WriteLine("Id: " + employees.Email);
            Console.WriteLine("Id: " + employees.PhoneNumber);
            Console.WriteLine("Id: " + employees.HireDate);
            Console.WriteLine("Id: " + employees.Salary);
            Console.WriteLine("Id: " + employees.ComissionPct);
            Console.WriteLine("Id: " + employees.ManagerId);
            Console.WriteLine("Id: " + employees.JobId);
            Console.WriteLine("Id: " + employees.DepartmentId);
        }

        public int InputById()
        {
            Console.WriteLine("Masukkan ID:");
            int inputId = Convert.ToInt32(Console.ReadLine());
            return inputId;

        }

        public Employees InsertMenu()
        {
            Console.WriteLine("Masukan Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Masukan First Name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Masukan Last Name: ");
            string? lastName = Console.ReadLine();

            Console.WriteLine("Masukan Email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Masukan Phone Number: ");
            string? phoneNumber = Console.ReadLine();

            Console.WriteLine("Masukan Hire Date: ");
            DateTime hireDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Masukan Salary: ");
            int? salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Masukan Comission PCT: ");
            int? comissionPct = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Masukan Manager ID: ");
            int? managerId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Masukan Job ID: ");
            string jobId = Console.ReadLine();

            Console.WriteLine("Masukan Department Id: ");
            int departmentId = Convert.ToInt32(Console.ReadLine());

            return new Employees
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                HireDate = hireDate,
                Salary = salary,
                ComissionPct = comissionPct,
                ManagerId = managerId,
                JobId = jobId,
                DepartmentId = departmentId,
            };
        }

        public Employees UpdateMenu()
        {
            Console.WriteLine("Id yang ingin diubah: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Masukan First Name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Masukan Last Name: ");
            string? lastName = Console.ReadLine();

            Console.WriteLine("Masukan Email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Masukan Phone Number: ");
            string? phoneNumber = Console.ReadLine();

            Console.WriteLine("Masukan Hire Date: ");
            DateTime hireDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Masukan Salary: ");
            int? salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Masukan Comission PCT: ");
            int? comissionPct = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Masukan Manager ID: ");
            int? managerId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Masukan Job ID: ");
            string jobId = Console.ReadLine();

            Console.WriteLine("Masukan Department Id: ");
            int departmentId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Nama: ");
            string name = Console.ReadLine();

            return new Employees
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                HireDate = hireDate,
                Salary = salary,
                ComissionPct = comissionPct,
                ManagerId = managerId,
                JobId = jobId,
                DepartmentId = departmentId,
            };
        }
        public Employees DeleteMenu()
        {
            Console.WriteLine("Id yang ingin dihapus: ");
            int id = Convert.ToInt32(Console.ReadLine());

            return new Employees
            {
                Id = id,
                FirstName = "",
                LastName = "",
                Email = "",
                PhoneNumber = "",
                HireDate = DateTime.Now,
                Salary = 0,
                ComissionPct = 0,
                ManagerId = 0,
                JobId = "",
                DepartmentId = 0,
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
