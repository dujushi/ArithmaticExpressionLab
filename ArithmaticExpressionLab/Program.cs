using System;
using System.Linq.Expressions;
using ArithmaticExpressionLab.Business;

namespace ArithmaticExpressionLab
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Console.WriteLine("Please enter an arithmatic expression:");
                    var expressionText = Console.ReadLine();
                    var expression = ArithmaticExpressionParser.Parse(expressionText);
                    var result = Expression.Lambda<Func<int>>(expression).Compile()();
                    Console.WriteLine($"Result: {result}");
                }
                catch (ArithmaticExpressionException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
            } while (true);
        }
    }
}
