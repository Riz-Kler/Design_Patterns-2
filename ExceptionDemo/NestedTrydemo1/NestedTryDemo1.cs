//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NestedTryDemo1
//{
//    class NestedTryDemo1
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
//            catch (NullReferenceException e)
//            {
//                Console.WriteLine("Inside inner catch block");
//                Console.WriteLine("Exception Details =" + e);
//            }
//        }

//        static void Main(string[] args)
//        {
//            try
//            {
//                Display(10, null);
//                Display(0, "Manchester");
//            }

//            catch(DivideByZeroException e)
//            {
//                Console.WriteLine("Inside outer catch block");
//                Console.WriteLine("Exception Detail = " + e);
//            }
            
//        }
//    }
//}
