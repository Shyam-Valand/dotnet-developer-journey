using CSharpBasics;

public class Program
{
    private static void Main(string[] args)
    {
        // Variables & Data Types

        Console.WriteLine("Practice Variables & Data Types");
        Console.WriteLine("------------------------");
        string name = "Ayush";
        int age = 19;

        double salary = 25000.50;

        decimal price = 99.99m;

        bool isDeveloper = true;

        char grade = 'A';

        Console.WriteLine(name);
        Console.WriteLine(age);
        Console.WriteLine(salary);
        Console.WriteLine(price);
        Console.WriteLine(isDeveloper);
        Console.WriteLine(grade);

        Console.WriteLine("------------------------");
        StudentProfile.Run();
        Console.WriteLine("------------------------");
        UserRegistration.Run();
        Console.WriteLine("------------------------");
        SalaryCalculator.Run();
        Console.WriteLine("------------------------");
    }
}