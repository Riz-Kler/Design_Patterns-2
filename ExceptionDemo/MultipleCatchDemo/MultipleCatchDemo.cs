//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MultipleCatchDemo
//{
//    class MultipleCatchDemo
//    {
//        static void Display(int value, String name)
//        {
//            try
//            {
//                int num = 100;
//                num = num / value;
//                Console.WriteLine("Value = " + value);
//                Console.WriteLine("Name Length = " + name.Length);
//            }
//            catch (NullReferenceException e)
//            {
//                Console.WriteLine("Inside catch handler1");
//                Console.WriteLine("Exception Details =" + e);
//            }
//            catch (DivideByZeroException e)
//            {
//                Console.WriteLine("Inside catch handler2");
//                Console.WriteLine("Exception Detail = " + e);
//            }
//        }
//        static void Main(string[] args)
//        {
//            Display(0, "Manchester");
//            Display(10, null);
//        }
//    }
//}
