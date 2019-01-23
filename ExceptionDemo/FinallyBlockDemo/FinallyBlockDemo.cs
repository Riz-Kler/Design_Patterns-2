//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FinallyBlockDemo
//{
//    class FinallyBlockDemo
//    {
//        static void Display(int value, String name)
//        {
//            int num = 100;
//            try
//            {
//                num = num / value;
//                Console.WriteLine("Value = " + value);
//                Console.WriteLine("Name Length = " + name.Length);
//            }

//            catch (DivideByZeroException e)
//            {
//                Console.WriteLine("Inside catch handler2");
//                Console.WriteLine("Exception Detail = " + e);
//            }

//            catch (NullReferenceException e)
//            {
//                Console.WriteLine("Inside catch handler1");
//                Console.WriteLine("Exception Details =" + e);
//            }

//            finally
//            {
//                Console.WriteLine("Inside finally block");
//            }
//        }
//        static void Main(string[] args)
//        {
//            Display(0, "Bangalore");
//            Display(10, null);
//            Display(10, "Manchester");
//        }
//    }
//}
