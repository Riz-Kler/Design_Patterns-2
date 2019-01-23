//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NestedTryDemo
//{
//    class NestedTryDemo
//    {
//        static void Display(int value, String name)
//        {
//            try
//            {
//                int num = 100;
//                try
//                {
//                    num = num / value;
//                    Console.WriteLine("Value = " + value);
//                    Console.WriteLine("Name Length = " + name.Length);
//                }
//                catch (NullReferenceException e)
//                {
//                    Console.WriteLine("Inside inner catch block");
//                    Console.WriteLine("Exception Details =" + e);
//                }
//            }
//            catch (DivideByZeroException e)
//            {
//                Console.WriteLine("Inside catch block to handle the exception");
//                Console.WriteLine("Exception Details = " + e);
//            }
//        }
//            static void Main(string[] args)
//        {
//            Display(0, "Manchester");
//            Display(10, null);
//        }
//    }
//}
