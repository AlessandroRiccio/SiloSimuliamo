using System;
using System.Collections.Generic;
using System.Text;

namespace SiloSappiamoSimulare.Models
{
    public class Silo
    {
        public Silo(int idSilos, int capacita, int riempimento)
        {
            IdSilos = idSilos;
            Capacita = capacita;
            Riempimento = riempimento;
        }

        public int IdSilos { get; set; }

        public int Capacita { get; set; }

        public int Riempimento { get; set; }
    }
}
