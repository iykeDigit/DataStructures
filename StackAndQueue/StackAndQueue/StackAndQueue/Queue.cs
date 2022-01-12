using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAndQueue
{
    public class Queue
    {
        DoublyLinkedList items = new DoublyLinkedList();
        int numElements;

        public Queue()
        {
            this.numElements = 0;
        }

        public bool isEmpty()
        {
            return (numElements == 0);
        }

        public int GetFront() 
        {
            return items.GetHead();
        }

        public int GetTail() 
        {
            return items.GetLast();
        }

        public int Enqueue(int value) 
        {
            numElements++;
            return items.InsertTail(value);
        }

        public bool Dequeue() 
        {
            numElements--;
            return items.DeleteHead();
        }

        public int GetSize() 
        {
            return numElements;
        }

        public bool ShowQueue()
        {
            return items.PrintList();
        }

    }
}
