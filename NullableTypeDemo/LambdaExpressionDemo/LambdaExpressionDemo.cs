using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressionDemo
{
    class LambdaExpressionDemo
    {
        delegate int MyDelegate(int value);

        //static int EvaluationExpression(int value)
        //{
        //    return value * value;
        //}

        static void Main(string[] args)
        {
            MyDelegate exprDelegate = x => x * x; //EvaluationExpression;
            Console.WriteLine("Expression Value = " + exprDelegate(10));
        }
    }
}
