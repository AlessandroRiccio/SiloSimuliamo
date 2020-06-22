using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SiloSappiamoSimulare.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using SimplexNoise;

namespace SiloSappiamoSimulare
{
    public class Worker : BackgroundService
    {
        private int c = 0;
        private readonly ILogger<Worker> _logger;
        private readonly Random random = new Random();
        static HttpClient client = new HttpClient();

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SimplexNoise.Noise.Seed = Convert.ToInt32( Math.Round(random.NextDouble() * 1000000000) );
            float[] noiseValues1 = SimplexNoise.Noise.Calc1D(1000, 0.022f);
            SimplexNoise.Noise.Seed = Convert.ToInt32(Math.Round(random.NextDouble() * 1000000000));
            float[] noiseValues2 = SimplexNoise.Noise.Calc1D(1000, 0.022f);
            SimplexNoise.Noise.Seed = Convert.ToInt32(Math.Round(random.NextDouble() * 1000000000));
            float[] noiseValues3 = SimplexNoise.Noise.Calc1D(1000, 0.022f);
            SimplexNoise.Noise.Seed = Convert.ToInt32(Math.Round(random.NextDouble() * 1000000000));
            float[] noiseValues4 = SimplexNoise.Noise.Calc1D(1000, 0.022f);

            List<Silo> silos = new List<Silo>();
            silos.Add(new Silo(21, 320000, 280000));
            silos.Add(new Silo(22, 380000, 100200));
            silos.Add(new Silo(23, 480000, 450000));
            silos.Add(new Silo(24, 630000, 80000));

            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json") );

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("New data generation at: {time}", DateTimeOffset.Now);
                
                //Randomizza
                double aux = silos[0].Capacita * noiseValues1[c]/256;
                silos[0].Riempimento = Convert.ToInt32( Math.Round(aux) );

                aux = silos[1].Capacita * noiseValues2[c] / 256;
                silos[1].Riempimento = Convert.ToInt32(Math.Round(aux));

                aux = silos[2].Capacita * noiseValues3[c] / 256;
                silos[2].Riempimento = Convert.ToInt32(Math.Round(aux));

                aux = silos[3].Capacita * noiseValues4[c] / 256;
                silos[3].Riempimento = Convert.ToInt32(Math.Round(aux));

                c++;

                //Invia post a localhost:5000/newdata
                var dataAsString = JsonConvert.SerializeObject(silos);
                var content = new StringContent(dataAsString);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync("http://localhost:5000/newdata", content);

                await Task.Delay(500, stoppingToken);
            }
        }
    }
}
