using System;
using System.Threading;
using System.Threading.Tasks;

namespace PWiR_9
{
    public class Przyklad_1
    {
        public static void RUN()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;   // token pozwalajacy na przerwanie zadania
            Task<int> t1 = Task<int>.Factory.StartNew
            (
                (x) =>
                {
                    Console.WriteLine(x.ToString());
                    return 101;
                },
                "Witaj",                        // wejscie dla zadania (argument przekazany do zadania)
                ct,                             // token pozwalajacy na przerwanie zadania
                TaskCreationOptions.None,       // opcje tworzenia i sterowania zadaniem https://msdn.microsoft.com/pl-pl/library/system.threading.tasks.taskcreationoptions(v=vs.110).aspx
                TaskScheduler.Default           //domyslny planista
            );      
            t1.Wait();
            Console.WriteLine(t1.Result);       // Wyswietlenie wyniku zwracanego przez zadanie

            Console.ReadKey();
        }
    }
}
