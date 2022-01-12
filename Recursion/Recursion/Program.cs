using System;
using System.Numerics;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayReverse("Uche");
            Console.WriteLine();
        }

        public static int Count = 0;
        public static int result = 0;

        public static string Counter() 
        {
           if(Count > 3)
            {
                return "done";
            }
            Count++;
            return Counter();
        }

        public static BigInteger NormalFactorial(int number) 
        {
            BigInteger result = 1;
            for (int i = number; i > 0; i--)
            {
                result *= i;
            }

            return result;
        }

        public static BigInteger RecursiveFactorial(BigInteger number)
        {
            if (number == 0) return 1;
            return number * RecursiveFactorial((number-1));
        }

        public static int FibionacciIterative(int n) 
        {
            var res = 0;
            for(int i = 1; i < n; i++) 
            {
                res += i-1;
            }
            return res;
        }

        public static int FibionacciRecursive(int n) 
        {
            if (n < 2)
                return n;
            return FibionacciRecursive(n-1) + FibionacciRecursive(n-2);
        }

        public static void DisplayReverse(string str)
        {
            if (str.Length > 0)
                DisplayReverse(str.Substring(1, str.Length - 1));
            else
                return;
            Console.Write(str[0]);
        }
    }

    
}
