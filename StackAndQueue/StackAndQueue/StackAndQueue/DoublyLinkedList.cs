using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAndQueue
{
    public class DoublyLinkedList
    {
        public class Node
        {
            public int data;
            public Node NextElement;
            public Node PreviousElement;

            public Node(int data)
            {
                this.data = data;
                NextElement = null;
            }
        };

        Node Head;
        Node Last;
        int Length;

        public DoublyLinkedList()
        {
            Head = null;
            Last = null;
            Length = 0;
        }

        public bool IsEmpty() 
        {
            if (Head == null)
                return true;
            else
                return false;
        }

        public int GetHead() 
        {
            if(!(Head == null)) 
            {
                return Head.data;
            }
            else 
            {
                return -1;
            }
        }

        public int GetLast()
        {
            if (!(this.Last == null))
                return this.Last.data;
            else
                return -1;
        }

        public int InsertTail(int value) 
        {
            Node newNode = new Node(value);
            if (IsEmpty()) 
            {
                Head = newNode;
                Last = newNode;
            }
            else 
            {
                newNode.PreviousElement = Last;
                Last.NextElement = newNode;
                Last = newNode;
            }
            Length++;
            return newNode.data;
        }

        public bool DeleteHead()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is Empty");
                return false;
            }

            Head = Head.NextElement;
            Length--;
            return true;
        }

        public bool PrintList()
        {        // Printing the list
            if (IsEmpty())
            {
                Console.Write("List is Empty!");
                return false;
            }
            Node temp = Head;        // starting from head node
            Console.Write("List : ");

            while (temp != null)
            {     // traveresing through the List
                Console.Write(temp.data + "->");
                temp = temp.NextElement;    // moving on to the temp's nextElement
            }
            Console.WriteLine("null ");    // printing null at the end
            return true;
        }
    }

    
}
