using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlas
{
    public class Pracownik
    {
        private string imie;
        private string nazwisko;
        private Data dataUrodzenia;
        private Adres adresZamieszkania;


        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }

        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }

        public Data DataUrodzenia
        {
            get { return dataUrodzenia; }
        }

        public Adres AdresZamieszkania
        {
            get { return adresZamieszkania; }
        }

        virtual public Zawody Zawod
        {
            get { return Zawody.Pracownik; }
        }

        public Pracownik()
        {
            dataUrodzenia = new Data();
            adresZamieszkania = new Adres();

        }

        public Pracownik(string i, string nazwisko, Data dataUrodzenia, Adres adresZamieszkania)
        {
            this.imie = i;
            this.nazwisko = nazwisko;
            this.dataUrodzenia = new Data(dataUrodzenia);
            this.adresZamieszkania = new Adres(adresZamieszkania);

        }

        public Pracownik(Pracownik poprzedniPracownik)
        {
            imie = poprzedniPracownik.imie;
            nazwisko = poprzedniPracownik.nazwisko;
            dataUrodzenia = new Data(poprzedniPracownik.dataUrodzenia);
            adresZamieszkania = new Adres(poprzedniPracownik.adresZamieszkania);

        }

        virtual public Pracownik Clone()
        {

            return new Pracownik(this);

        }

        public override string ToString()
        {
            return imie + " " + nazwisko + " " + dataUrodzenia.ToString() + " " + adresZamieszkania.ToString();
        }

        public virtual string FormatWyjsciowy()
        {
            return "Imie, nazwisko: " + imie + " " + nazwisko + "\n Data urodzenia: " + dataUrodzenia.ToString() +
                "\n Adres zamieszkania: " + adresZamieszkania.ToString();
        }

        public virtual string SzczegolyZawodu()
        {
            return "brak";

        }

        public string DataToString()
        {
            return dataUrodzenia.ToString();
        }

        public string AdresToString()
        {
            return adresZamieszkania.ToString();
        }

        public virtual void OdczytConsole()
        {
            Console.Write("Podaj imie pracownika: ");
            imie = Console.ReadLine();
            Console.Write("Podaj nazwisko pracownika: ");
            nazwisko = Console.ReadLine();
            Console.Write("Podaj dzien urodzenia pracownika: ");
            dataUrodzenia.Dzien = int.Parse(Console.ReadLine());
            Console.Write("Podaj miesiac urodzenia pracownika: ");
            dataUrodzenia.Miesiac = Console.ReadLine();
            Console.Write("Podaj rok urodzenia pracownika: ");
            dataUrodzenia.Rok = int.Parse(Console.ReadLine());
            Console.Write("Podaj adres zamieszkania pracownika \n ");
            Console.Write("Ulica ");
            adresZamieszkania.Ulica = Console.ReadLine();
            Console.Write("Numer domu ");
            adresZamieszkania.NumerDomu = Console.ReadLine();
            Console.Write("Miasto ");
            adresZamieszkania.Miasto = Console.ReadLine();

        }

        public virtual void ZapisConsole()
        {

            Console.WriteLine(FormatWyjsciowy());
            
        }
        public virtual void OdczytXml(DataRow dr)
        {
            this.imie = dr.ItemArray[0].ToString();
            this.nazwisko = dr.ItemArray[1].ToString();
            string[] data = dr.ItemArray[2].ToString().Split(' ');
            dataUrodzenia.Dzien = Int32.Parse(data[0]);
            dataUrodzenia.Miesiac = data[1];
            dataUrodzenia.Rok = Int32.Parse(data[2]);
            string[] adres = dr.ItemArray[3].ToString().Split(' ');
            adresZamieszkania.Ulica = adres[0];
            adresZamieszkania.NumerDomu = adres[1];
            adresZamieszkania.Miasto = adres[2];

        }


    }
}
