using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace cwiczenia2
{
    public enum Plcie { K, M }
    [Serializable]
    public abstract class Osoba : IEquatable<Osoba>
    {
        
        public string _imie;
        public string _nazwisko;
        public string _ulica;
        public string _miasto;
        public int _kodPocztowy;
        public DateTime _dataUrodzenia;
        public string _PESEL;
        public Plcie plec;

        public string Imie
        {
            get { return _imie; }
            set { _imie = value; }
        }

        public string Nazwisko { get => _nazwisko; set => _nazwisko = value; }
        public string Ulica { get => _ulica; set => _ulica = value; }
        public string Miasto { get => _miasto; set => _miasto = value; }
        public int KodPocztowy { get => _kodPocztowy; set => _kodPocztowy = value; }
        public DateTime DataUrodzenia { get => _dataUrodzenia; set => _dataUrodzenia = value; }
        public string PESEL { get => _PESEL; set => _PESEL = value; }
        internal Plcie Plec { get => plec; set => plec = value; }
        public Osoba()
        {
            _PESEL = new string('0', 11);
        }
        public Osoba(string imie, string nazwisko)
        {
            _imie = imie;
            _nazwisko = nazwisko;
        }
        public Osoba(string imie, string nazwisko, string dataUrodzenia, string pesel, Plcie plec)
        {
            _imie = imie;
            _nazwisko = nazwisko;
            DateTime date;
            if (DateTime.TryParseExact(dataUrodzenia, new string[] { "dd/MM/yyyy", "dd/MM/yyyy", "dd.MM.yyyy", "dd-MM-yyyy", "yyyy/MM/dd", "yyyy.MM.dd", "yyyy-MM-dd" }, null, DateTimeStyles.None, out date))
                _dataUrodzenia = date;
            _PESEL = pesel;
            this.plec = plec;
        }
        public Osoba(string imie, string nazwisko, string ulica, string miasto, int kod, string dataUrodzenia, string pesel, Plcie plec)
        {
            _imie = imie;
            _nazwisko = nazwisko;
            _ulica = ulica;
            _miasto = miasto;
            _kodPocztowy = kod;
            DateTime date;
            if (DateTime.TryParseExact(dataUrodzenia, new string[] { "dd/MM/yyyy", "dd.MM.yyyy", "dd-MM-yyyy", "dd-MMM-yyyy", "dd.MMM.yyyy", "dd/MMM/yyyy", "yyyy/MM/dd", "yyyy.MM.dd", "yyyy-MM-dd" }, null, DateTimeStyles.None, out date))
                _dataUrodzenia = date;
            _PESEL = pesel;
            this.plec = plec;
        }
        public int Wiek()
        {
            return (DateTime.Now.Year - _dataUrodzenia.Year);
        }
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(_imie).Append(" ").Append(_nazwisko).Append(" ").Append(_dataUrodzenia.ToString("dd.MM.yyyy")).Append(" ").Append(_miasto).Append(" ").Append(_kodPocztowy).Append(" ");
            return info.ToString();
        }
        public void ToStringMod()
        {
            Console.WriteLine(_PESEL + " " + _imie + " " + _nazwisko + " (" + this.Wiek() + ") " + _ulica + " " + _miasto + " " + _kodPocztowy);
        }

        public bool Equals(Osoba other)
        {
            return this.PESEL.Equals(other.PESEL);
        }
    }
}
