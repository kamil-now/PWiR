using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PWiR_8
{
    public class Przyklad_4
    {
        public static void RUN()
        {
            Action a1 = () =>
            {
                Console.WriteLine("Start zadania nr {0}", Task.CurrentId);
                // SpinWait wykonuje rzeczywiste operacje obci¹¿aj¹ce procesor 
                // (nie usypia w¹tku jak Sleep). Wymaga using System.Threading;
                Thread.SpinWait(new Random().Next(10000000));
                Console.WriteLine("Koniec zadania nr {0}", Task.CurrentId);
            };

            List<Task> listaZadan = new List<Task>();
            for (int i = 0; i < 100; i++)
            {
                listaZadan.Add(new Task(a1));
            }
            listaZadan.ForEach(t => t.Start());
            listaZadan.ForEach(t => t.Wait());

            Console.ReadKey();
        }
    }
}
