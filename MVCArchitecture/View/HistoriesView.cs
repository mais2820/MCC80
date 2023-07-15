using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCArchitecture.Model;

namespace MVCArchitecture.View
{
    public class HistoriesView
    {
        public int Menu()
        {
            Console.WriteLine("== HISTORIES ==");
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
        public void GetAll(List<Histories> historiess)
        {
            foreach (var histories in historiess)
            {
                GetById(histories);
            }
        }

        public void GetById(Histories histories)
        {
            Console.WriteLine("Start Date: " + histories.StartDate);
            Console.WriteLine("Employee Id: " + histories.EmployeeId);
            Console.WriteLine("End Date: " + histories.EndDate);
            Console.WriteLine("Department Id: " + histories.DepartmentId);
            Console.WriteLine("Job Id: " + histories.JobId);
            Console.WriteLine("==========================");
        }

        public int InputById()
        {
            Console.WriteLine("Masukkan ID:");
            int inputId = Convert.ToInt32(Console.ReadLine());
            return inputId;

        }

        public Histories InsertMenu()
        {
            Console.WriteLine("Masukan Start Date: ");
            DateTime startDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Masukan Employee Id: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Masukan End Date: ");
            DateTime endDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Masukan Department Id: ");
            int departmentId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Masukan Job Id: ");
            int jobId = Convert.ToInt32(Console.ReadLine());

            return new Histories
            {
                StartDate = startDate, 
                EmployeeId = employeeId,
                EndDate = endDate,
                DepartmentId = departmentId,
                JobId = jobId               
            };
        }

        public Histories UpdateMenu()
        {
            Console.WriteLine("Masukan Start Date: ");
            DateTime startDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Masukan Employee Id: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Masukan End Date: ");
            DateTime endDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Masukan Department Id: ");
            int departmentId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Masukan Job Id: ");
            int jobId = Convert.ToInt32(Console.ReadLine());

            return new Histories
            {
                StartDate = startDate,
                EmployeeId = employeeId,
                EndDate = endDate,
                DepartmentId = departmentId,
                JobId = jobId
            };
        }

        public Histories DeleteMenu()
        {
            Console.WriteLine("Employee Id yang ingin dihapus: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());

            return new Histories
            {
                StartDate = DateTime.Now,
                EmployeeId = employeeId,
                EndDate = null,
                DepartmentId = 0,
                JobId = 0
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
