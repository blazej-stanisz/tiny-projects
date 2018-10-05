using System;
using System.Threading;

namespace E1_5
{
    class Program
    {
        [ThreadStatic]
        static int counter = 0;

        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    counter++;
                }
                Console.WriteLine("t1:" + counter);
            });

            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    counter--;
                }
                Console.WriteLine("t2:" + counter);
            });

            t1.Start();
            t2.Start();
            Console.ReadKey();
            Console.WriteLine(counter);
        }
    }
}
