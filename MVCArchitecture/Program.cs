

using MVCArchitecture.Controller;
using MVCArchitecture.Controllers;
using MVCArchitecture.Model;
using MVCArchitecture.View;
using System.Diagnostics.Metrics;

namespace MVCArchitecture;

public class Program
{
    public static void Main()
    {
        MainMenu();
    }

    private static void MainMenu()
    {
        bool ulang = true;
        do
        {
            Console.WriteLine("== MENU DATABASE AL MAIS ==");
            Console.WriteLine("== MENU DATABASE MVC ==");
            Console.WriteLine("1. Employees");
            Console.WriteLine("2. Departments");
            Console.WriteLine("3. Jobs");
            Console.WriteLine("4. Histories");
            Console.WriteLine("5. Locations");
            Console.WriteLine("6. Countries");
            Console.WriteLine("7. Regions");
            Console.WriteLine("8. LINQ");
            Console.WriteLine("9. Exit");
            Console.Write("Input Menu: ");

            try
            {
                int pilihMenu = Int32.Parse(Console.ReadLine());
                Console.Clear();

                switch (pilihMenu)
                {
                    case 1:
                        EmployeesMenu();
                        break;
                    case 2:
                        DepartmentMenu();
                        break;
                    case 3:
                        JobsMenu();
                        break;
                    case 4:
                        HistoriesMenu();
                        break;
                    case 5:
                        LocationMenu();
                        break;
                    case 6:
                        CountriesMenu();
                        break;
                    case 7:
                        RegionMenu();
                        break;
                    case 8:
                        LinqMenu();
                        PressAnyKey();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 9:
                        ulang = false;
                        break;
                    default:
                        Console.WriteLine("Silahkan Pilih Nomor 1-7");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Input Hanya diantara 1-7!");
            }
        } while (ulang);
    }

    public static void LinqMenu()
    {
        var employee = new Employees();
        var region = new Region();
        var country = new Countries();
        var location = new Location();
        var department = new Department();
        var linq = new LinqController(employee, country, region, location, department);

        linq.DetailEmployees();      
    }

    private static void RegionMenu()
    {
        Region region = new Region();
        RegionView vRegion = new RegionView();
        RegionController regionController = new RegionController(region, vRegion);

        bool isTrue = true;
        do
        {
            int pilihMenu = vRegion.Menu();
            Console.Clear();

            switch (pilihMenu)
            {
                case 1:
                    Console.Clear();
                    regionController.GetAll();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    regionController.GetById();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    regionController.Insert();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    regionController.Update();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 5:
                    Console.Clear();
                    regionController.Delete();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        }           
        while (isTrue);
        Console.Clear();
    }

    private static void JobsMenu() 
    {
        Jobs jobs = new Jobs();
        JobsView vJobs = new JobsView();
        JobsController jobsController = new JobsController(jobs, vJobs);

        bool isTrue = true;
        do
        {
            int pilihMenu = vJobs.Menu();
            Console.Clear();

            switch (pilihMenu)
            {
                case 1:
                    Console.Clear();
                    jobsController.GetAll();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    jobsController.GetById();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    jobsController.Insert();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    jobsController.Update();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 5:
                    Console.Clear();
                    jobsController.Delete();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } 
        while (isTrue);
    }

    private static void CountriesMenu()
    {
        Countries countries = new Countries();
        CountriesView vCountries = new CountriesView();
        CountriesController countriesController = new CountriesController(countries, vCountries);

        bool isTrue = true;
        do
        {
            int pilihMenu = vCountries.Menu();
            Console.Clear();

            switch (pilihMenu)
            {
                case 1:
                    Console.Clear();
                    countriesController.GetAll();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    countriesController.GetById();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    countriesController.Insert();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    countriesController.Update();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 5:
                    Console.Clear();
                    countriesController.Delete();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void LocationMenu()
    {
        Location location = new Location();
        LocationView vLocation = new LocationView();
        LocationController locationController = new LocationController(location, vLocation);

        bool isTrue = true;
        do
        {
            int pilihMenu = vLocation.Menu();
            Console.Clear();

            switch (pilihMenu)
            {
                case 1:
                    Console.Clear();
                    locationController.GetAll();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    locationController.GetById();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    locationController.Insert();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    locationController.Update();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 5:
                    Console.Clear();
                    locationController.Delete();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void DepartmentMenu()
    {
        Department department = new Department();
        DepartmentView vDepartment = new DepartmentView();
        DepartmentController departmentController = new DepartmentController(department, vDepartment);

        bool isTrue = true;
        do
        {
            int pilihMenu = vDepartment.Menu();
            Console.Clear();

            switch (pilihMenu)
            {
                case 1:
                    Console.Clear();
                    departmentController.GetAll();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    departmentController.GetById();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    departmentController.Insert();
                    PressAnyKey();
                    break;
                case 4:
                    Console.Clear();
                    departmentController.Update();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 5:
                    Console.Clear();
                    departmentController.Delete();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } 
        while (isTrue);
    }

    private static void HistoriesMenu()
    {
        Histories histories = new Histories();
        HistoriesView vHistories = new HistoriesView();
        HistoriesController historiesController = new HistoriesController(histories, vHistories);

        bool isTrue = true;
        do
        {
            int pilihMenu = vHistories.Menu();
            Console.Clear();

            switch (pilihMenu)
            {
                case 1:
                    Console.Clear();
                    historiesController.GetAll();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    historiesController.GetById();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    historiesController.Insert();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    historiesController.Update();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 5:
                    Console.Clear();
                    historiesController.Delete();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }

    private static void EmployeesMenu()
    {
        Employees employees = new Employees();
        EmployeesView vEmployees = new EmployeesView();
        EmployeesController employeesController = new EmployeesController(employees, vEmployees);

        bool isTrue = true;
        do
        {
            int pilihMenu = vEmployees.Menu();
            Console.Clear();

            switch (pilihMenu)
            {
                case 1:
                    Console.Clear();
                    employeesController.GetAll();
                    PressAnyKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    employeesController.GetById();
                    PressAnyKey();
                    break;
                case 3:
                    Console.Clear();
                    employeesController.Insert();
                    PressAnyKey();
                    break;
                case 4:
                    Console.Clear();
                    employeesController.Update();
                    PressAnyKey();
                    break;
                case 5:
                    Console.Clear();
                    employeesController.Delete();
                    PressAnyKey();
                    break;
                case 6:
                    isTrue = false;
                    break;
                default:
                    InvalidInput();
                    break;
            }
        } while (isTrue);
    }


    private static void InvalidInput()
    {
        Console.WriteLine("Your input is not valid!");
    }

    private static void PressAnyKey()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
