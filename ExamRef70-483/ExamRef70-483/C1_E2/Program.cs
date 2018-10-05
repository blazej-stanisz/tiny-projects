using System;
using System.Threading;

namespace C1_E2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool t1CanRun = true;

            Thread t1 = new Thread(() =>
            {
                while (t1CanRun)
                {
                    Console.WriteLine("t1 running...");
                    Thread.Sleep(1000);
                }
                if (!t1CanRun)
                {
                    Console.WriteLine("t1 stopped");
                }
            });

            t1.Start();
            Console.WriteLine("Press any key to stop t1");
            Console.ReadKey();
            t1CanRun = false;
            Console.ReadKey();
        }
    }
}
