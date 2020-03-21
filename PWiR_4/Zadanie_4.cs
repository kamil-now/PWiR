using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace PWiR_4
{
    public class Zadanie_4
    {
        public static void RUN()
        {
            var path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\test.log";
            var process = Process.GetCurrentProcess();
            var mutex = new Mutex(false, "4190D5CA-3AD7-41A9-8206-39E4C54AEEC3", out var isFirst);

            if (!isFirst)
            {
                Console.WriteLine("Czekam");
            }
            mutex.WaitOne();
            using (var file = File.AppendText(path))
            {
                Console.Write("Wpisuję ");
                for (int i = 0; i < 100; i++)
                {

                    file.WriteLine($"{i}; Id\t {process.Id}; Time {DateTime.Now}");
                    Thread.Sleep(50);
                    Console.Write(".");
                }
                file.Flush();
            }
            Console.WriteLine("\nKoniec");
            mutex.ReleaseMutex();
            mutex.Dispose();
            Console.ReadKey();
        }
    }
}
