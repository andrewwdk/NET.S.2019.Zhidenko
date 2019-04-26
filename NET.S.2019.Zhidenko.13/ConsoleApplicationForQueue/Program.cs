using System;
using Queue;

namespace ConsoleApplicationForQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(new int[] { 1, 2 });

            queue.Enqueue(3);
            queue.Enqueue(4);

            Console.Write("Current elements: ");

            foreach(int element in queue)
            {
                Console.Write("{0} ", element);
            }

            Console.WriteLine("\nDequeued element: {0}", queue.Dequeue());

            Console.Write("Left elements: ");

            foreach (int element in queue)
            {
                Console.Write("{0} ", element);
            }

            Console.ReadKey();
        }
    }
}
