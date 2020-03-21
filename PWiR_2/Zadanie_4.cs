using System;

namespace PWiR_2
{
    public class Zadanie_4
    {
        static int _bilans = 0;
        public static void RUN()
        {
            Action<int> dodaj = n =>
            {
                for (int i = 0; i < n; i++)
                {
                    _bilans += 100;
                    Console.WriteLine($"Po dodaniu: {_bilans}");

                }
            };
            dodaj(100);
        }
    }
}
