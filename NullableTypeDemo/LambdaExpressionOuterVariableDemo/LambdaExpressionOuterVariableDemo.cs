using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// To demonstrate Outer Variable in Lambda Expression
namespace LambdaExpressionOuterVariableDemo
{
    delegate int MyDelegate(int value);
    class LambdaExpressionOuterVariableDemo
    {
        static void Main(string[] args)
        {
            int y = 5; // this is no ignored

            MyDelegate exprDelegate = (int x) =>
                                                {
                                                    return x * y++;
                                                };

            y = 6;   //Outer Variable
            Console.WriteLine("Expression Value = " + exprDelegate(10));
            Console.WriteLine("Expression Value = " + exprDelegate(10));
        }
    }
}
