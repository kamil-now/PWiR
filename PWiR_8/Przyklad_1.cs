using System;
using System.Threading;

namespace PWiR_8
{
    public class Przyklad_1
    {

        // Przykład na podstawie https://msdn.microsoft.com/pl-pl/library/system.threading.thread.priority(v=vs.110).aspx 
        public static void RUN()
        {
            PriorityTest priorityTest = new PriorityTest();

            Thread w1 = new Thread(priorityTest.ThreadMethod)
            {
                Name = "Watek1"
            };
            Thread w2 = new Thread(priorityTest.ThreadMethod)
            {
                Name = "Watek2",
                Priority = ThreadPriority.Lowest
            };
            Thread w3 = new Thread(priorityTest.ThreadMethod)
            {
                Name = "Watek3",
                Priority = ThreadPriority.Highest
            };

            w1.Start();
            w2.Start();
            w3.Start();
            // Allow counting for 10 seconds.
            Thread.Sleep(10000);
            priorityTest.LoopSwitch = false;
        }

    }
    class PriorityTest
    {
        static bool loopSwitch;
        [ThreadStatic]
        static long threadCount = 0;

        public PriorityTest()
        {
            loopSwitch = true;
        }

        public bool LoopSwitch
        {
            set { loopSwitch = value; }
        }

        public void ThreadMethod()
        {
            while (loopSwitch) Interlocked.Increment(ref threadCount);
            Console.WriteLine("{0} z priorytem {1,11} " +
                "ma licznik = {2,13}", Thread.CurrentThread.Name,
                Thread.CurrentThread.Priority.ToString(),
                threadCount.ToString("N0"));   // "N0" - seperatator co 3 cyfry, w PL spacja - wiecej na stronie https://msdn.microsoft.com/en-us/library/dwhawy9k.aspx 

            Console.ReadKey();
        }
    }
}
