//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SingleCatchDemo
//{
//    class SingleCatchDemo
//    {
//        static void Display(int value, String name)
//        {
//                try
//                {
//                    int num = 100;
//                    num = num / value;
//                    Console.WriteLine("Value = " + value);
//                    Console.WriteLine("Name Length = " + name.Length);
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine("Inside single catch handler1");
//                    Console.WriteLine("Exception Details =" + e);
//                }
//        }
//        static void Main(string[] args)
//        {
//            Display(0, "Manchester");
//            Display(10, null);
//        }
//    }
//}
