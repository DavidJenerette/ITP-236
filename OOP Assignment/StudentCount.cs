namespace OOP_Assignment
{
    public class StudentCount
    {
        public int Count { get; private set; }

        public StudentCount(int initialCount = 0)
        {
            if (initialCount < 0) throw new System.ArgumentOutOfRangeException(nameof(initialCount), "Initial count cannot be negative.");
            //Lets the user know if that they cannot have a negative number of students.//
            Count = initialCount;
        }

        public void AddStudents(int number)
        {
            if (number < 0) throw new System.ArgumentOutOfRangeException(nameof(number), "Number to add cannot be negative.");
            //Lets the user know if that they cannot add a negative number of students.//
            Count += number;
        }

        public bool RemoveStudents(int number)
        {
            if (number < 0) throw new System.ArgumentOutOfRangeException(nameof(number), "Number to remove cannot be negative.");
            if (number > Count) return false; // Lets the user know if they are trying to remove more students than currently exist.//
            Count -= number;
            return true;
        }


        public void AddStudents()
        {
            int number;
            do
            {
                System.Console.WriteLine("Number of students to add: ");
                var input = System.Console.ReadLine();
                if (!int.TryParse(input, out number) || number < 0)
                {
                    System.Console.WriteLine("Please enter a non-negative integer.");
                    number = -1;
                }
            } while (number < 0);

            AddStudents(number);
        }

        public bool RemoveStudents()
        {
            int number;
            do
            {
                System.Console.WriteLine($"Number of students to remove (current: {Count}): ");
                var input = System.Console.ReadLine();
                if (!int.TryParse(input, out number) || number < 0)
                {
                    System.Console.WriteLine("Please enter a non-negative integer.");
                    number = -1;
                    continue;
                }

                if (number > Count)
                {
                    System.Console.WriteLine("Cannot remove more students than currently exist. Try again.");
                    number = -1;
                }
            } while (number < 0);

            return RemoveStudents(number);
        }

        public static StudentCount Students()
        {
            int initial;
            do
            {
                System.Console.WriteLine("Initial number of students: ");
                var input = System.Console.ReadLine()?.Trim();
                if (!int.TryParse(input, out initial) || initial < 0)
                {
                    System.Console.WriteLine("Please enter a non-negative integer.");
                    initial = -1;
                }
            } while (initial < 0);

            return new StudentCount(initial);
        }
        public override string ToString() => Count.ToString();
    }
}