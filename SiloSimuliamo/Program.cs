using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Security.Cryptography;

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

           
            Random rnd = new Random();
            var volt1 = rnd.Next(0, 2) * 2;
            var volt2 = rnd.Next(0, 2) * 2;
            var volt3 = rnd.Next(0, 2) * 2;
            var volt4 = rnd.Next(0, 2) * 2;

            var metri1 = volt1 / 2.2 * 8;
            var metri2 = volt2 / 2.2 * 8;
            var metri3 = volt3 / 2.2 * 8;
            var metri5 = volt4 / 2.2 * 8;


            using (var client = new HttpClient())
            {
                ///////////////////////////////////////////////////////Cosa da mandare////////////
                var content = new StringContent(JsonConvert.SerializeObject(silos), Encoding.UTF8, "application/json");

                var result = await client.PostAsync("http://localhost:5000/newdata", content);
                string resultContent = await result.Content.ReadAsStringAsync();
            }

             while (true)
                        {
                            await Task.Delay(500);
                        }
        }

    }
}
