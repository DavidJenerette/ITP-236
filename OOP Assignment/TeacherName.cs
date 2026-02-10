namespace OOP_Assignment
{
    public class TeacherName
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public TeacherName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new System.ArgumentException("First name cannot be empty.", nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName)) throw new System.ArgumentException("Last name cannot be empty.", nameof(lastName));
            //Lets the user know if that they cannot leave the first name or last name empty.//
            FirstName = firstName;
            LastName = lastName;
        }

        public void UpdateName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new System.ArgumentException("First name cannot be empty.", nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName)) throw new System.ArgumentException("Last name cannot be empty.", nameof(lastName));
            //Lets the user know if that they cannot leave the first name or last name empty.//
            FirstName = firstName;
            LastName = lastName;
        }

        public void UpdateName()
        {
            string first;
            do
            {
                System.Console.WriteLine("Please enter the teacher's first name: ");
                first = System.Console.ReadLine();
                if (string.IsNullOrWhiteSpace(first))
                {
                    System.Console.WriteLine("First name cannot be empty. Please try entering the information again.");
                    //Lets the user know if that they cannot leave the first name or last name empty.//
                }
            } while (string.IsNullOrWhiteSpace(first));

            string last;
            do
            {
                System.Console.WriteLine("Please enter the teacher's last name: ");
                last = System.Console.ReadLine();
                if (string.IsNullOrWhiteSpace(last))
                {
                    System.Console.WriteLine("Last name cannot be empty. Please try entering the information again.");
                    //Lets the user know if that they cannot leave the first name or last name empty.//
                }
            } while (string.IsNullOrWhiteSpace(last));

            FirstName = first;
            LastName = last;
        }
        public static TeacherName Teacher()
        {
            System.Console.WriteLine("Please add a teacher:");
            string first;
            do
            {
                System.Console.WriteLine("Please enter the new teacher's first name");
                first = System.Console.ReadLine();
                if (string.IsNullOrWhiteSpace(first)) System.Console.WriteLine("First name cannot be empty.");
            } while (string.IsNullOrWhiteSpace(first));

            string last;
            do
            {
                System.Console.WriteLine("Please enter the new teacher's last name ");
                last = System.Console.ReadLine();
                if (string.IsNullOrWhiteSpace(last)) System.Console.WriteLine("Last name cannot be empty.");
            } while (string.IsNullOrWhiteSpace(last));

            return new TeacherName(first, last);
        }
        public string FullName() => $"{FirstName} {LastName}";

        public override string ToString() => FullName();
    }
}