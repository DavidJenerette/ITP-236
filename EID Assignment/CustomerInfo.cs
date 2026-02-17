using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EID_Assignment
{/// Represents the information of a customer, including their first name, last name, age, and email address.
    public class CustomerInfo : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public CustomerInfo(string firstName, string lastName, int age, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
        }
        /// Displays the information of the customer in a formatted manner, including their first name, last name, age, and email address.
        public void DisplayInfo()
        {
            Console.WriteLine("Customer Information:");
            Console.WriteLine($"First Name: {FirstName}");
            Console.WriteLine($"Last Name: {LastName}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Email: {Email}");
        }
    }
}
