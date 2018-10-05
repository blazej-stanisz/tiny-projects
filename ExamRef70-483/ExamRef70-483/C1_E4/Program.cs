using System;
using System.Threading;

namespace C1_E4
{
    class Program
    {
        static ThreadLocal<int> tl = new ThreadLocal<int>(() =>
        {
            return 0;
        });

        static void Main(string[] args)
        {
            new Thread(() =>
            {
                while (tl.Value < 4)
                {
                    Console.WriteLine($"T1, counter value {tl.Value}");
                    Thread.Sleep(1000);
                    tl.Value++;
                }
            }).Start();

            new Thread(() =>
            {
                while (tl.Value < 4)
                {
                    Console.WriteLine($"T2, counter value {tl.Value}");
                    Thread.Sleep(1000);
                    tl.Value++;
                }
            }).Start();
        }
    }
}
