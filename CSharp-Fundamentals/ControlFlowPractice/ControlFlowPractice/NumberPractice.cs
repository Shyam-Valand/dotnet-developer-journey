namespace ControlFlowPractice
{
    public class NumberPractice
    {
        public static void Run()
        {
            //For loop practice
            Console.WriteLine("____ for loop to print numbers ____");
            Console.WriteLine("Numbers 1 to 10");
            Console.WriteLine("------------------------");


            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("____ for loop to print even numbers ____");


            Console.WriteLine("Even Numbers");
            Console.WriteLine("------------------------");


            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }

            //While loop practice
            Console.WriteLine("____ While loop practice ____");
            Console.WriteLine("Password Retry System");
            Console.WriteLine("------------------------");


            string password = "12345";

            int attempts = 0;


            while (attempts < 3)
            {
                Console.Write("Enter Password: ");

                string input = Console.ReadLine() ?? "";


                if (input == password)
                {
                    Console.WriteLine("Login Successful");
                    break;
                }
                else
                {
                    attempts++;

                    Console.WriteLine("Try Again");
                }
            }


            if (attempts == 3)
            {
                Console.WriteLine("Account Locked");
            }


            Console.WriteLine("------------------------");
        }
    }
}