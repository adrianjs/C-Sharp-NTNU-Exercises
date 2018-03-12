using System;

namespace Ex4
{
    public abstract class Billett
    {
        private string TribuneNavn { get; set; }
        public double Pris { get; set; }

        public Billett(string tribuneNavn, double pris)
        {
            TribuneNavn = tribuneNavn;
            Pris = pris;
        }

        public virtual String ToString()
        {
            return "navn: " + TribuneNavn + " / pris: " + Pris + ",-";
        }
    }
}