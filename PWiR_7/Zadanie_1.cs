using System;
using System.Collections.Generic;
using System.Threading;

namespace PWiR_7
{
    public class Zadanie_1
    {
        static readonly Random _rnd = new Random();
        public static void RUN()
        {
            KonsumenciProducenci kp = new KonsumenciProducenci();
            kp.Pracuj();
        }
        class KonsumenciProducenci
        {
            static Thread _watekProducenta = null;
            static Thread _watekKonsumenta = null;
            static int _pojemnoscMagazynu = 5;
            static Queue<object> _magazyn = new Queue<object>();
            static readonly object _lck = new object();

            public void Pracuj()
            {
                Action akcjaProducenta = () =>
                {
                    while (true)
                    {
                        Monitor.Enter(_lck);
                        if (_magazyn.Count == _pojemnoscMagazynu)
                        {
                            Monitor.Pulse(_lck);
                        }
                        else
                        {
                            _magazyn.Enqueue(_rnd.Next(1, 101));
                        }
                        Monitor.Exit(_lck);
                    }
                };
                Action akcjaKonsumenta = () =>
                {
                    while (true)
                    {
                        Monitor.Enter(_lck);
                        if (_magazyn.Count == 0)
                        {
                            Monitor.Wait(_lck);
                        }
                        else
                        {
                            _magazyn.Dequeue();
                            Monitor.Pulse(_lck);
                        }
                        Monitor.Exit(_lck);
                    }
                };

                _watekProducenta = new Thread(new ThreadStart(akcjaProducenta))
                {
                    IsBackground = true
                };
                _watekKonsumenta = new Thread(new ThreadStart(akcjaKonsumenta))
                {
                    IsBackground = true
                };
                _watekProducenta.Start();
                _watekKonsumenta.Start();
                while (true)
                {
                    var key = Console.ReadKey().Key;
                    if (key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    else
                    {
                        WyswietlStanMagazynu();

                    }
                }

                Console.WriteLine("!!! Koniec !!!");
                Console.ReadKey();
            }
            static void WyswietlStanMagazynu()
            {
                Monitor.Enter(_lck);
                if (_magazyn.Count == 0)
                {
                    Console.WriteLine("-");
                }
                foreach (var item in _magazyn)
                {
                    Console.WriteLine(item.ToString());
                }
                Monitor.Exit(_lck);
            }
        }

    }
}
