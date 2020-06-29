using Simulatore.Models;
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
            silos.Add(new Silos(1, 5, 1.5));
            silos.Add(new Silos(2, 8, 2.4));
            silos.Add(new Silos(3, 7, 1.5));
            silos.Add(new Silos(4, 12, 2.64));

            Sender sender = new Sender(); // .Send(object) -> execute POST request
            Generator generator = new Generator(); // .Generate(List<Silos>) -> generate list of random data for given List<silos>
            List<GeneratorResult> generatorResult; 

            while (true)
            {
                generatorResult = generator.Generate(silos);
                await sender.Send(generatorResult);
                await Task.Delay(500);
            }
        }
    }
}
