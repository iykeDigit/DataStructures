using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAndQueue
{
    public class Stack
    {
        int[] stackArr;
        int capacity;
        int numElements;

        public Stack(int size)
        {
            capacity = size;
            stackArr = new int[size];
            numElements = 0;
            Debug.Assert(stackArr != null);
        }

        public bool IsEmpty() 
        {
            return numElements == 0;
        }

        public int GetTop() 
        {
            return (numElements == 0 ? -1 : stackArr[numElements - 1]);
        }

        public bool Push(int value) 
        {
            if(numElements < capacity) 
            {
                stackArr[numElements] = value;
                numElements++;
                return true;
            }
            else 
            {
                Console.WriteLine("Stack Overflow");
                return false;
            }
        }

        public int Pop() 
        {
            if(numElements == 0) 
            {
                Console.WriteLine("Stack Empty");
                return -1;
            }
            else 
            {
                numElements--;
                return stackArr[numElements];
            }
        }

        public int GetSize() 
        {
            return numElements;
        }

        public void ShowStack() 
        {
            int i = 0;
            while(i < numElements) 
            {
                Console.WriteLine($"Printing {numElements - (i + 1)}");
                Console.WriteLine("\t" + stackArr[numElements-(1+i)]);
                i++;
            }
            Console.WriteLine("");
        }
    }
}
