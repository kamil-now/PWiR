using System;
using System.Threading;

namespace PWiR_8
{
    public class Przyklad_2
    {
        const int ileWatkow = 10;
        //static Barrier b = new Barrier(ileWatkow);
        static readonly Barrier b = new Barrier(ileWatkow, (Barrier b) => Console.WriteLine());  // Klasa Barrier umożliwia określenie działania jakie ma być wykonane po każdej fazie

        public static void RUN()
        {
            ThreadStart metodaWatku = () =>
            {
                for (char znak = 'A'; znak <= 'G'; znak++)
                {
                    Console.Write(znak);
                    b.SignalAndWait();
                }
            };
            Thread[] tab = new Thread[ileWatkow];
            for (int i = 0; i < ileWatkow; i++)
            {
                tab[i] = new Thread(metodaWatku);
                tab[i].Start();
            }
            Console.ReadKey();
        }

    }
}
