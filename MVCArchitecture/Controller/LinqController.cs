using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCArchitecture.Model;

namespace MVCArchitecture.Controllers;

public class LinqController
{
    private Employees _employees;
    private Countries _countries;
    private Region _region;
    private Location _location;
    private Department _department;

    public LinqController(Employees employee, Countries country, Region region, Location location, Department department)
    {
        _employees = employee;
        _countries = country;
        _region = region;
        _location = location;
        _department = department;
    }
    public void DetailEmployees()
    {
        var getEmployees = _employees.GetAll();
        var getRegion = _region.GetAll();
        var getCountry = _countries.GetAll();
        var getLocation = _location.GetAll();
        var getDepartment = _department.GetAll(); 


        var detailEmployeeByQuery = (from e in getEmployees 
                                     join d in getDepartment on e.DepartmentId equals d.Id
                                     join l in getLocation on d.LocationId equals l.Id
                                     join c in getCountry on l.CountryId equals c.Id
                                     join r in getRegion on c.RegionId equals r.Id
                                    select new
                                    {
                                        Id = e.Id,
                                        FirstName = e.FirstName,
                                        LastName = e.LastName,
                                        Email = e.Email,
                                        Phone = e.PhoneNumber,
                                        Salary = e.Salary,
                                        DepartmentName = d.Name,
                                        StreetAddress = l.StreetAddress,
                                        CountryName = c.Name,
                                        RegionName = r.Name
                                    }).ToList();

        foreach (var employee in detailEmployeeByQuery)
        {
            //Console.WriteLine($"{employee.Id} {employee.FirstName} {employee.LastName} {employee.Email} {employee.Phone} {employee.Salary} " +
                //$"{employee.DepartmentName} {employee.StreetAddress} {employee.CountryName} {employee.RegionName}");
            Console.WriteLine("Id              : "+employee.Id);
            Console.WriteLine("Full Name       : "+employee.FirstName+" "+employee.LastName);
            Console.WriteLine("Email           : "+employee.Email);
            Console.WriteLine("Phone           : "+employee.Phone);
            Console.WriteLine("Salary          : "+employee.Salary);
            Console.WriteLine("Department Name : "+employee.DepartmentName);
            Console.WriteLine("Street Address  : "+employee.StreetAddress);
            Console.WriteLine("Country Name    : "+employee.CountryName);
            Console.WriteLine("Region Name     : "+employee.RegionName);
            Console.WriteLine("");

        }
    }
}
