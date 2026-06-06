namespace ControlFlowPractice
{
    public class GradeCalculator
    {
        public static void Run()
        {
            Console.WriteLine("Student Grade Calculator");

            Console.Write("Enter Marks: ");
            int marks = Convert.ToInt32(Console.ReadLine());

            if (marks >= 90)
            {
                Console.WriteLine("Grade: A+");
            }
            else if (marks >= 80)
            {
                Console.WriteLine("Grade: A");
            }
            else if (marks >= 70)
            {
                Console.WriteLine("Grade: B");
            }
            else if (marks >= 60)
            {
                Console.WriteLine("Grade: C");
            }
            else
            {
                Console.WriteLine("Result: Fail");
            }
        }
    }
}