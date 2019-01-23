using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Extension Method with a parameter

namespace ExtensionMethodDemo1
{
    static class CommonTools
    {
        public static String NewMethod(this String text, String lastName)
        {
            Console.WriteLine("Inside NewMethod, Text = " + text);
            return text + lastName;
        }
    }
    class ExtensionMethodDemo
    {
        static void Main(string[] args)
        {
            String firstName = "James";
            Console.WriteLine("Using Extension Method firstName.NewMethod() : " + firstName.NewMethod(" Bond 007"));
        }
    }
}
