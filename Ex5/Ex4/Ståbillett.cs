namespace Ex4
{
    public class Ståbillett : Billett
    {
        public double Pris { get; set; }
        public Ståbillett(string tribuneNavn, double pris) : base(tribuneNavn, pris)
        {
        }
    }
}