using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var priorityQueue = new PriorityQueue<string, int>();

            for (char i = 'a'; i <= 'z'; i++)
            {
                priorityQueue.Insert(i.ToString(), 1);
            }

            Console.WriteLine();
        }
    }
}
