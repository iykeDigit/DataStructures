using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public class LinkedList
    {
        public Node Head;

        public LinkedList()
        {
            Head = null;
        }



        /// <summary>
        /// Remove nth element from the end
        /// </summary>
        /// <returns></returns>
        
        public Node RemoveNthNodeFromEnd(int n) 
        {
            Node slow = Head;
            Node fast = Head;

            for(int i = 1; i <= n+1; i++) 
            {
                fast = fast.NextElement;
                Console.WriteLine(i);
            }

            while (fast != null) 
            {
                slow = slow.NextElement;
                fast = fast.NextElement;
            }

            slow.NextElement = slow.NextElement.NextElement;
            return fast;
            
        }

        /// <summary>
        /// Return Nth node from the end
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ReturnNthNodeFromEnd(int n)
        {
            Node slow = Head;
            Node fast = Head;

            for (int i = 1; i <= n + 1; i++)
            {
                fast = fast.NextElement;
                Console.WriteLine(i);
            }

            while (fast != null)
            {
                slow = slow.NextElement;
                fast = fast.NextElement;
            }

            return slow.NextElement.Data;
            

        }


        public bool IsEmpty()
        {
            if (Head == null)
            {
                return true;
            }

            return false;
        }

        public void InsertAtHead(int value)
        {
            Node newNode = new Node();
            newNode.Data = value;
            newNode.NextElement = Head;
            Head = newNode;
        }

        public void InsertAtTail(int value)
        {
            // Enter your code here
            Node newNode = new Node();
            newNode.Data = value;

            //start from the head
            Node currentNode = Head;
            if (currentNode == null)
            {
                Head = newNode;
            }
            while (currentNode != null)
            {
                if (currentNode.NextElement == null)
                {
                    currentNode.NextElement = newNode;
                    break;
                }
                currentNode = currentNode.NextElement;
            }

        }

        public void InsertAtIndex(int value, int index)
        {
            Node newNode = new Node();
            newNode.Data = value;
            int count = 0;
            Node currentNode = Head;
            while (currentNode != null)
            {
                if (count == index)
                {
                    newNode.NextElement = currentNode.NextElement;
                    currentNode.NextElement = newNode;
                    break;
                }
                currentNode = currentNode.NextElement;
                count++;
            }
        }

        public bool Search(int value)
        {
            Node currentNode = Head;
            if (currentNode == null)
            {
                return false;
            }
            while (currentNode != null)
            {
                if (currentNode.Data == value)
                {
                    return true;
                }
                currentNode = currentNode.NextElement;
            }
            // Write your code here
            return false; // if not found
        }

        public bool DeleteAtHead()
        {
            if (Head == null)
            {
                return false;
            }
            Head = Head.NextElement;
            return true;
        }

        public bool Delete(int value)
        {
            // Write your code here
            if (Head == null)
                return false;

            Node previous = Head;
            Node currentNode = Head.NextElement;

            if(Head.Data == value) 
            {
                Head = currentNode;
            }

            while(currentNode != null) 
            {
                if(currentNode.Data == value) 
                {
                    previous.NextElement = currentNode.NextElement;
                    currentNode = previous.NextElement;
                    return true;
                }

                previous = currentNode;
                currentNode = currentNode.NextElement;
                                
            }
            return false;
        }

        public Node Reverse() 
        {
            Node previous = null;
            Node current = Head;
            Node next = null;
           while(current != null) 
            {
                next = current.NextElement;
                current.NextElement = previous;
                previous = current;
                current = next;
            }

            return previous;
           

        }

        /// <summary>
        /// Detect cycle in a loop
        /// </summary>
        /// <returns></returns>
        public bool DetectLoop()
        {
            Node slow = Head;
            Node fast = Head;

            while (slow != null && fast != null && fast.NextElement != null)
            {
                slow = slow.NextElement;
                fast = fast.NextElement.NextElement;
                if (slow == fast)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Find the middle node in a linked list
        /// </summary>
        /// <returns></returns>
        public int FindMid()
        {
            Node current = Head;
            Node last = Head;

            while (current != null && current.NextElement != null)
            {
                current = current.NextElement.NextElement;
                last = last.NextElement;


                if (current.NextElement == null)
                {
                    return last.Data;
                }
            }
            // Write your code here
            return 0;
        }

        public void RemoveDuplicates()
        {
            Node current = Head;
            Node previous = null;
            List<int> list = new List<int>();
            

            while(current != null) 
            {
                if (list.Contains(current.Data)) 
                {
                    previous.NextElement = current.NextElement;
                    
                }

                else 
                {
                    list.Add(current.Data);
                    previous = current;
                }
                current = previous.NextElement;
            }

        }

        public LinkedList Union(LinkedList list1, LinkedList list2)
        {
            //Return other List if one of them is empty
            if (list1.IsEmpty())
                return list2;
            else if (list2.IsEmpty())
                return list1;

            Node start = list1.Head; // starting from head of list 1

            //Traverse first list till the last element
            while (start.NextElement != null)
            {
                start = start.NextElement;
            }

            //Link last element of first list to the first element of second list
            start.NextElement = list2.Head; // appendinf list2 with list 1

            list1.RemoveDuplicates(); // removing duplicates from list and return list
            return list1;
        }

        public LinkedList Intersection(LinkedList list1, LinkedList list2)
        {
            LinkedList list3 = new LinkedList();
            Node t1 = list1.Head, t2 = list2.Head;

            // Traverse both lists and store the same element 
            // in the resultant list list3
            while (t1 != null)
            {
                while (t2 != null)
                {
                    if (t1.Data == t2.Data)
                        list3.InsertAtHead(t1.Data);
                    t2 = t2.NextElement;
                }
                t2 = list2.Head;
                t1 = t1.NextElement;
            }
            list3.RemoveDuplicates();
            return list3;
        }
    }








}
