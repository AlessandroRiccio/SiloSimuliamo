using System;
using System.Collections.Generic;
using System.Text;

namespace Simulatore.Models
{
    public class GeneratorResult
    {
        public GeneratorResult(int id, double riempimento)
        {
            Id = id;
            Riempimento = riempimento;
        }

        public int Id { get; set; }

        public double Riempimento { get; set; }
    }
}
