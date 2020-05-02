using System;
using System.Linq;
using System.Threading.Tasks;

namespace PWiR_9
{
    public class Zadanie_2
    {
        public static void RUN()
        {
            int start = Environment.TickCount;

            var list = Enumerable.Range(0, 1000).ToList();

            //list.ForEach(x => FindPrimeNumber(1000));         // wariant sekwencyjny
            Parallel.ForEach(list, x => FindPrimeNumber(1000)); // wariant równoległy

            int stop = Environment.TickCount;
            Console.WriteLine($"Czas wykonania {(stop - start).ToString("N0")} ms");
            Console.ReadKey();
        }

        // metoda wyznacza n-tą liczbę pierwszą a
        static void FindPrimeNumber(int n) // w tym przypadku nie potrzebujemy wyznaczonej liczby, więc metoda nic nie zwraca
        {
            var count = 0; // licznik ilości wyznaczonych liczb
            var a = 2; // liczba pierwsza jest podzielna przez 1 dlatego rozpoczynamy sprawdzanie od 2
            while (count < n)
            {
                var b = 2; // pierwsza liczba, która może być dzielnikiem liczby a
                var isPrime = true;

                // pierwiastek z a to ostatnia liczba, która może być dzielnikiem liczby a
                // dlatego pod uwagę powinny być brane tylko liczby, których kwadrat jest mniejszy lub równy a
                while (b * b <= a)
                {
                    if (a % b == 0) // jeżeli a jest podzielna przez jakąkolwiek liczbę w tej pętli, to nie jest liczbą pierwszą
                    {
                        isPrime = false;
                        break;
                    }
                    b++;
                }

                if (isPrime) // warunek jest prawdziwy gdy pętla while nie została przerwana
                {
                    count++;
                }
                a++;
            }
        }
    }
}
