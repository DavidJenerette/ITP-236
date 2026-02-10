namespace OOP_Assignment
{
    public class Subject
    {
        public string Name { get; private set; }

        public Subject(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new System.ArgumentException("Subject name cannot be empty.", nameof(name));
            Name = name;
        }

        public void Change(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName)) throw new System.ArgumentException("Subject name cannot be empty.", nameof(newName));
            //Lets the user know if that they cannot leave the subject name empty.//
            Name = newName;
        }

        public void ChangeSubject()
        {
            string newName;
            do
            {
                System.Console.WriteLine("Enter the subject ");
                newName = System.Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newName))
                {
                    System.Console.WriteLine("Subject name cannot be empty. Please try again.");
                    //Lets the user know if that they cannot leave the subject name empty.//
                }
            } while (string.IsNullOrWhiteSpace(newName));

            Name = newName;
        }

        public static Subject Subjects()
        {
            System.Console.WriteLine("Enter the new subject ");
            string name;
            do
            {
                name = System.Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name)) System.Console.WriteLine("Subject name cannot be empty.");
                //Lets the user know if that they cannot leave the subject name empty.//
            } while (string.IsNullOrWhiteSpace(name));

            return new Subject(name);
        }

        public override string ToString() => Name;
    }
}