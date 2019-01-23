using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This program demonstrates the Func and Action delegate with the Lambda Expression
namespace LambdaExpressionFuncAndActionDemo
{
    class LambdaExpressionFuncAndActionDemo
    {
        static void Main(string[] args)
        {
            Func<int, int, bool> compareDelegate = (x, y) => x > y;
            Console.WriteLine("compareDelegate(10, 5) = " + compareDelegate(10, 5));

            Action<int, int> dispParamDelegate = (x, y) => { Console.WriteLine("x = " + x + ", y = " + y); };
            dispParamDelegate(20, 10);
        }
    }
}
