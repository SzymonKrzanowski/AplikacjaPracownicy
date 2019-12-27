using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlas
{
    public class FormatDanych
    {
        private string sciezka= @"D:\Metody i techniki programowania\Szymon Krzanowski\AplikacjaPracownicy\WierszPoleceń\pracownicy.xml";
        private DataSet ds;
        private DataTable dt;

        public string Sciezka
        {
            get { return sciezka; }
            set { sciezka = value; }

        }


        public void InicjalizujKomponent()
        {
            ds = new DataSet();
            dt = new DataTable("Pracownicy");
            StworzKolumny();

        }

        public FormatDanych()
        {
            InicjalizujKomponent();
        }

        public void StworzKolumny()
        {
            dt.Columns.Add("Imię", typeof(String));
            dt.Columns.Add("Nazwisko", typeof(String));
            dt.Columns.Add("Data Urodzenia", typeof(String));
            dt.Columns.Add("Adres Zamieszkania", typeof(String));
            dt.Columns.Add("Dane Szczegółowe", typeof(String));
            dt.Columns.Add("Zawód", typeof(String));
            ds.Tables.Add(dt);
        }

        public void ZapisXML(List<Pracownik> lista)
        {
            InicjalizujKomponent();
            WypelnijTabele(lista);
            ds.WriteXml(this.sciezka);
            //ds.ReadXml(this.Sciezka);
        }
        
        public void WypelnijTabele(List<Pracownik> lista)
        {
            dt.Rows.Clear();
            DataRow dr;
            foreach(Pracownik p in lista)
            {
                dr = dt.NewRow();
                dr["Imię"] = p.Imie;
                dr["Nazwisko"] = p.Nazwisko;
                dr["Data Urodzenia"] = p.DataToString();
                dr["Adres Zamieszkania"] = p.AdresZamieszkania;
                dr["Dane szczegółowe"] = p.SzczegolyZawodu();
                dr["Zawód"] = p.Zawod.ToString();
                dt.Rows.Add(dr);
            }
        }

        public List<Pracownik> OdczytXML()
        {
            List<Pracownik> lista = new List<Pracownik>();
            ds = new DataSet();
            ds.ReadXml(this.sciezka);
            Pracownik p = new Pracownik();
            foreach(DataTable dt in ds.Tables)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    switch ((dr["Zawód"]).ToString())
                    {
                        case "Informatyk":
                            {
                                p = new Informatyk();
                                break;
                            }
                        case "Nauczyciel":
                            {
                                p = new Nauczyciel();
                                break;
                            }
                        case "Lekarz":
                            {
                                p = new Lekarz();
                                break;
                            }

                    }
                    p.OdczytXml(dr);
                    lista.Add(p);
                    Console.WriteLine(p.FormatWyjsciowy());
                }
            }


            return lista;
        }
    }
}
