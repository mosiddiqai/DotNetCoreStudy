using System;

namespace fibo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fibonesis series to Level 10!");

            int inc = 0;

            if (args.Length >1)
            {
                int i1 = int.Parse(args[0]);
                int i2 = int.Parse(args[1]);

                Console.WriteLine($"current number : {i1}");
                Console.WriteLine($"current number : {i2}");

                while (inc < 8)
                {
                    i2 = i1 + i2;
                    i1 = i2 - i1;

                    Console.WriteLine($"current number : {i2}");

                    inc++;
                }
            }
        }
    }
}
