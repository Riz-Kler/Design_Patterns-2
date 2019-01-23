//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//Extension Method with a string

//namespace ExtensionMethodDemo
//{
//    static class CommonTools
//    {
//        public static String NewMethod(this String text)
//        {
//            Console.WriteLine("Inside NewMethod, Text = " + text);
//                return text + " Bond 007";
//        }
//    }
//    class ExtensionMethodDemo
//    {
//        static void Main(string[] args)
//        {
//            String name = "James";
//            Console.WriteLine("Using Extension Method name.NewMethod() : " + name.NewMethod());
//            Console.WriteLine("Using Extension Method name.NewMethod() : " + "James".NewMethod());
//        }
//    }
//}
