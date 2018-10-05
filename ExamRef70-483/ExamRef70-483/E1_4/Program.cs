using System;
using System.Threading;

namespace E1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stopped = false;

            Thread t = new Thread(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Thread Go..." + new Random().Next());
                }
            });
            t.Start();
            Console.ReadKey();
            stopped = true;
        }
    }
}
