using System;
using System.Collections.Generic;

namespace Ex4
{
	/// <summary>
	/// Basisklasse Tribunene samt de avledete kalssene Ståtribune, Sittetribune og VIPtribune
	/// </summary>
	public abstract class Tribune
	{
		protected Tribune(string navn, double pris, int kap)
		{
			Navn = navn;
            Pris = pris;
            Kapasitet = kap;
			Inntekt = 0;
		}

		protected string Navn 
		{
			get;
            private set;
		}

		protected double Pris
        {
            get;
            private set;
        }
        
        public int Kapasitet 
		{
			get;
            private set;
		}

		protected double Inntekt;

		protected virtual double Barnepris
		{
			get { return Pris / 2; }
			set {  }
		}

		public virtual double SolgtFor() 
		{
			return Inntekt;
		}

		public abstract Billett[] KjøpBillett(int antVoksne, int antBarn);

		public abstract int AntallSolgtePlasser { get; }

		public String VisNavn()
		{
			return Navn;
			
		}
		
   		public override string ToString() 
        {
             return Navn + " har kapasitet " + Kapasitet + " og pris " + Pris + " kroner.";
        }
	}


	public class Ståtribune : Tribune 
	{
        private int _antallSolgtePlasser;
		public Ståtribune(string navn, double pris, int kap) 
			: base(navn, pris, kap)
		{ 
			_antallSolgtePlasser = 0;
		}
        public override int AntallSolgtePlasser
        {
            get 
            {
                return _antallSolgtePlasser;
            }
         }

		
		public override Billett[] KjøpBillett(int antVoksne, int antBarn)
		{
			KeyValuePair<bool, Ståbillett> kanSelge = SelgPlasser(antBarn + antVoksne);
			int antall = antBarn + antVoksne;
			if (kanSelge.Key)
			{
				Billett[] temp = new Ståbillett[antall];
				for (int i = 0; i < antVoksne; i++)
				{
					temp[i] = new Ståbillett(Navn, Pris);
					Inntekt += temp[i].Pris;

				}
				for (int j = antVoksne; j < temp.Length; j++)
				{
					temp[j] = new Ståbillett(Navn, Barnepris);
					Inntekt += temp[j].Pris;
				}
				Console.WriteLine("[" + Navn + "]: Kvittering: " + antall + " billetter solgt");
				return temp;
			}

			Console.WriteLine("[" + Navn + "]: Oppgitt antall (" + antall + ") billetter kan ikke selges");
			return null;

		} 
		
		// Oppgave D
		public Billett[] KjøpBillett(String[] listeVoksne, String[] listeBarn)
		{
			KeyValuePair<bool, Ståbillett> kanSelge = SelgPlasser(listeVoksne.Length + listeBarn.Length);
			int antall = listeBarn.Length + listeVoksne.Length;
			if (kanSelge.Key)
			{
				Billett[] temp = new Ståbillett[antall];
				for (int i = 0; i < listeVoksne.Length; i++)
				{
					temp[i] = new Ståbillett(Navn, Pris);
					Inntekt += temp[i].Pris;
				}

				for (int j = listeVoksne.Length; j < temp.Length; j++)
				{
					temp[j] = new Ståbillett(Navn, Barnepris);
					Inntekt += temp[j].Pris;
				}

				Console.WriteLine("[" + Navn + "]: Kvittering: " + antall + " billetter solgt.");
				return temp;
			}
			Console.WriteLine("[" + Navn + "]: Oppgitt antall (" + antall + ") billetter kan ikke selges.");
			return null;
		}

		private KeyValuePair<bool, Ståbillett> SelgPlasser(int antall)
		{
			if (AntallSolgtePlasser + antall <= Kapasitet)
			{
				_antallSolgtePlasser += antall;
				return new KeyValuePair<bool, Ståbillett>(true, new Ståbillett(Navn, Pris));
			}

			return new KeyValuePair<bool, Ståbillett>(false, new Ståbillett(Navn, Pris));
		}
	}

	public class Sittetribune : Tribune
	{
		private int[] antallSolgtPrRad;

		public Sittetribune(string navn, double pris, int kap, int antRader) 
			: base(navn, pris, kap)
		{
			AntallRader = antRader;
			antallSolgtPrRad = new int[AntallRader];
			for (int i=0; i<AntallRader; i++) antallSolgtPrRad[i] = 0;
		}

        public int AntallRader
        {
            get;
            private set;
         }

		public override int AntallSolgtePlasser 
		{
			get 
			{
				int total = 0;
				for (int i=0; i<AntallRader; i++) total += antallSolgtPrRad[i];
				return total;
			}
		}

