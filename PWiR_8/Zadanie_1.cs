using System;
using System.Threading;
using System.Threading.Tasks;

namespace PWiR_8
{
    public class Zadanie_1
    {
        const int ileWatkow = 10;
        static Barrier b = new Barrier(ileWatkow, (Barrier b)=> { Console.WriteLine(); });  // Klasa Barrier umozliwia okreslenia dzialania jakie ma byc wykonane po kazdej fazie

        public static void RUN()
        {
            Action metodaWatku = () =>
            {
                for (char znak = 'A'; znak <= 'G'; znak++)
                {
                    Console.Write(znak);
                    b.SignalAndWait();
                }
            };
            var tab = new Task[ileWatkow];
            for (int i = 0; i < ileWatkow; i++)
            {
                tab[i] = new Task(metodaWatku);
                tab[i].Start();
            }
            Console.ReadKey();
        }
    }
}
