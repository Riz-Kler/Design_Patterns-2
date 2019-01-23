using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypeDemo
{
    class NullableTypeDemo
    {
        static void Main(string[] args)
        {
            int? x = null;

            if (!x.HasValue)
            {
                x = 10;
                Console.WriteLine("x.Value = " + x.Value);
            }
            else
            {
                x = x * x;
                Console.WriteLine("x.Value = " + x.Value);
            }

            int y = 5;
            x = y;
            y = (int)x;
            Console.WriteLine("y.Value = " + y);

            x = null;
            Console.WriteLine("x.Value = " + x.GetValueOrDefault());

        }
    }
}
