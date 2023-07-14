

using MVCArchitecture.Controller;
using MVCArchitecture.Model;
using MVCArchitecture.View;
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
            Console.WriteLine("8. Exit");
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
                    regionController.GetAll();
                    PressAnyKey();
                    break;
                case 2:
                    regionController.GetById();
                    PressAnyKey();
                    break;
                case 3:
                    regionController.Insert();
                    PressAnyKey();
                    break;
                case 4:
                    regionController.Update();
                    PressAnyKey();
                    break;
                case 5:
                    regionController.Delete();
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
                    jobsController.GetAll();
                    PressAnyKey();
                    break;
                case 2:
                    jobsController.GetById();
                    PressAnyKey();
                    break;
                case 3:
                    jobsController.Insert();
                    PressAnyKey();
                    break;
                case 4:
                    jobsController.Update();
                    PressAnyKey();
                    break;
                case 5:
                    jobsController.Delete();
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
                    countriesController.GetAll();
                    PressAnyKey();
                    break;
                case 2:
                    countriesController.GetById();
                    PressAnyKey();
                    break;
                case 3:
                    countriesController.Insert();
                    PressAnyKey();
                    break;
                case 4:
                    countriesController.Update();
                    PressAnyKey();
                    break;
                case 5:
                    countriesController.Delete();
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
                    locationController.GetAll();
                    PressAnyKey();
                    break;
                case 2:
                    locationController.GetById();
                    PressAnyKey();
                    break;
                case 3:
                    locationController.Insert();
                    PressAnyKey();
                    break;
                case 4:
                    locationController.Update();
                    PressAnyKey();
                    break;
                case 5:
                    locationController.Delete();
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
                    departmentController.GetAll();
                    PressAnyKey();
                    break;
                case 2:
                    departmentController.GetById();
                    PressAnyKey();
                    break;
                case 3:
                    departmentController.Insert();
                    PressAnyKey();
                    break;
                case 4:
                    departmentController.Update();
                    PressAnyKey();
                    break;
                case 5:
                    departmentController.Delete();
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
                    historiesController.GetAll();
                    PressAnyKey();
                    break;
                case 2:
                    historiesController.GetById();
                    PressAnyKey();
                    break;
                case 3:
                    historiesController.Insert();
                    PressAnyKey();
                    break;
                case 4:
                    historiesController.Update();
                    PressAnyKey();
                    break;
                case 5:
                    historiesController.Delete();
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
                    employeesController.GetAll();
                    PressAnyKey();
                    break;
                case 2:
                    employeesController.GetById();
                    PressAnyKey();
                    break;
                case 3:
                    employeesController.Insert();
                    PressAnyKey();
                    break;
                case 4:
                    employeesController.Update();
                    PressAnyKey();
                    break;
                case 5:
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
