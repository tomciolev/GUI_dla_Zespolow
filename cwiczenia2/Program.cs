using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia2
{
    class Program
    {
        static void Main(string[] args)
        {
            CzlonekZespolu czlonek01 = new CzlonekZespolu("Witold", "Jarmuz", "1992-10-27", "92102201347", Plcie.M, "projektant", "01-sty-2020");
            CzlonekZespolu czlonek02 = new CzlonekZespolu("Witold", "Adamski", "1992.10.22", "92102266738", Plcie.M, "sekretarz", "01-sty-2020");
            CzlonekZespolu czlonek03 = new CzlonekZespolu("Jan", "But", "10/05/1992", "92051613915", Plcie.M, "programista", "01-cze-2019");
            CzlonekZespolu czlonek04 = new CzlonekZespolu("Beata", "But", "22/11/1993", "93112225023", Plcie.K, "projektant", "01-cze-2019");
            CzlonekZespolu czlonek05 = new CzlonekZespolu("Anna", "Myszka", "22.07.1991", "91072235964", Plcie.K, "projektant", "01-lip-2019");
            CzlonekZespolu nieczlonek = new CzlonekZespolu("Jas", "Fasola", "18.04.2002", "01333365732", Plcie.M, "nikt", "22-sty-2020");
            KierownikZespolu kierownik01 = new KierownikZespolu("Adam", "Kowalski", "1990-07-01", "90070100211", Plcie.M, 5);
            Zespol GrupaIT = new Zespol("GrupaIT", kierownik01);
            GrupaIT.DodajCzlonka(czlonek01);
            GrupaIT.DodajCzlonka(czlonek02);
            GrupaIT.DodajCzlonka(czlonek03);
            GrupaIT.DodajCzlonka(czlonek04);
            Console.WriteLine(GrupaIT.ToString());
            //klonowanie
            Zespol NowaGrupa = new Zespol();
            KierownikZespolu kierownik02 = new KierownikZespolu("Rafał", "Marzec", "1999-09-21", "88032112357", Plcie.M, 6);
            NowaGrupa = (Zespol)GrupaIT.Clone();
            NowaGrupa.Nazwa = "NowaGrupa";
            NowaGrupa.Kierownik = kierownik02;
            Console.WriteLine(NowaGrupa.ToString());
            //sortowanie
            NowaGrupa.Sortuj();
            Console.WriteLine(NowaGrupa.ToString());
            NowaGrupa.SortujPoPESEL();
            Console.WriteLine(NowaGrupa.ToString());
            NowaGrupa.SortujPoFunkcji();
            Console.WriteLine(NowaGrupa.ToString());
            //porównywanie obiektów
            Console.WriteLine(czlonek01.Equals(czlonek01));
            Console.WriteLine(NowaGrupa.JestCzlonkiem(nieczlonek));
            //zapisywanie i wczytywanie danych
            NowaGrupa.ZapiszBin("zespol.bin");
            Zespol NowyZespol = new Zespol();
            NowyZespol = (Zespol)NowaGrupa.OdczytajBin("zespol.bin");
            Console.WriteLine("NowaGrupa");
            Console.WriteLine(NowaGrupa.ToString());
            Console.WriteLine("NowyZespol - serializowany binarnie");
            Console.WriteLine(NowyZespol.ToString());
            Zespol.ZapiszXML("zespolxml.xml",NowyZespol);
            Zespol NowyZespol2 = new Zespol();
            Console.WriteLine("NowyZespol2 - serializowany xml");
            NowyZespol2 = Zespol.OdczytajXML("zespolxml.xml");
            Console.WriteLine(NowyZespol2.ToString());
            //siemanko
            Console.ReadKey();
        }
    }
}
