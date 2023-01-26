using System;
using System.Collections.Generic;

// namespace CatWorx.BadgeMaker {
//   class Employee
//   {
//     private string FirstName;
//     private string LastName;
//     private int Id;
//     private string PhotoUrl;
//     public Employee(string firstName, string lastName, int id, string photoUrl) {
//         FirstName = firstName;
//         LastName = lastName;
//         Id = id;
//         PhotoUrl = photoUrl;
//     }
//     public string GetFullName() {
//         return  FirstName + " " + LastName;
//     }
  
//     public int GetId() {
//         return Id;
//     }
//     public string GetPhotoUrl() {
//         return PhotoUrl;
//     }
//     public string GetCompanyName() {
//      return "Cat Worx";
//     }  

//   }
// }

namespace CatWorx.BadgeMaker
{
    class Employee 
    {
        public string FirstName;
        public string LastName;
        public int Id;
        public string PhotoUrl;
        public Employee(string firstName, string lastName, int id, string photoUrl) {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            PhotoUrl = photoUrl;
        }
        public string GetFullName() {
            return FirstName + " " + LastName;
        }
        public int GetId() {
            return Id;
        }
        public string GetPhotoUrl() {
            return PhotoUrl;
        }
        public string GetCompanyName() {
            return "Cat Worx";
        }
    }
}