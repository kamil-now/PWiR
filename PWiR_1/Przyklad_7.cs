using System;
using System.IO;

namespace PWiR_1
{
    public class Przyklad_7
    {
        public static void RUN()
        {
            FileSystemWatcher SledzikPlikow = new FileSystemWatcher();
            SledzikPlikow.Path = @"D:\MojFolder";
            SledzikPlikow.Filter = "*.txt";

            SledzikPlikow.Deleted += new FileSystemEventHandler(fileWatcher_Deleted);
            SledzikPlikow.Renamed += new RenamedEventHandler(fileWatcher_Renamed);
            SledzikPlikow.Changed += new FileSystemEventHandler(fileWatcher_Changed);
            SledzikPlikow.Created += new FileSystemEventHandler(fileWatcher_Created);

            SledzikPlikow.EnableRaisingEvents = true;
            Console.ReadKey();
        }

        static void fileWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Usunięto plik: " + e.FullPath);
        }
        static void fileWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("Zmieniono nazwę pliku: " + e.FullPath);
        }
        static void fileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Zmieniono plik: " + e.FullPath);
        }
        static void fileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Utworzono plik: " + e.FullPath);
        }
    }
}
