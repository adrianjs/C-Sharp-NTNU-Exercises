namespace Ex4
{
    public class Sittebillett : Billett
    {
        public int Rad { get; set; }
        public int PlassNr { get; set; }
        
        public Sittebillett(string tribuneNavn, double pris, int rad, int plassNr) : base(tribuneNavn, pris)
        {
            Rad = rad;
            PlassNr = plassNr;
        }

        public override string ToString()
        {
            return base.ToString() + " / rad: " + Rad + " / plassnr: " + PlassNr;
        }
    }
}