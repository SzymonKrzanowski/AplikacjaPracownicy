using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlas
{
    class Lekarz : Pracownik
    {
        private string specjalizacja;
        private string tytul;

        public string  Specjalizacja
        {
            get { return specjalizacja; }
            set { specjalizacja = value; }
        }
        public string Tytul
        {
            get { return tytul; }
            set { tytul = value; }
        }

        public override Zawody Zawod
        {
            get { return Zawody.Lekarz; }
        }

        public Lekarz():base()
        {
            this.specjalizacja = "";
            this.tytul = " ";
        }

        public Lekarz(string imie, string nazwisko, Data dataUrodzenia, Adres adresZamieszkania, string specjalizacja, string tytul) : base(imie, nazwisko, dataUrodzenia, adresZamieszkania)
        {
            this.specjalizacja = specjalizacja;
            this.tytul = tytul;
        }

        public Lekarz(Lekarz wzor) : base(wzor)
        {
            specjalizacja = wzor.specjalizacja;
            tytul = wzor.tytul;
        }

        public override Pracownik Clone()
        {
            return new Lekarz(this);
        }
        public override string SzczegolyZawodu()
        {
            return specjalizacja + "\t" + tytul;
        }
        public override string ToString()
        {
            return String.Format("{0} {1} {2}", base.ToString(), specjalizacja, tytul);
        }
        public override string FormatWyjsciowy()
        {
            return String.Format("Zawód: {0} \n {1} Dane dodatkowe {2} {3}", this.Zawod, base.FormatWyjsciowy(), specjalizacja, tytul);
        }

        public override void OdczytConsole()
        {
            base.OdczytConsole();
            Console.WriteLine("Podaj specjalizacje: ");
            specjalizacja = Console.ReadLine();
            Console.WriteLine("Podaj tytul ");
            tytul = Console.ReadLine();
        }

        public override void ZapisConsole()
        {
            Console.WriteLine(this.FormatWyjsciowy());

        }

        public override void OdczytXml(DataRow dr)
        {
            base.OdczytXml(dr);
            string[] szczegolyZawodu = dr.ItemArray[4].ToString().Split('\t');
            this.specjalizacja = szczegolyZawodu[0];
            this.tytul = szczegolyZawodu[1];
        }
    }
}
