using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlas
{
    class Informatyk : Pracownik
    {
        private string adresEmail;
        private string stronaInternetowa;

        public string AdresEmail
        {
            get { return adresEmail; }
            set { adresEmail = value; }
        }

        public string StronaInternetowa
        {
            get { return stronaInternetowa; }
            set { stronaInternetowa = value; }
        }

        public override Zawody Zawod
        {
            get { return Zawody.Informatyk; }

        }

        public Informatyk() : base()
        {
            this.adresEmail = " ";
            this.stronaInternetowa = " ";

        }

        public Informatyk(string imie, string nazwisko, Data dataUrodzenia, Adres adresZamieszkania, string adresEmail, string stronaInternetowa) : base(imie, nazwisko, dataUrodzenia, adresZamieszkania)
        {
            this.adresEmail = adresEmail;
            this.stronaInternetowa = stronaInternetowa;
        }

        public Informatyk(Informatyk wzorzec) : base(wzorzec)
        {
            adresEmail = wzorzec.adresEmail;
            stronaInternetowa = wzorzec.stronaInternetowa;
        }

        public override Pracownik Clone()
        {
            return new Informatyk(this);
        }

        public override string SzczegolyZawodu()
        {
            return AdresEmail + "\t" + StronaInternetowa;
        }

        public override string ToString()
        {
            return base.Imie + base.Nazwisko + base.DataUrodzenia.Dzien + base.DataUrodzenia.Miesiac + base.DataUrodzenia.Rok + base.AdresZamieszkania.Ulica + base.AdresZamieszkania.NumerDomu
                +base.AdresZamieszkania.Miasto + adresEmail + stronaInternetowa;
        }

        public override string FormatWyjsciowy()
        {
            return String.Format("Zawód: {0} \n {1} Dane dodatkowe {2} {3}", this.Zawod, base.FormatWyjsciowy(), adresEmail, stronaInternetowa);
        }
        public override void OdczytConsole()
        {
            base.OdczytConsole();
            Console.WriteLine("Podaj adres email: ");
            adresEmail = Console.ReadLine();
            Console.WriteLine("Podaj strone www ");
            stronaInternetowa = Console.ReadLine();
        }

        public override void ZapisConsole()
        {
            Console.WriteLine(this.FormatWyjsciowy());
        }

        public override void OdczytXml(DataRow dr)
        {
            base.OdczytXml(dr);
            string[] szczegolyZawodu = dr.ItemArray[4].ToString().Split('\t');
            this.adresEmail = szczegolyZawodu[0];
            this.stronaInternetowa = szczegolyZawodu[1];
        }

    }
}