using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
//parts.ForEach(Console.WriteLine);
namespace cwiczenia2
{
    [Serializable]
    public class CzlonekZespolu : Osoba, ICloneable, IComparable<CzlonekZespolu>
    {
        DateTime dataZapisu;
        public string funkcja;
        public DateTime DataZapisu { get => dataZapisu; set => dataZapisu = value; }
        public string Funkcja { get => funkcja; set => funkcja = value; }
        public CzlonekZespolu() { }
        public CzlonekZespolu(string imie, string nazwisko, string dataUrodzenia, string pesel, Plcie plec,  string funkcja, string datazapisu) :
            base(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            DateTime date;
            if (DateTime.TryParseExact(datazapisu, new string[] {"dd/MM/yyyy", "dd.MM.yyyy", "dd-MM-yyyy", "dd-MMM-yyyy", "dd.MMM.yyyy", "dd/MMM/yyyy", "yyyy/MM/dd", "yyyy.MM.dd", "yyyy-MM-dd" }, null, DateTimeStyles.None, out date))
                dataZapisu = date;
            this.funkcja = funkcja; 
        }
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(_imie).Append("\t").Append(_nazwisko).Append("\t").Append(_dataUrodzenia.ToString("dd.MM.yyyy")).Append("\t").Append(_PESEL).Append("\t").Append(plec).Append("\t").Append(funkcja);
            return (info.ToString());
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(CzlonekZespolu other)
        {
            if (this.Nazwisko != other.Nazwisko)
                return this.Nazwisko.CompareTo(other.Nazwisko);
            else
                return this.Imie.CompareTo(other.Imie);
        }
    }
}
