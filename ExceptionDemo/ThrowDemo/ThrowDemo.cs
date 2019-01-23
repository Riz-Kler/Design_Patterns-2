//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ThrowDemo
//{
//    class ThrowDemo
//    {
//        static void Display(int value, String name)
//        {
//            int num = 100;
//            try
//            {
//                if (value == 0)
//                    throw new DivideByZeroException();

//                num = num / value;
//                Console.WriteLine("Value = " + value);

//                if (name == null)
//                    throw new NullReferenceException();

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
//                Console.WriteLine("Exception Details = " + e);
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
