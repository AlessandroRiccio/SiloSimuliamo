using System;
using System.Collections.Generic;
using System.Text;

namespace Simulatore
{
    public class Silos
    {
        public Silos(int id, double altezza, double raggio)
        {
            Id = id;
            Altezza = altezza;
            Raggio = raggio;
        }

        public int Id { get; set; }

        public double Altezza { get; set; }

        public double Raggio { get; set; }
    }
}
