namespace CSharpBasics
{
    public class UserRegistration
    {
        public static void Run()
        {
            // User Registration Console App
            Console.WriteLine("User Registration Console App");

            Console.Write("Enter Name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter Email: ");
            string email = Console.ReadLine() ?? "";

            Console.Write("Enter Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine("User Created Successfully");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Email: " + email);
            Console.WriteLine("Age: " + age);
        }
    }
}