		public override Billett[] KjøpBillett(int antVoksne, int antBarn)
		{
			KeyValuePair<bool, Sittebillett> kanSelge = SelgPlasser(antBarn + antVoksne);
			int antall = antBarn + antVoksne;
			if (kanSelge.Key)
			{
				Billett[] temp = new Ståbillett[antall];
				for (int i = 0; i < antVoksne; i++)
				{
					/*legger til billetter for voksne*/
					//SelgPlasser(antVoksne - i);
					temp[i] = new Ståbillett(Navn, Pris);
					Inntekt += temp[i].Pris;

				}
				for (int j = antVoksne; j < temp.Length; j++)
				{
					/* legger til billetter for barn med barnepris */
					temp[j] = new Ståbillett(Navn, Barnepris);
					Inntekt += temp[j].Pris;
				}
				Console.WriteLine("[" + Navn + "]: Kvittering: " + antall + " billetter solgt");
				return temp;
			}

			Console.WriteLine("[" + Navn + "]: Oppgitt antall (" + antall + ") billetter kan ikke selges");
			return null;
		}

		public virtual Billett[] KjøpBillett(String[] listeVoksne, String[] listeBarn)
		{
			bool kanSelges = false;
			if (listeBarn != null || listeVoksne != null)
			{
				if (listeVoksne.Length != 0 || listeBarn.Length != 0)
				{
					kanSelges = SelgPlasser(listeBarn.Length + listeVoksne.Length).Key;
				}
			}

			int antall = 0;
			if (listeVoksne != null)
			{
				antall += listeVoksne.Length;
			}

			if (listeBarn != null)
			{
				antall += listeBarn.Length;
			}

			Sittebillett n = SelgPlasser(antall).Value;
			if (kanSelges)
			{
				Billett[] temp = new Sittebillett[antall];
				int teller = n.PlassNr + 1;
				for (int i = 0; i < listeVoksne.Length; i++)
				{
					Sittebillett b = new Sittebillett(Navn, Pris, n.Rad, teller);
					temp[i] = b;
					Inntekt += Pris;
				}

				for (int j = listeVoksne.Length; j < temp.Length; j++)
				{
					Sittebillett barneBillett = SelgPlasser(listeBarn.Length).Value;
					temp[j] = barneBillett;
					Inntekt += Barnepris;
				}

				Console.WriteLine("[" + Navn + "]: Kvittering: " + antall + " billetter solgt.");
				return temp;
			}

			if (antall > 0)
			{
				Console.WriteLine("[" + Navn + "]: Oppgitt antall (" + antall + ") billetter kan ikke selges på samme rad.");
			} else if (antall == 0)
			{
				Console.WriteLine("[" + Navn + "] Bestillingslisten er tom, ingen kjøp er registrert");
			}

			return null;
		}

		private KeyValuePair<bool, Sittebillett> SelgPlasser(int antall)
		{
			int kapasitetPerRad = Kapasitet / AntallRader;
			int i = 0;
			while (i < AntallRader && antallSolgtPrRad[i] + antall > kapasitetPerRad) i++;
			if (i < AntallRader)
			{
				antallSolgtPrRad[i] += antall;
				return new KeyValuePair<bool, Sittebillett>(true, new Sittebillett(Navn, Pris, i, antallSolgtPrRad[i]));
			}

			return new KeyValuePair<bool, Sittebillett>(false, null);
		}

		public override string ToString() 
        {
            return base.ToString()+" Antall rader er " + AntallRader + ".";
        }
    }

	public class VIPTribune : Sittetribune 
	{
		private string[,] _tilskuer;
		private int _rad, _plass, _antPrRad;

		public VIPTribune(string navn, double pris, int kap, int antRader)
			: base(navn, pris, kap, antRader) 
		{
			_antPrRad = Kapasitet / AntallRader;
			_tilskuer = new string[AntallRader , _antPrRad];
			_rad = _plass = 0;
		}

		public override Billett[] KjøpBillett(String[] listeVoksne, String[] listeBarn)
		{
			LeggTilTilskuer(listeVoksne);
			LeggTilTilskuer(listeBarn);
			return base.KjøpBillett(listeVoksne, listeBarn);
		}

		private void LeggTilTilskuer(String[] liste)
		{
			if (liste == null)
			{
				Console.WriteLine("Ingen tilskuere å legge til.");
			}
			else
			{
				for (int i = 0; i < liste.Length; i++)
				{
					if (KanSelges(i))
					{
						_tilskuer[_rad, _plass] = liste[i];
						_plass++;
						if (_plass == _antPrRad - 1)
						{
							_plass = 0;
							_rad++;
						}
					}
					else
					{
						Console.WriteLine("[" + Navn + "]: Utsolgt. Kan ikke selge billett til følgende navn i listen: " + liste[i]);
					}
				}
			}
		}

		private bool KanSelges(int i)
		{
			bool temp = i < _antPrRad && _rad < AntallRader;
			return temp;
		}

		public override string ToString()
		{
			String temp = Navn + "\nTilskuere";
			for (int i = 0; i < AntallRader; i++)
			{
				for (int j = 0; j < _antPrRad; j++)
				{
					temp += _tilskuer[i, j];
					if (i != _antPrRad - 1)
					{
						temp += " | ";
					}
				}
			}
			return temp == "" ? "Ingenting å vise" : temp;
		}

		protected override double Barnepris
		{
			get { return Pris; }
			set { base.Barnepris = value; }
		}
	}

}

