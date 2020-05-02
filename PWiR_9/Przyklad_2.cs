using System;
using System.Threading.Tasks;

namespace PWiR_9
{
    public class Przyklad_2
    {
        public static void RUN()
        {
            int liczba = 10000000;
            bool czyPierwsza = true;

            Parallel.For(2, (int)Math.Sqrt(liczba) + 1, (i, status) =>
            {
                if (liczba % i == 0)
                {
                    Console.WriteLine("{0} dzieli sie przez {1} zadanie nr {2}", liczba, i, Task.CurrentId);
                    czyPierwsza = false;
                    // status.Break(); // odpowiednik break, ale rownolegly (istnieja inne sposoby przerwania petli rownoleglych, np. metoda Stop() oraz z uzyciem klasy CancellationToken)
                }
            });
            if (czyPierwsza)
                Console.WriteLine("Liczba {0} jest liczb¹ pierwsz¹", liczba);
            Console.ReadKey();
        }
    }
}
