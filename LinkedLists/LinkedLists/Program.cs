using System;

namespace LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.InsertAtTail(9);
            list.InsertAtTail(3);
            list.InsertAtTail(4);
            list.InsertAtTail(3);
            list.InsertAtTail(1);

            LinkedList list2 = new LinkedList();
            list2.InsertAtTail(3);
            list2.InsertAtTail(2);
            list2.InsertAtTail(4);
            list2.InsertAtTail(5);

           // var check = list.Union(list, list2);

           // list2.RemoveDuplicates();
            Console.WriteLine();

           var x =  list.ReturnNthNodeFromEnd(2);
            //list.InsertAtIndex(1, 2);
           // list.Delete(0);


            Console.WriteLine(list);
        }
    }

    

    
}
