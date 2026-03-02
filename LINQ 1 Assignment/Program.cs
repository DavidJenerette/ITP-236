using LINQ_1;

namespace LINQ_1_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Customer Sales Order Data Summary");
            Console.WriteLine("=================================");
            var customers = CustomerData.Customers;
            foreach (var customer in customers)
            {
                Display(customer);
            }
            Console.WriteLine("============================");
            Console.WriteLine("Press any key to continue..."); 
            Console.WriteLine("============================");  Console.ReadKey();
            var AllSalesOrders = customers.SelectMany(c => c.SalesOrders);
            double OverallAverage = AllSalesOrders.Any() ? AllSalesOrders.Average(o => o.OrderTotal) : 0;
            Console.WriteLine("Average order size of all customers currently: ");
            Console.WriteLine($"Overall Average Order Total: {OverallAverage:C}");
            Console.WriteLine("============================");
            Console.WriteLine("Press any key to continue..."); 
            Console.WriteLine("============================");  Console.ReadKey();
            var HighestCustomer = customers
                .OrderByDescending(c => c.OrderTotal)
                .First();
            Console.WriteLine("The customer with the highest order total is: ");
            Console.WriteLine($"Customer With Highest Order Total: {HighestCustomer.Name} ({HighestCustomer.OrderTotal:C})");
        }
        static void Display(Customer customer)
        {
            Console.WriteLine($"Customer: {customer.Name}");
            Console.WriteLine($"Total Order Amount: {customer.OrderTotal:C}");
            Console.WriteLine($"BackOrdered Quantity: {customer.BackOrdered}");
            double averageOrder = customer.SalesOrders.Any() ? customer.SalesOrders.Average(so => so.OrderTotal) : 0;
            Console.WriteLine($"Average Order Total: {averageOrder:C}");
        }
    }
}
