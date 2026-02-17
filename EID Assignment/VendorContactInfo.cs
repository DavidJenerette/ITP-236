using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EID_Assignment
{/// Represents the contact information of a vendor, including their first name, last name, age, and email address.
    public class VendorContactInfo : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public VendorContactInfo(string firstName, string lastName, int age, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
        }
        ///Displays the contact information of the vendor in a formatted manner, including their first name, last name, age, and email address.
        public void DisplayInfo()
        {
            Console.WriteLine("Vendor Contact Information:");
            Console.WriteLine($"First Name: {FirstName}");
            Console.WriteLine($"Last Name: {LastName}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Email: {Email}");
        }
    }
}
