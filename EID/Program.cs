using System.ComponentModel.DataAnnotations;

namespace EID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello".IsCapitalized());
            Console.WriteLine("David Jenerette".Left(5));
            Console.WriteLine("David Jenerette".Right(9));
            var consumer = new Consumer
            {
                Name = "Alice",
                ConsumerId = 123,
                TotalAmount = 456.78
            };
            var vendor = new Vendor
            {
                Name = "Bob's Supplies",
                VendorId = 456,
                TotalAmount = 789.01
            };
            var associates = new List<IBusinessAssociate> { consumer, vendor };
        }
        delegate int Numbers(int[] numbers);
        int[] numbers = [ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        int sumArray(int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum;
        }
        Numbers del = new Numbers(sumArray);
    }
}
