
// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;


// namespace CatWorx.BadgeMaker {

//   class Program {
  
//     // static List<Employee> GetEmployees()
//     // {
//     //   List<Employee> employees = new List<Employee>();
      
//     //   while(true) 
//     //   {
//     //     // Move the initial prompt inside the loop, so it repeats for each employee
//     //     Console.WriteLine("Enter first name (leave empty to exit): ");

//     //     // change input to firstName
//     //     string firstName = Console.ReadLine() ?? "";
//     //     if (firstName == "") 
//     //     {
//     //       break;
//     //     }

//     //     // add a Console.ReadLine() for each value
//     //     Console.Write("Enter last name: ");
//     //     string lastName = Console.ReadLine() ?? "";
//     //     Console.Write("Enter ID: ");
//     //     int id = Int32.Parse(Console.ReadLine() ?? "");
//     //     Console.Write("Enter Photo URL:");
//     //     string photoUrl = Console.ReadLine() ?? "";
//     //     Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
//     //     employees.Add(currentEmployee);
//     //     }

//     //     return employees;

//     // }

//     static void PrintEmployees(List<Employee> employees)
//     {
//       for (int i = 0; i < employees.Count; i++)
//       {
//         string template = "{0,-10}\t{1,-20}\t{2}";
//         // each item in employees is now an Employee instance
//         Console.WriteLine(employees[i].GetFullName());
//       }
//     }

//     static void Main(string[] args)
//       {
//         List<Employee> employees = new List<Employee>();
//         employees = await PeopleFetcher.GetFromApi();
//         Util.MakeCSV(employees);
//         Util.MakeBadges(employees);
        
//       }
//   }
// }

using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
           List<Employee> employees = new List<Employee>();
            Console.WriteLine("Would you like to enter employee information? (y/n): ");
            string response1 = Console.ReadLine();
            if (response1 == "y" || response1 == "yes" || response1 == "Yes")
            {
                employees = PeopleFetcher.GetEmployees();
                Util.PrintEmployees(employees);
                Util.MakeCSV(employees);
                Util.MakeBadges(employees);
            }

            Console.WriteLine("Would you like to fetch employee data from the API? (y/n): ");
            string response2 = Console.ReadLine();
            if (response2 == "y" || response2 == "yes" || response2 == "Yes")
            {
                employees = PeopleFetcher.GetFromAPI();
                Util.PrintEmployees(employees);
                Util.MakeCSV(employees);
                Util.MakeBadges(employees);
            }
        }
        
        static void PrintEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
                {
                    string template = "{0,-10}\t{1,-20}\t{2}";
                    // each item in employees is now an Employee instance
                    Console.WriteLine(employees[i].GetFullName());
                }
        }
    }
}