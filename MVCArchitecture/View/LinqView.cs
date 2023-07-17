using MVCArchitecture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.View
{
    public class LinqView
    {
        public void GetAll(List<Linq> linq)
        {
            foreach (var l in linq)
            {
                Console.WriteLine("==========================================");
                Console.WriteLine("Id: " + l.Id);
                Console.WriteLine("Full Name: " + l.FirstName + " " + l.LastName);
                Console.WriteLine("Email: " + l.Email);
                Console.WriteLine("Phone Number: " + l.PhoneNumber);
                Console.WriteLine("Salary: " + l.Salary);
                Console.WriteLine("Department Name: " + l.DepartmentName);
                Console.WriteLine("Street Address: " + l.StreetAddress);
                Console.WriteLine("Country Name: " + l.Country);
                Console.WriteLine("Region Name: " + l.Region);
                Console.WriteLine("==========================================");
            }
        }
    }
}
