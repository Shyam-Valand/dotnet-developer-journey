namespace CSharpBasics
{
    public class SalaryCalculator
    {
        public static void Run()
        {
            Console.WriteLine("Salary Calculator");

            Console.Write("Enter Salary: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Bonus: ");
            decimal bonus = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Expenses: ");
            decimal expenses = Convert.ToDecimal(Console.ReadLine());


            decimal totalIncome = salary + bonus;

            decimal remaining = totalIncome - expenses;

            decimal yearlyIncome = totalIncome * 12;

            decimal dailyBudget = remaining / 30;

            Console.WriteLine();

            Console.WriteLine($"Total Income: {totalIncome}");
            Console.WriteLine($"Remaining Amount: {remaining}");
            Console.WriteLine($"Yearly Income: {yearlyIncome}");
            Console.WriteLine($"Daily Budget: {dailyBudget}");
        }
    }
}