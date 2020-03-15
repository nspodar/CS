using System;

namespace Part2
{
    class Program
    {
        static string generate_number(Int64 num)
        {
            string str = Convert.ToString(num, 2);
            str = str.PadLeft(64, '0');
            return str;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a first number ");
            string remainder = Console.ReadLine();
            Console.WriteLine("Enter a second number");
            string divisior = Console.ReadLine();
            Int64 ff = Int32.Parse(remainder);
            Int64 ss = Int32.Parse(divisior);
            ss <<= 32;
            bool setRemLSBToOne = false;
            for (int i = 0; i <= 32; i++)
            {
                Console.WriteLine($"Step {i + 1} ");
                if (ss <= ff)
                {
                    ff -= ss;
                    setRemLSBToOne = true;
                    Console.Write("less");
                }
                else
                    Console.Write("more");
                Console.WriteLine(" than remainder.");
                Console.WriteLine("Shift remainder left one bit.");
                ff <<= 1;
                if (setRemLSBToOne)
                {
                    setRemLSBToOne = false;
                    ff |= 1; //lsb - 1
                    Console.WriteLine("Set remainder lsb to 1");
                }
                Console.WriteLine();
                Console.WriteLine($"Remaiderandquatient \n {generate_number(ff)}");
                Console.WriteLine($"Divisior \n {generate_number(ss)}");
            }
            long quotient = ff & ((long)Math.Pow(2, 33) - 1);
            long rem = ff >> 33;
            Console.WriteLine("Quotient:\n" + generate_number(quotient) +
            " ( " + quotient + " )\n");

            Console.WriteLine("Remainder:\n" + generate_number(rem) +
            " ( " + rem + " )");
        }
    }
}
