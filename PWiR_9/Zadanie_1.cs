using System;
using System.Threading;
using System.Threading.Tasks;

namespace PWiR_9
{
    public class Zadanie_1
    {
        static readonly Random _rand = new Random();
        static readonly Barrier _barrier = new Barrier(2);
        public static void RUN()
        {
            Action a = () => _barrier.SignalAndWait();
            Action<Task> b = (Task t) => Thread.Sleep(_rand.Next(1000, 2001));

            var t3 = Task.Factory.StartNew(a).ContinueWith(b);
            var t4 = Task.Factory.StartNew(a).ContinueWith(b);
            Task[] zadania = { t3, t4 };
            Task.Factory.ContinueWhenAny(zadania, (t) =>
            {
                Console.WriteLine("Zawodnik nr {0} wygrał wyścig!", t.Id);
            });
            Console.ReadKey();
        }
    }
}
