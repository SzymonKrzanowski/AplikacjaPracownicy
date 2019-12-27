using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlas
{
    public class Sortowanie
    {
        public class PoNazwisku : IComparer<Pracownik>
        {
            public int Compare(Pracownik x, Pracownik y)
            {
                return x.Nazwisko.CompareTo(y.Nazwisko);
            }
        }

        public class PoImieniu : IComparer<Pracownik>
        {
            public int Compare(Pracownik x, Pracownik y)
            {
                return x.Imie.CompareTo(y.Imie);
            }
        }

        public class PoDacieUrodzenia : IComparer<Pracownik>
        {
            public int Compare(Pracownik x, Pracownik y)
            {
                return x.DataUrodzenia.Rok.CompareTo(y.DataUrodzenia.Rok);
            }
        }

        public class PoAdresie : IComparer<Pracownik>
        {
            public int Compare(Pracownik x, Pracownik y)
            {
                return x.AdresZamieszkania.Miasto.CompareTo(y.AdresZamieszkania.Miasto);
            }
        }

        public class PoZawodzie : IComparer<Pracownik>
        {
            public int Compare(Pracownik x, Pracownik y)
            {
                return x.Zawod.CompareTo(y.Zawod);
            }
        }



       
    }
}
