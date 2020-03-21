using System;
using System.Threading;

namespace PWiR_4
{
    public class Zadanie_3
    {
        static readonly object _lck = new object();

        static int _msgCount = 0;
        public static void RUN()
        {
            Thread read = new Thread(new ThreadStart(Read));
            read.Name = "Wątek czytający";

            Thread write = new Thread(new ThreadStart(Write));
            write.Name = "Wątek piszący";

            write.Start();
            read.Start();

            Console.ReadKey();
        }
        static void Read()
        {
            while (true)
            {
                Monitor.Enter(_lck);
                if (_msgCount <= 0)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: Brak wiadomości");
                    Monitor.Wait(_lck);
                }
                _msgCount -= 1;
                Console.WriteLine($"{Thread.CurrentThread.Name}: Wiadomość przeczytana");

                Monitor.Exit(_lck);
            }
        }

        static void Write()
        {
            for (int i = 1; i < 10; i++)
            {
                Monitor.Enter(_lck);
                if (_msgCount > 0)
                {
                    Monitor.Pulse(_lck);
                }
                _msgCount += 1;
                Console.WriteLine($"{Thread.CurrentThread.Name}: Wiadomość wysłana");
                Monitor.Exit(_lck);
            }
        }
    }
}
