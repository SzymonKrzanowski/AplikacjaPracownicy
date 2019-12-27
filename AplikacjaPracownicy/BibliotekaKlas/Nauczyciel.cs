using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlas
{
    class Nauczyciel : Pracownik
    {

        private string przedmiot;
        private string tytul;

        public string Przedmiot
        {
            get { return przedmiot; }
            set { przedmiot = value; }
        }
        public string Tytul
        {
            get { return tytul; }
            set { tytul = value; }
        }

        public override Zawody Zawod
        {
            get
            {
                return Zawody.Nauczyciel;
            }
        }

        public Nauczyciel() : base()
        {
            this.przedmiot = " ";
            this.tytul = " ";

        }

        public Nauczyciel(string imie, string nazwisko, Data dataUrodzenia, Adres adresZamieszkania, string przedmiot, string tytul) : base(imie, nazwisko, dataUrodzenia, adresZamieszkania)
        {
            this.przedmiot = przedmiot;
            this.tytul = tytul;
        }

        public Nauczyciel(Nauczyciel wzor) : base(wzor)
        {
            przedmiot = wzor.przedmiot;
            tytul = wzor.tytul;
        }

        public override Pracownik Clone()
        {
            return new Nauczyciel(this);
        }

        public override string SzczegolyZawodu()
        {
            return przedmiot + "\t" + tytul;
        }

        public override string ToString()
        {
            return String.Format("{0}  {1}  {2}", base.ToString(), przedmiot, tytul);
        }
        public override string FormatWyjsciowy()
        {
            return String.Format("Zawód: {0} \n {1} Dane dodatkowe {2} {3}", this.Zawod, base.FormatWyjsciowy(), przedmiot, tytul);
        }

        public override void OdczytConsole()
        {
            base.OdczytConsole();
            Console.WriteLine("Podaj przedmiot: ");
            przedmiot = Console.ReadLine();
            Console.WriteLine("Podaj tytul ");
            tytul = Console.ReadLine();
        }

        public override void ZapisConsole()
        {
            base.OdczytConsole();
            Console.WriteLine(przedmiot);
            Console.WriteLine(tytul);
        }

        public override void OdczytXml(DataRow dr)
        {
            base.OdczytXml(dr);
            string[] szczegolyZawodu = dr.ItemArray[4].ToString().Split('\t');
            this.przedmiot = szczegolyZawodu[0];
            this.tytul = szczegolyZawodu[1];
        }
    }
}
