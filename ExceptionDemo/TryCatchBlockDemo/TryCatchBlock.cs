//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TryCatchBlockDemo
//{
//    class TryCatchBlock
//    {
//        static void Display(int value)
//        {
//            int num = 100;
//            try
//            {
//                num = num / value;
//                Console.WriteLine("Value = " + value);
//            }
//            catch(DivideByZeroException e)
//            {
//                Console.WriteLine("Inside catch block to handle the exception");
//                Console.WriteLine("Exception Details = " + e);
//            }
//        }
//        static void Main(string[] args)
//        {
//            Display(10);
//            Display(0);

//        }
//    }
//}
