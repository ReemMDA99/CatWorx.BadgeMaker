using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    
      // MAIN
     async static Task Main(string[] args)
    {
        // employee class 
        Console.Write("Would you like to randomly generate [1] or manually generate [2] ? (please press 1 or 2, leave empty to exit)");
        string userInput = Console.ReadLine() ?? "";
        if(userInput == "1"){
          List<Employee> employees = await PeopleFetcher.GetFromApi();
          Util.PrintEmployees(employees);
        Util.MakeCSV(employees);
        await Util.MakeBadges(employees);
        } if(userInput == ""){
          return;
        } else {
          List<Employee> employees =  PeopleFetcher.GetEmployees();
          Util.PrintEmployees(employees);
        Util.MakeCSV(employees);
        await Util.MakeBadges(employees);

        }

        
    }
  }
}