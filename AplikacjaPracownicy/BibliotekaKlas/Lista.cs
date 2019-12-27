using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlas
{
    public class Lista
    {
        private List<Pracownik> lista;
        public Lista()
        {
            lista = new List<Pracownik>();
        }

        public void Dodaj(Pracownik pracownik)
        {
            lista.Add(pracownik.Clone());
        }

        public void WstawPolozenie(int index, Pracownik pracownik)
        {
            lista.Insert(index, pracownik);
        }

        public int Usun(string nazwisko)
        {

            int ind = lista.FindIndex(Pracownik => Pracownik.Nazwisko.Equals(nazwisko));
            if (ind >= 0)
                lista.RemoveAt(ind);

            return ind;

        }

        public void Usun(int indeks)
        {
            if (indeks < 0)
            {
                Console.Write("Niepoprawny indeks!");
            }
            lista.RemoveAt(indeks);

        }

        public Pracownik Szukaj(string nazwisko)
        {
            foreach (Pracownik p in lista)
            {
                if (p.Nazwisko.Equals(nazwisko))
                {
                    return p;
                }
            }
            return null;
        }


        public void Sortuj(IComparer<Pracownik> icc)
        {
            lista.Sort(icc);
        }

        //public void Sortuj()
        //{

        //    IComparer<Pracownik> icc;
        //    icc = new Sortowanie.PoNazwisku();
        //    Lista lista = new Lista();
        //    lista.Sortuj(icc);
        //    icc = new Sortowanie.PoZawodzie();
        //    lista.Sortuj(icc);
        //    icc = new Sortowanie.PoAdresie();
        //    lista.Sortuj(icc);
        //    icc = new Sortowanie.PoImieniu();
        //    lista.Sortuj(icc);
        //    icc = new Sortowanie.PoImieniu();
        //    lista.Sortuj(icc);

        //}

        public void ZapisConsole()
        {
            foreach (Pracownik p in lista)
            {
                p.ZapisConsole();
            }

        }

        public void OdczytConsole()
        {
            Pracownik pracownik = new Pracownik();
            Console.WriteLine("Podaj typ pracownika");
            Console.WriteLine("i - Informatyk");
            Console.WriteLine("l - Lekarz");
            Console.WriteLine("n - Nauczyciel");
            Console.WriteLine("q - Wyjscie");
            char typ = char.Parse(Console.ReadLine());
            switch (typ)
            {
                case 'i':
                    {
                        pracownik = new Informatyk();
                        break;
                    }
                case 'l':
                    {
                        pracownik = new Lekarz();
                        break;
                    }
                case 'n':
                    {
                        pracownik = new Nauczyciel();
                        break;
                    }
                case 'q':
                    {
                        return;
                    }

            }
            pracownik.OdczytConsole();
            lista.Add(pracownik);

        }

        public void Wyczysc()
        {
            lista.Clear();
        }

        public int Rozmiar
        {
            get
            {
                return lista.Count;
            }
        }


        public Pracownik this[int i]
        {
            get
            {
                return lista[i];
            }
        }

        FormatDanych df = new FormatDanych();

        public void OdczytXml()
        {
            lista = df.OdczytXML();
        }

        public void ZapisXml()
        {
            df.ZapisXML(lista);
        }

        public string SciezkaDoPliku
        {
            get { return df.Sciezka; }
            set { df.Sciezka = value; }
        }

    }
}