using System;
using System.Threading;
using System.Threading.Tasks;

namespace YT_Examples
{
    class Program
    {
        static Test test1 = new Test1();
        static Test test2 = new Test2();
        static Test test3 = new Test3();
        static Test test4 = new Test4();
        static Test test5 = new Test5();
        static Test test6 = new Test6();
        static Test test7 = new Test7();
        static Test test8 = new Test8();
        static Test test9 = new Test9();
        static Test test10 = new Test10();
        static Test test11 = new Test11();

        static void Main(string[] args)
        {
            // Join example
            // test1.Run();

            // Background/foreground threads
            // test2.Run();

            // Parametrized threads
            // test3.Run();

            // Stop thread
            // test4.Run();

            // ThreadStatic variable
            // test5.Run();

            // Threadpool
            // test6.Run();

            // Task
            // test7.Run();

            // Task using Action argument
            // test8.Run();

            // Task return values
            // test9.Run();

            // Task return values
            // test10.Run();

            // Task continue with continuation options/conditions
            // test11.Run();

            // !!! use Ctrl + F5 instead of ReadKey
            //Console.ReadKey();
        }
    }

    /// <summary>
    /// Task continue with continuation options/conditions
    /// </summary>
    public class Test11 : Test
    {
        public void Run()
        {
            Task<int> task1 = Task.Run(() =>
            {
                //throw new Exception();
                return 42;
            });

            task1.ContinueWith((i) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            task1.ContinueWith((i) =>
            {
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            Console.WriteLine(task1.Result);
        }

        /// Komentarz: Metoda continue with moze przyjmować wiele parametrów warunkujących jej wykonanie, np. wyjątek albo zakończenie taska
    }

    /// <summary>
    /// Continuations
    /// </summary>
    public class Test10 : Test
    {
        public void Run()
        {
            Task<int> task1 = Task.Run(() =>
            {
                return 42;
            }).ContinueWith((i) =>
            {
                return i.Result * 2;
            });

            Console.WriteLine(task1.Result);
        }

        /// Komentarz: Task może być kontynowany po zakończeniu i zwróceniu wyniku. 
    }

    /// <summary>
    /// Task return values
    /// </summary>
    public class Test9 : Test
    {
        public void Run()
        {
            Task<int> task1 = Task.Run(() =>
            {
                return 42;
            });
            Console.WriteLine(task1.Result);
        }

        /// Komentarz: Task może zwracać wartość. Należy wtedy podać typ przy typie obiektu Task
        /// Wartość zwracana podawana jest w polu Result
    }

    /// <summary>
    /// Task using Action argument
    /// </summary>
    public class Test8 : Test
    {
        public static void ThreadMethod()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write('*');
            }
        }

        Action action1 = new Action(ThreadMethod);

        public void Run()
        {
            Task task1 = Task.Run(action1);
            task1.Wait();
        }

        /// Komentarz: Użycie taska z Action jako parametr
    }

    /// <summary>
    /// Task
    /// </summary>
    public class Test7 : Test
    {
        public void Run()
        {
            Task task1 = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write('*');
                }
            });
            task1.Wait();
        }

        /// Komentarz: Task posiada wartość zwaracaną
        /// funkcja Wait zabezpiecza przed przedwczesnym usunięciem wątku, jeżeli wątek główny zakończy się wcześniej
    }

    /// <summary>
    /// Threadpool
    /// </summary>
    public class Test6 : Test
    {
        public void Run()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from the threadpool");
            });
            Console.ReadKey();
        }

        /// Komentarz: ?? możliwość uruchamiania wątkuów w threadpool
    }

    /// <summary>
    /// ThreadStatic variable
    /// </summary>
    public class Test5 : Test
    {
        [ThreadStatic]
        public static int _field;

        public void Run()
        {
            Thread thread1 = new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread_A {0}", _field);
                }
            }));

            thread1.Start();

            Thread thread2 = new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread_B {0}", _field);
                }
            }));

            thread2.Start();
        }

        /// Komentarz: Uzycie zmiennej opisanej atrybutem ThreadStatic powoduje, że każdy wątek posiada własną kopię tej zmiennej
        /// każdy wątek inkrementuje wartość zmiennej od 0
    }


    /// <summary>
    /// Stop thread
    /// </summary>
    public class Test4 : Test
    {
        public void Run()
        {
            bool stopped = false;
            Thread thread1 = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Thread is about to close");
            }));
            Console.WriteLine("Press any key to Exit");
            thread1.Start();
            Console.ReadKey();
            stopped = true;
            thread1.Join();
        }

        /// Komentarz: umożliwienie sterowania wątkiem za pomocą globalnej zmiennej - w tym przypadku umożliwienie zatrzymania wątku
        /// Ważna jest kolejność kodu na samym dole, join musi byc wykonany na końcu po to aby program nie czekał na zakończenie wątku
        /// Zmianna stopped jest współdzielona przez wszystkie wątki
    }

    /// <summary>
    /// Parametrized threads
    /// </summary>
    public class Test3 : Test
    {
        public void ThreadMethod(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc {0}", i);
                Thread.Sleep(0);
            }
        }

        public void Run()
        {
            Thread thread1 = new Thread(new ParameterizedThreadStart(ThreadMethod));
            thread1.Start(15);
        }

        /// Komentarz: przekazywanie wartości do wątku odbywa się za pomocą delegatu ParameterizedThreadStart
        /// przekazana wartość jest opakowywana w typ object
    }

    /// <summary>
    /// Background/foreground threads
    /// </summary>
    public class Test2 : Test
    {
        public void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc {0}", i);
                Thread.Sleep(500);
            }
        }

        public void Run()
        {
            Thread thread1 = new Thread(new ThreadStart(ThreadMethod));
            thread1.IsBackground = true;
            thread1.Start();
        }

        /// Komentarz: Zadeklarowanie wątku jako IsBackground = true, powoduje, że wątek główny nie oczekuje na jego zakończenie
        /// Jeżeli wątek główny zakończy pracę, zabije wątek oznaczony jako IsBackground, bez względu na to na jakim etapie realizacji
        /// zadnia znajduje się ten wątek
    }

    /// <summary>
    /// Join example
    /// </summary>
    public class Test1 : Test
    {
        public void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc {0}", i);
                Thread.Sleep(0);
            }
        }

        public void Run()
        {
            Thread thread1 = new Thread(new ThreadStart(ThreadMethod));
            thread1.Start();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work");
                Thread.Sleep(0);
            }

            thread1.Join();
            Console.WriteLine("AFTER");
        }

        /// Komentarz: użycie Join powoduje, że wątek musi zostać wykonany i zakończyć się w miejscu wywołania Join
        /// Dopiero po zakończeniu wątku pobocznego, wątek głowny pójdzie dalej z wykonaniem programu
        /// W tym przypadku wypisze na ekran słowo "AFTER"
        /// Thread.Sleep(0) informuje TaskScheduler, że procesor może przełączyć się na inny wątek, czyli, że akutalnie
        /// zakończyliśmy pracę w miejscu zadeklarowania Sleep(0). Po pewnym czasie task scheduler wróci znów do wykonania
        /// przerwanego wątku 
    }

    interface Test
    {
        void Run();
    }
}
