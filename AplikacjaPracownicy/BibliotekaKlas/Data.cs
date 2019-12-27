using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlas
{
    public class Data
    {
        private int dzien;
        private string miesiac;
        private int rok;
        static readonly string[] miesiace = {"Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec", "Lipiec", "Sierpień", "Wrzesien", "Pazdziernik", "Listopad", "Grudzien" };

        public int Dzien
        {
            get { return dzien; }
            set { dzien = value; }
        }

        public string Miesiac
        {
            get { return miesiac; }
            set {
                miesiac = value;
            }
        }

        public int Rok
        {
            get { return rok; }
            set { rok = value; }
        }

        public Data()
        {

        }

        public Data(int dzien, string miesiac, int rok)
        {
            this.dzien = dzien;
            this.miesiac = miesiac;
            this.rok = rok;

        }
        public Data(Data d)
        {
            dzien = d.dzien;
            miesiac = d.miesiac;
            rok = d.rok;
        }

        public override string ToString()
        {
            return dzien + " " + miesiac + " " + rok;
        }

        public static string ZwrocMiesiac(int miesiac)
        {
            return "Miesiac: " + miesiace[miesiac - 1]; 
        }

    }
}
