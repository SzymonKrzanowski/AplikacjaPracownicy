using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlas
{
    public class Adres
    {
        private string ulica;
        public string Ulica
        {
            get { return ulica; }
            set { ulica = value; }
        }

        private string numerDomu;
        public string NumerDomu
        {
            get { return numerDomu; }
            set
            {
                numerDomu = value;
            }

        }
        private string miasto;
        public string Miasto
        {
            get { return miasto; }
            set { miasto = value; }
        }

        public Adres()
        {

        }
        public Adres(string ulica, string numerDomu, string miasto)
        {
            this.ulica = ulica;
            this.numerDomu = numerDomu;
            this.miasto = miasto;
        }

        public Adres(Adres poprzedniAdres)
        {
            ulica = poprzedniAdres.ulica;
            numerDomu = poprzedniAdres.numerDomu;
            miasto = poprzedniAdres.miasto;
        }
        public override string ToString()
        {
            return ulica + " " + numerDomu + " " + miasto;
        }
    }
}
