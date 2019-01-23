//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SingleCatchDemo1
//{
//    class SingleCatchDemo1
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
//            catch
//            {
//                Console.WriteLine("Inside single catch handler");
//            }
//        }
//        static void Main(string[] args)
//        {
//            Display(0, "Manchester");
//            Display(10, null);
//        }
//    }
//}
