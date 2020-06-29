using Simulatore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simulatore
{
    public class Generator
    {
        public List<GeneratorResult> Generate(List<Silos> silos)
        {
            List<GeneratorResult> generatorResult = new List<GeneratorResult>();
            Random random = new Random();

            foreach(Silos silo in silos)
            {
                double volt = random.NextDouble() * 2.2; // 2.2 = max voltage
                double meters = volt / 2.2 * silo.Altezza;
                int litri;

                if (meters < silo.Altezza)
                    litri = Convert.ToInt32(1000 * Math.PI * silo.Raggio * silo.Raggio * meters );
                else
                    litri = Convert.ToInt32(1000 * GetLitersWithCone(silo.Raggio, silo.Altezza, meters) );

                generatorResult.Add( new GeneratorResult(silo.Id, litri) );

                Console.WriteLine("Silos " + silo.Id.ToString() + ": " + volt.ToString() + "V -> " + litri.ToString());
            }

            Console.WriteLine();

            return generatorResult;
        }

        protected double GetLitersWithCone(double r, double h, double d)
        {
            return Math.PI * r * r * d + Math.PI * ((d - h) * (d - h) * (d - h) / 3 - (d - h) * (d - h) * r + (d - h) * r * r);
        }
    }
}