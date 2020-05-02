using System;
using System.Threading;
using System.Threading.Tasks;

namespace PWiR_8
{
    public class Zadanie_2
    {
        static readonly Random _rand = new Random();
        static readonly Barrier _barrier = new Barrier(2);
        public static void RUN()
        {
            Task getTask(int taskIndex) => new Task(() =>
              {
                  Thread.Sleep(_rand.Next(1000, 2001));
                  Console.WriteLine($"t{taskIndex}");
              });

            var t1 = getTask(1);
            var t2 = getTask(2);
            var t3 = getTask(3);
            var t4 = getTask(4);

            t1.ContinueWith((t) => _barrier.SignalAndWait())
                .ContinueWith((t) => t3.Start());

            t2.ContinueWith((t) => _barrier.SignalAndWait())
                .ContinueWith((t) => t4.Start());

            Parallel.Invoke(() => t1.Start(), () => t2.Start());

            Task.WaitAll(t1, t2, t3, t4);
            Console.WriteLine("KONIEC");

            Console.ReadKey();
        }
    }
}
