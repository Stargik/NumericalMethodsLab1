using System.Text;

namespace CalcEqs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Метод релаксації: ");
            Ilogger logger = new ConsoleLogger();
            IEqsFunction eqsFunction = new RelaxationCalc(-4, -3.5, 3.75, 9d, 1E-4, false, logger);
            Console.WriteLine($"{new String(' ', 24)}Xn ## {new String(' ', 11)}|X(n) - X(n+1)|");
            double res = eqsFunction.Calc((x) => { return Math.Pow(x, 3) + 6 * Math.Pow(x, 2) + 9 * x + 2; }, -3.75);
            Console.WriteLine($"Результат: {res}");
            Console.WriteLine();

            Console.WriteLine("Модифікований метод Ньютона: ");
            eqsFunction = new ModNewtonCalc(-4, -3.5, (x) => { return 3 * Math.Pow(x, 2) + 12 * x + 9; }, 1E-4, logger);
            Console.WriteLine($"{new String(' ', 24)}Xn ## {new String(' ', 11)}|X(n) - X(n+1)|");
            res = eqsFunction.Calc((x) => { return Math.Pow(x, 3) + 6 * Math.Pow(x, 2) + 9 * x + 2; }, -3.75);
            Console.WriteLine($"Результат: {res}");
            Console.WriteLine();

            Console.WriteLine("Метод простої ітерації: ");
            eqsFunction = new SimpleIterationCalc(-4, -3.5, 0.583, 1E-4, logger);
            Console.WriteLine($"{new String(' ', 24)}Xn ## {new String(' ', 11)}|X(n) - X(n+1)|");
            res = eqsFunction.Calc((x) => { return (Math.Pow(x, 3) + 6 * Math.Pow(x, 2) + 2) / (-9); }, -3.75);
            Console.WriteLine($"Результат: {res}");
        }
    }
}