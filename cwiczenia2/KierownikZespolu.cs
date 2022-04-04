using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cwiczenia2
{
    [Serializable]
    public class KierownikZespolu : Osoba, ICloneable
    {
        int doswiadczenie;
        public int Doswiadczenie { get => doswiadczenie; set => doswiadczenie = value; }
        public KierownikZespolu() { }
        public KierownikZespolu(string imie, string nazwisko, string dataUrodzenia, string pesel, Plcie plec, int doswiadczenie) :
            base(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            this.doswiadczenie = doswiadczenie;
        }
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(_imie).Append(" ").Append(_nazwisko).Append(" ").Append(_dataUrodzenia.ToString("dd.MM.yyyy")).Append(" ").Append(_PESEL).Append(" ").Append(plec).Append(" ").Append(doswiadczenie);
            return info.ToString();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
