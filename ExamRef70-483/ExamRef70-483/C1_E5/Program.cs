using System;
using System.Threading;

namespace C1_E5
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem((arg) =>
            {
                Console.WriteLine($"Some work to {arg}");
            }, "do");

            Console.ReadKey();
        }
    }
}
