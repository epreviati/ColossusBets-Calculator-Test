using System;
using System.Threading;
using ColossusBets.Calculator.DependencyResolver;
using ColossusBets.Calculator.Service;

namespace ColossusBets.Calculator.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = Bootstrapper.Boot();
            var service = container.Resolve<IServiceCalculator>();

            var i = 0;
            while (i < 10)
            {
                var input = (decimal) new Random().Next(1, 100000)/100;
                var result = service.GetSmallestCombination(input);
                System.Console.WriteLine("Input: {0}", input);
                System.Console.WriteLine("Result: {0}", result);
                System.Console.WriteLine();
                Thread.Sleep(500);
                i++;
            }

            var records = service.Gets();
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine();
            foreach (var record in records) System.Console.WriteLine(record.ToString());

            System.Console.ReadKey();
        }
    }
}