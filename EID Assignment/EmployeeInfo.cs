using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EID_Assignment
{/// Represents the information of an employee, including their first name, last name, age, and email address.
    public class EmployeeInfo : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public EmployeeInfo(string firstName, string lastName, int age, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
        }
        /// Displays the information of the employee in a formatted manner, including their first name, last name, age, and email address.
        public void DisplayInfo()
        {
            Console.WriteLine("Employee Information:");
            Console.WriteLine($"First Name: {FirstName}");
            Console.WriteLine($"Last Name: {LastName}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Email: {Email}");
        }
    }
}
