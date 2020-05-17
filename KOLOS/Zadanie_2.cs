using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KOLOS
{
    class Program
    {
        static readonly object _lck = new object();
        static void Main(string[] args)
        {
            var path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\liczby_zaprzyjaznione.csv";

            var max = 600000;
            var iloscLiczb = 12;
            Action tmp = () =>
            {
                var liczby = ZnajdzLiczbyZaprzyjaznione(max);
                lock (_lck)
                {
                    Console.WriteLine($"Znaleziono {liczby.Count} liczb zaprzyjaźnionych");
                }
                CsvReaderWriter.Write(path, liczby.Select(x => new string[] { x.a.ToString(), x.b.ToString() }).ToList(), false);
                lock (_lck)
                {
                    Console.WriteLine($"Liczby zapisano do pliku {path}");
                    CsvReaderWriter.ReadAndPrint(path);
                }
            }; tmp();
            var t1 = new Task(() =>
            {
                var liczby = ZnajdzLiczbyZaprzyjaznione(max);
                lock (_lck)
                {
                    Console.WriteLine($"Znaleziono {liczby.Count} liczb zaprzyjaźnionych");
                }
                CsvReaderWriter.Write(path, liczby.Select(x => new string[] { x.a.ToString(), x.b.ToString() }).ToList(), false);
                lock (_lck)
                {
                    Console.WriteLine($"Liczby zapisano do pliku {path}");
                    CsvReaderWriter.ReadAndPrint(path);
                }
            });
            var t2 = new Task(() =>
            {
                lock (_lck)
                {
                    var liczby = new List<int>();
                    do
                    {
                        Console.WriteLine("Wprowadź liczbę");
                        var input = Console.ReadLine();

                        if (int.TryParse(input, out int liczba))
                        {
                            liczby.Add(liczba);
                        }

                    } while (liczby.Count < iloscLiczb);
                    var odchylenie = ObliczOdchylenieStandardowe(liczby);
                    Console.WriteLine($"Odchylenie standardowe dla {string.Join(", ", liczby.ToArray())} = {odchylenie}");
                }
            });

            Parallel.Invoke(() => t1.Start(), () => t2.Start());
            Task.WaitAll(t1, t2);
        }
        static List<(int a, int b)> ZnajdzLiczbyZaprzyjaznione(int max)
        {
            var liczby = new List<(int, int)>();
            Parallel.For(0, max, i =>
            {
                for (int j = 1; j < max; j++)
                {
                    if (i != j && SumaDzielnikow(i) == SumaDzielnikow(j))
                    {
                        liczby.Add((i, j));
                        Console.WriteLine($"{i}, {j}");
                    }
                }
            });
            //for (int i = 1; i < max; i++)
            //{
            //    for (int j = 1; j < max; j++)
            //    {
            //        if (i != j && SumaDzielnikow(i) == SumaDzielnikow(j))
            //        {
            //            liczby.Add((i, j));
            //            Console.WriteLine($"{i}, {j}");
            //        }
            //    }
            //}
            return liczby;

        }
        static int SumaDzielnikow(int liczba)
        {
            int suma = 0;
            for (int i = 1; i < liczba; i++)
            {
                if (liczba % i == 0)
                {
                    suma += i;
                }
            }
            return suma;
        }
        static double ObliczOdchylenieStandardowe(IEnumerable<int> liczby)
        {
            var odchylenie = 0d;

            if (liczby.Any())
            {
                var srednia = liczby.Average();
                var suma = liczby.Sum(d => Math.Pow(d - srednia, 2));
                odchylenie = Math.Sqrt((suma) / (liczby.Count() - 1));
            }

            return odchylenie;
        }
    }
    class CsvReaderWriter
    {
        public static List<string[]> Read(string path)
        {
            var list = new List<string[]>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    list.Add(line.Split(','));
                }
            }
            return list;
        }
        public static void ReadAndPrint(string path)
        {
            var content = Read(path);
            foreach (var row in content)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
        public static void Write(string path, List<string[]> content, bool append)
        {
            using (var writer = new StreamWriter(path, append))
            {
                if (content.Count > 0 && new FileInfo(path).Length == 0)
                {
                    writer.WriteLine();
                }
                foreach (var row in content)
                {
                    writer.WriteLine(string.Join(",", row));
                }
            }
        }
    }
}
