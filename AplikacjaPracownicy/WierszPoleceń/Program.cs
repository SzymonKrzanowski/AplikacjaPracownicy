using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekaKlas;

namespace WierszPolecen
{
    class Program
    {
                static void Main(string[] args)
        {
            //Data d1 = new Data(12, "maj", 1999);
            //Adres a1 = new Adres("Podkarpacka", "2A", "Rzeszów");
            //Pracownik p1 = new Pracownik("Jan", "Kowalski", d1, a1);

            //Data d2 = new Data();
            //Adres a2 = new Adres();
            //Pracownik p2 = new Pracownik();

            //Data d3 = new Data(d1);
            //Adres a3 = new Adres(a1);
            //Pracownik p3 = new Pracownik(p1);

            Lista lista = new Lista();
            bool stay = true;
            while (stay)
            {
                Console.WriteLine("***************\n");
                Console.WriteLine("1. Dodaj pracownika.\n");
                Console.WriteLine("2. Wstaw pracownika.\n");
                Console.WriteLine("3. Usun pracownika.\n");
                Console.WriteLine("4. Wyszukaj pracownika.\n");
                Console.WriteLine("5. Sortowanie\n");
                Console.WriteLine("6. Wyswietl wszystkich\n");
                Console.WriteLine("7. Wyczyść liste.\n ");
                Console.WriteLine("8. Odczyt.\n");
                Console.WriteLine("9. Zapis.\n");
                Console.WriteLine("10. Wyjdz.\n");
                Console.WriteLine("***************");
                Console.WriteLine("-->: ");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        {

                            lista.OdczytConsole();
                            Console.WriteLine("Dodano pracownika. \n");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Podaj index: ");
                            int inx = int.Parse(Console.ReadLine());
                            Console.WriteLine("Dodaj pracownika: ");
                            Pracownik tmp = new Pracownik();
                            tmp.OdczytConsole();
                            lista.WstawPolozenie(inx, tmp);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Podaj nazwisko lub index: ");
                            string u = Console.ReadLine();
                            int inx;
                            bool check = int.TryParse(u, out inx);
                            if (check)
                                lista.Usun(inx);
                            else
                                Console.WriteLine("Usunieto pracownika o indexie:" + lista.Usun(u));
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Podaj nazwisko: ");
                            string naz = Console.ReadLine();
                            Pracownik tmp = lista.Szukaj(naz);
                            Console.WriteLine(tmp.FormatWyjsciowy());
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Sortowanie po nazwisku/zawodzie? -- n/z");
                            string check = Console.ReadLine();
                            if (check == "n")
                            {
                                IComparer<Pracownik> ic;
                                ic = new Sortowanie.PoNazwisku();
                                lista.Sortuj(ic);
                            }
                            else
                            {
                                IComparer<Pracownik> ic;
                                ic = new Sortowanie.PoZawodzie();
                                lista.Sortuj(ic);
                            }
                            break;
                        }
                    case 6:
                        {   
                            
                            lista.ZapisConsole();
                            break;
                        }
                    case 7:
                        {
                            lista.Wyczysc();
                            Console.WriteLine("Lista pusta!");
                            break;
                        }
                    case 8:
                        {
                            lista.OdczytXml();
                            break;
                        }
                    case 9:
                        {
                            lista.ZapisXml();
                            break;
                        }
                    case 10:
                        {
                            stay = false;
                            break;
                        }
                    default:
                        {
                            stay = false;
                            break;
                        }
                }
            }
        }
  
    }
}