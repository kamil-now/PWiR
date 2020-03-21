using System;
using System.Threading;

namespace PWiR_5
{
    public class Przyklad_1
    {
        static Semaphore _sem;

        public static void RUN()
        {
            // Tworzymy semafor, ktory umożliwia żądania dla 3 wątków
            // Początkowa liczba obsługiwanych wątków wysnosi zero
            _sem = new Semaphore(0, 3);

            // Tworzymy 5 numerowanych watków. 
            for (int i = 1; i <= 5; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(Pracuj));
                t.Start(i);
            }

            // Czekamy pół sekundy aby pozwolić wszystkim wątkom wystartować i ustawic semafor
            Thread.Sleep(500);

            // Wątek główny (z metodą main) zwiększa liczbę wątków obsługiwnaych na 3.
            // Dzięki temu do semafora będa mogły wejść maksymalnie 3 wątki oczekujące
            Console.WriteLine("Wątek główny wywołuje Release(3)");
            _sem.Release(3);

            Console.WriteLine("Wątek główny trwa");
            Console.ReadKey();
        }

        static void Pracuj(object num)
        {
            // Każdy pracujący wątek wysyła żądanie (blokady) dla semafora
            Console.WriteLine("Wątek nr {0} odpalił i czeka na semafor", num);
            _sem.WaitOne();
            Console.WriteLine("Wątek nr {0} obsługuje semafor", num);
            Thread.Sleep(1000);   // symulacja jakiejś "pracy"
            Console.WriteLine("Wątek nr {0} zwalnia semafor", num);
            _sem.Release();
        }
    }
}
