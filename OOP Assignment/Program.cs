namespace OOP_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var teacher = TeacherName.Teacher();
            var students = StudentCount.Students();
            var subject = Subject.Subjects();

            System.Console.WriteLine($"Teacher: {teacher.FullName()}");
            System.Console.WriteLine($"Subject: {subject}");
            System.Console.WriteLine($"Students: {students}");
            Console.WriteLine("Press ENTER to continue");
            Console.ReadKey();
            System.Console.WriteLine("Update teacher name:");
            teacher.UpdateName();

            System.Console.WriteLine("Add students:");
            students.AddStudents();

            System.Console.WriteLine("Remove students:");
            var removed = students.RemoveStudents();

            System.Console.WriteLine("Change subject:");
            subject.ChangeSubject();

            System.Console.WriteLine("After updates:");
            System.Console.WriteLine($"Teacher: {teacher}");
            System.Console.WriteLine($"Subject: {subject}");
            System.Console.WriteLine($"Students: {students}");
            Console.WriteLine("Press ENTER to continue");
            Console.ReadKey();
        }
    }
}
