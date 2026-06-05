namespace CSharpBasics
{
    public class StudentProfile
    {
        public static void Run()
        {
            Console.WriteLine("Student Profile Program");

            string name = "Shyam Valand";
            int age = 23;
            string degree = "MCA";
            string role = ".NET Developer";

            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Degree: " + degree);
            Console.WriteLine("Role: " + role);

            Console.WriteLine();
            Console.WriteLine("Skills:");

            string skill1 = "C#";
            string skill2 = "SQL";
            string skill3 = "ASP.NET Core";

            Console.WriteLine(skill1);
            Console.WriteLine(skill2);
            Console.WriteLine(skill3);

            double salary = 18000.00;
            decimal coursePrice = 499.99m;
            bool isDeveloper = true;
            char grade = 'A';

            Console.WriteLine(salary);
            Console.WriteLine(coursePrice);
            Console.WriteLine(isDeveloper);
            Console.WriteLine(grade);

        }
    }
}
