namespace ControlFlowPractice
{
    public class LoginSystem
    {
        public static void Run()
        {
            Console.WriteLine("Login System");

            string correctEmail = "admin@test.com";
            string correctPassword = "12345";


            Console.Write("Enter Email: ");
            string email = Console.ReadLine() ?? "";


            Console.Write("Enter Password: ");
            string password = Console.ReadLine() ?? "";


            bool isValid =
                email == correctEmail &&
                password == correctPassword;


            if (isValid)
            {
                Console.WriteLine("Login Successful");
            }
            else
            {
                Console.WriteLine("Invalid Credentials");
            }
        }
    }
}