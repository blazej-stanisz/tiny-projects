using System;
using System.Threading;

namespace E1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread((object arg) =>
            {
                //Thread.Sleep(100);
                Console.WriteLine("Go" + (int)arg);
                //Thread.Sleep(0);
            });
            t.Start(12);
            //t.IsBackground = true;
            //t.Join();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
