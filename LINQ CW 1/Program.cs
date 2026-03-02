namespace LINQ_CW_1
    Using Collections.Generic;
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ");
            int[] sevens = new int[]
                { 
                    7, 14, 21, 28, 35, 42, 49, 56, 63, 70 
                };
            int sum = sevens.Sum();
            int max = sevens.Max();
            double avg = sevens.Average();
        }
    }
}
