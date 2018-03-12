using System;
using System.Windows.Forms;

namespace Ex4
{
    class Tribunetest
    {
        static void Main(string[] args)
        {
            Ståtribune feltA = new Ståtribune("Felt A", 50, 1000);
            Sittetribune feltB = new Sittetribune("Felt B", 250, 200, 20);
            VIPTribune kafeen = new VIPTribune("Kafe Fotball", 1000, 10, 2);
            String res = "";
            
            String[] voksenListe1 = {"Egil", "Jonas", "Mats", "David"};
            String[] voksenListe2 = {"Mari", "Anne", "Håvard"};
            String[] barneListe = {"Bjarne", "Kari", "Nils", "Janne", "Ola"};
            
            res += "Kapasitet på felt A: " + feltA.Kapasitet + "\n";
            res += "Kapasitet på felt B: " + feltB.Kapasitet + "\n";
            res += "Kapasitet i kafeen: " + kafeen.Kapasitet + "\n";
            
            feltA.KjøpBillett(10, 5);
            feltA.KjøpBillett(7, 25);

            feltB.KjøpBillett(5, 1);
            feltB.KjøpBillett(3, 4);
            feltB.KjøpBillett(10, 1);
            feltB.KjøpBillett(voksenListe1, barneListe);
            feltB.KjøpBillett(voksenListe2, barneListe);
            
            feltA.KjøpBillett(7, 70);
            feltA.KjøpBillett(300, 250);
            feltA.KjøpBillett(300, 125);
            feltA.KjøpBillett(voksenListe1, barneListe);
            feltA.KjøpBillett(voksenListe2, barneListe);

            kafeen.KjøpBillett(null, null);
            kafeen.KjøpBillett(voksenListe1, barneListe);
            kafeen.KjøpBillett(voksenListe2, barneListe);

            #region Oppgave E sortering/delegater
            Sortering sort = new Sortering();
            Tribune[] tab1 = {kafeen, feltA, feltB};
            sort.SorterTabellEtterNavn(tab1);
            Tribune[] tab2 = {feltA, kafeen, feltB};
            sort.SorterTabellEtterInntekt(tab2);
            #endregion

            double solgtFor = feltA.SolgtFor() + feltB.SolgtFor() + kafeen.SolgtFor();
            res += "Solgt for: " + solgtFor + " kroner \n";

            MessageBox.Show(res, "Tribuner", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            //           Console.WriteLine();
        }
    }
}