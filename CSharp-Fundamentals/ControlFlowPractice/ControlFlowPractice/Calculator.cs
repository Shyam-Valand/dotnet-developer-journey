namespace ControlFlowPractice
{
    public class Calculator
    {
        public static void Run()
        {
            Console.WriteLine("Calculator");

            Console.Write("Enter First Number: ");
            int number1 = Convert.ToInt32(Console.ReadLine());


            Console.Write("Enter Second Number: ");
            int number2 = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Multiply");
            Console.WriteLine("4. Divide");


            Console.Write("Choose Option: ");
            int choice = Convert.ToInt32(Console.ReadLine());


            switch (choice)
            {
                case 1:
                    Console.WriteLine(number1 + number2);
                    break;


                case 2:
                    Console.WriteLine(number1 - number2);
                    break;


                case 3:
                    Console.WriteLine(number1 * number2);
                    break;


                case 4:
                    if (number2 != 0)
                    {
                        Console.WriteLine(number1 / number2);
                    }
                    else
                    {
                        Console.WriteLine("Cannot divide by zero");
                    }

                    break;

                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        }
    }
}