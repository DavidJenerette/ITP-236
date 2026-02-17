namespace EID_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /// Demonstrates the usage of extension methods for string and integer types. 
            /// It prompts the user to enter a name and an odd number, then applies the ProperName and IsOdd extension methods to display the results.
            /// Finally, it creates instances of EmployeeInfo, CustomerInfo, and VendorContactInfo classes to display their contact information.
            Console.WriteLine("Please enter a name:");
            string name = Console.ReadLine();
            Console.WriteLine(name.ProperName());
            Console.WriteLine("Please enter an odd number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(number.IsOdd());
            Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();

            Console.WriteLine("\nDisplaying contact info of personel:");
            EmployeeInfo employee = new EmployeeInfo("John", "Doe", 37, "JohnDoe@Example.com");
            CustomerInfo customer = new CustomerInfo("Jane", "Smith", 23, "JaneS@Fakemail.com");
            VendorContactInfo vendor = new VendorContactInfo("Bob", "Johnson", 44, "JohnsonBob@Contact.com");
            employee.DisplayInfo();
            customer.DisplayInfo();
            vendor.DisplayInfo();
        }
    } 
}
