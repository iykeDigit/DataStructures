using System;
using System.Collections.Generic;

namespace StackAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = 2;
            string binary = Convert.ToString(value, 2);
            // binary to base 10
            int values = Convert.ToInt32("1000", 2);

            // var x = Binary(10);
            Queue<int> callerIds = new Queue<int>();
            callerIds.Enqueue(1);
            callerIds.Enqueue(2);
            callerIds.Enqueue(3);
            callerIds.Enqueue(4);
            callerIds.Enqueue(5);
            callerIds.Enqueue(6);
            callerIds.Enqueue(7);
            callerIds.Enqueue(8);

            var arr = new int[] { 1, 2, 3, 4, 5, 6,7 };

            var x = BalancedParenthesis("{[()]}");
            Console.WriteLine();

        }

        public static string[] Binary(int n) 
        {
            Stack<string> myStack = new Stack<string>();
            var arr = new String[n];

            for(int i = 1; i < n+1; i++) 
            {
                var m = Convert.ToString(i, 2);
                myStack.Push(m);
            }

            for(var i  = n-1; i >= 0; i--) 
            {
                arr[i] = myStack.Pop();
            }

            return arr;
        }

        public static Queue<int> ReverseK(Queue<int> queue, int k)
        {
            var stack = new Stack<int>();
            int count = 0;

            while(count < k) 
            {
                stack.Push(queue.Dequeue());
                count++;
            }

            while(stack.Count != 0) 
            {
                queue.Enqueue(stack.Pop());
            }

            for(int i = 0; i < k; i++) 
            {
                queue.Enqueue(queue.Dequeue());
            }

            return queue;

            }

        public static int[] ReverseArray(int[] arr, int k) 
        {
            int first = 0;
            int last = k - 1;
            int temp = 0;

            while(first <= last) 
            {
                temp = arr[last];
                arr[last] = arr[first];
                arr[first] = temp;
                last--;
                first++;
            }

            return arr;
        }

        public static bool BalancedParenthesis(string exp) 
        {
            
            if (exp.Length == 0)
                return false;

            var stack = new Stack<char>();

            for (int i = 0; i < exp.Length; i++) 
            {
                if(exp[i] == '}' || exp[i] == ')' || exp[i] == ']') 
                {
                    if (stack.Count == 0)
                        return false;

                    else if(exp[i] == '}' && stack.Pop() != '{' || exp[i] == ')' && stack.Pop() != '(' || exp[i] == ']' && stack.Pop() != '[') 
                    {
                        return false;
                    }
                }

                else 
                {
                    stack.Push(exp[i]);
                }
            }

            return stack.Count == 0;
        }

    }
}
