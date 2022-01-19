using System;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = FibionacciRecursion(50);
            Console.WriteLine();
        }

        public static int FibionacciRecursion(int n) 
        {
            if (n <= 2)
                return 1;

            return FibionacciRecursion(n - 1) + FibionacciRecursion(n - 2);
        }
    }
}
