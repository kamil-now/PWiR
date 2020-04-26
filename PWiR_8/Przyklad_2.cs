using System;
using System.Threading;

namespace PWiR_8
{
    public class Przyklad_2
    {
        const int ileWatkow = 10;
        //static Barrier b = new Barrier(ileWatkow);
        //static Barrier b = new Barrier(ileWatkow, (Barrier b)=> { Console.WriteLine(); });  // Klasa Barrier umozliwia okreslenia dzialania jakie ma byc wykonane po kazdej fazie

        public static void RUN()
        {
            ThreadStart metodaWatku = () =>
            {
                for (char znak = 'A'; znak <= 'G'; znak++)
                {
                    Console.Write(znak);
                    //b.SignalAndWait();
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
