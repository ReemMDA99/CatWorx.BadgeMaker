// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    static void Main(string[] args)
    {
    //   string greeting = "Hello";
    //     greeting = greeting + "World";
    //     // Console.WriteLine("greeting" + " " + greeting);   
    //     //Console.WriteLine($"greeting: {greeting}"); 
    //     Console.WriteLine("greeting: {0}", greeting);
    
    // How do you find the area of a square? Area = side * side
        // double side = 3.14;
        // double area = side * side;
        // Console.WriteLine("area is a {0}", area.GetType());
       
    //    bool isCold = true;
    //     Console.WriteLine(isCold ? "drink" : "add ice");  // output: drink
    //     Console.WriteLine(!isCold ? "drink" : "add ice");  // output: add ice
        // string stringNum = "2";
        // int intNum = Convert.ToInt32(stringNum);
        // Console.WriteLine(intNum);
        // Console.WriteLine(intNum.GetType());
        // Dictionary<string, int> myScoreBoard = new Dictionary<string, int>(){
        //     { "firstInning", 10 },
        //     { "secondInning", 20},
        //     { "thirdInning", 30},
        //     { "fourthInning", 40},
        //     { "fifthInning", 50}
        // };
        // Console.WriteLine("----------------");
        // Console.WriteLine("  Scoreboard");
        // Console.WriteLine("----------------");
        // Console.WriteLine("Inning |  Score");
        // Console.WriteLine("   1   |    {0}", myScoreBoard["firstInning"]);
        // Console.WriteLine("   2   |    {0}", myScoreBoard["secondInning"]);
        // Console.WriteLine("   3   |    {0}", myScoreBoard["thirdInning"]);
        // Console.WriteLine("   4   |    {0}", myScoreBoard["fourthInning"]);
        // Console.WriteLine("   5   |    {0}", myScoreBoard["fifthInning"]);
        
//         string[] favFoods = new string[3]{ "pizza", "doughnuts", "icecream" };
// string firstFood = favFoods[0];
// string secondFood = favFoods[1];
// string thirdFood = favFoods[2];
// Console.WriteLine("I like {0}, {1}, and {2}", firstFood, secondFood, thirdFood);

List<string> employees = new List<string>() { "adam", "amy" };

employees.Add("barbara");
employees.Add("billy");
// Console.WriteLine("My employees include {0}, {1}, {2}, {3}", employees[0], employees[1], employees[2], employees[3]);
for (int i = 0; i < employees.Count; i++) 
{
  Console.WriteLine(employees[i]);
}
    }
    }
}