using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace cwiczenia2
{
    
    class PESELComparator : Comparer<CzlonekZespolu> //komparator
    {
        public override int Compare(CzlonekZespolu x, CzlonekZespolu y)
        {
            return x.PESEL.CompareTo(y.PESEL);
        }
    }
    class FunkcjaComparator : Comparer<CzlonekZespolu>
    {
        public override int Compare(CzlonekZespolu x, CzlonekZespolu y)
        {
            return x.Funkcja.CompareTo(y.Funkcja);
        }
    }
    [Serializable]
    public class Zespol : ICloneable, IZapisywalna
    {
        int liczbaCzlonkow;
        string nazwa;
        public KierownikZespolu kierownik;
        public List<CzlonekZespolu> czlonkowie;

        public Zespol()
        {
            nazwa = null;
            kierownik = null;
            liczbaCzlonkow = 0;
            Czlonkowie = new List<CzlonekZespolu>();
        }
        public Zespol(string nazwa, KierownikZespolu kierownik)
        {
            this.nazwa = nazwa;
            this.kierownik = kierownik;
            liczbaCzlonkow = 0;
            Czlonkowie = new List<CzlonekZespolu>();
        }
        public int LiczbaCzlonkow { get => liczbaCzlonkow; set => liczbaCzlonkow = value; }
        public string Nazwa { get => nazwa; set => nazwa = value; }
        internal KierownikZespolu Kierownik { get => kierownik; set => kierownik = value; }
        internal List<CzlonekZespolu> Czlonkowie { get => czlonkowie; set => czlonkowie = value; }


        public void DodajCzlonka(CzlonekZespolu c)
        {
            Czlonkowie.Add(c);
            liczbaCzlonkow++;
        }
        public void UsunCzlonka(CzlonekZespolu c)
        {
            Czlonkowie.Remove(c);
            liczbaCzlonkow--;
        }
        public override string ToString()
        {
            StringBuilder opis = new StringBuilder();
            opis.Append("Zespol: ").Append(nazwa).AppendLine().Append("Kierownik: ").Append(kierownik.ToString()).AppendLine().Append("Czlonkowie: ").Append("(").Append(liczbaCzlonkow).Append(")").AppendLine();
            foreach(CzlonekZespolu czlonek in Czlonkowie)
            {
                opis.Append(czlonek.ToString()).AppendLine();
            }
            return opis.ToString();
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public void Sortuj()
        {
            czlonkowie.Sort();
        }
        public void SortujPoPESEL()
        {
            czlonkowie.Sort(new PESELComparator());
        }
        public void SortujPoFunkcji()
        {
            czlonkowie.Sort(new FunkcjaComparator());
        }
        public bool JestCzlonkiem(CzlonekZespolu osoba)
        {
            foreach (CzlonekZespolu czlonek in czlonkowie)
            {
                if (osoba.Equals(czlonek))
                    return true;
            }
                
            return false;
        }

        public void ZapiszBin(string nazwa)
        {
            var fs = new FileStream(nazwa, FileMode.Create);
            var bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }
        public object OdczytajBin(string nazwa)
        {
            object wynik = null;
            var fs = new FileStream(nazwa, FileMode.Open);
            var bf = new BinaryFormatter();
            wynik = bf.Deserialize(fs);
            return wynik;
        }
        public static void ZapiszXML(string nazwa, Zespol zespol)
        {
            var fs = new FileStream(nazwa, FileMode.Create);
            var xmls = new XmlSerializer(typeof(Zespol));
            xmls.Serialize(fs, zespol);
            fs.Close();
        }
        public static Zespol OdczytajXML(string nazwa)
        {
            object wynik = null;
            var fs = new FileStream(nazwa, FileMode.Open);
            var xmls = new XmlSerializer(typeof(Zespol));
            wynik = xmls.Deserialize(fs);
            return wynik as Zespol;
        }
    }
    
}
