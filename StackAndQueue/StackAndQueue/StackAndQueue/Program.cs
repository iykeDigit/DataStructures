using System;

namespace StackAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Stack myStack = new Stack(5);
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);

            myStack.ShowStack();
          
            myStack.Pop();
            myStack.ShowStack();
            */

            Queue myQueue = new Queue();
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(4);
            myQueue.Enqueue(5);
            myQueue.ShowQueue();

            myQueue.Dequeue();
            myQueue.GetSize();
            myQueue.ShowQueue();

        }

    }
}
