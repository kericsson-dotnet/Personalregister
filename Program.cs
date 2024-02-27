internal class Program
{
    private static void Main(string[] args)
    {
        Register register = new Register();
        Console.WriteLine("Welcome!");
        string? choice = "";

        while (choice != "3")
        {
            Console.WriteLine("\n1. Add new employee");
            Console.WriteLine("2. Print list of employees");
            Console.WriteLine("3. Quit");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Name?");
                    string? name = Console.ReadLine();
                    while (String.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Please enter a name.");
                        name = Console.ReadLine();
                    }
                    Console.WriteLine("Salary?");

                    bool isValidSalary = false;
                    while (!isValidSalary)
                    {
                        if (int.TryParse(Console.ReadLine(), out int salary))
                        {
                            register.AddEmployee(new Employee(name, salary));
                            isValidSalary = true;
                        }
                        else
                        {
                            Console.WriteLine("ERROR: Please enter a valid number.");
                        }
                    }

                    Console.Clear();
                    Console.WriteLine("Added the following:\n" + register.GetLatestAdded());
                    break;
                case "2":
                    Console.Clear();
                    register.PrintRegister();
                    break;
                case "3":
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Please choose 1, 2 or 3.");
                    break;
            };
        }
    }
}

class Employee
{
    public string Name;
    public int Salary;

    public Employee(string name, int salary)
    {
        Name = name;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Salary: {Salary}";
    }
}

class Register
{
    private List<Employee> employees = new List<Employee>();

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
    }

    public Employee GetLatestAdded()
    {
        return employees.Last();
    }

    public void PrintRegister()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees added yet!");
        }
        else
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
