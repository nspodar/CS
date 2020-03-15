using System;

namespace CS_Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("First number");
            Int32 multiplicand = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Second number");
            Int32 multiplier = Convert.ToInt32(Console.ReadLine());
            Int64 product = 0;
            for (int i = 32; i > 0; i--)
            {
                if ((multiplier & 1) == 1)
                {
                    product += (((long)multiplicand << 32));
                    product >>= 1;
                }
                else
                    product >>= 1;
                multiplier >>= 1;
                String result = Convert.ToString(product, 2);
                result = new string('0', 64 - result.Length) + result;
                Console.WriteLine(result);
            }
            Console.WriteLine("Result = " + product);
        }
    }
}
