using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simulatore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simulatore Sensori");

            start();

            Console.ReadKey();
        }

        static async void start()
        {
            List<Silos> silos = new List<Silos>();
            silos.Add(new Silos(21, 5, 1.5));
            silos.Add(new Silos(22, 8, 2.4));
            silos.Add(new Silos(23, 7, 1.5));
            silos.Add(new Silos(33, 12, 2.64));

            while (true)
            {
                await Task.Delay(500);
            }
        }
    }
}
