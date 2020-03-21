using System;
using System.Threading;

namespace PWiR_2
{
    public class Zadanie_6
    {
        static readonly Random _rnd = new Random();
        static int _bilans = 0;
        public static void RUN()
        {
            Action<int> dodaj = n =>
            {
                for (int i = 0; i < n; i++)
                {
                    Thread.Sleep(_rnd.Next(100, 501));
                    _bilans += 100;
                    Console.WriteLine($"Po dodaniu: {_bilans}");

                }
            };
            dodaj(100);
        }
    }
}
