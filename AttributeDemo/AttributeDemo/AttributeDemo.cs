using System;

// To demonstrate the use of Attribute

namespace AttributeDemo
{
    class SumOfN
    {
        [Obsolete("Please use the method sumOfNLong", true)]
        public int sumOfNInt(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum = +1;
            }
            return sum;
        }

        public long sumOfNLong(long n)
        {
            return (n * (n + 1)) / 2;
        }
    }
    class AttributeDemo
    {
        static void Main(string[] args)
        {
            SumOfN obj = new SumOfN();
            Console.WriteLine(obj.sumOfNInt(10));
            Console.WriteLine(obj.sumOfNLong(100));
        }
    }
}
