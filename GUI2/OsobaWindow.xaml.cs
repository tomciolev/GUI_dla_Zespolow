using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using cwiczenia2;
namespace GUI2
{
    /// <summary>
    /// Logika interakcji dla klasy OsobaWindow.xaml
    /// </summary>
    public partial class OsobaWindow : Window
    {
        Osoba osoba;
        public OsobaWindow()
        {
            InitializeComponent();
            txtFunkcja.IsEnabled = false;
            txtDoswiadczenie.IsEnabled = false;

        }
        public OsobaWindow(Osoba os) : this()
        {
            osoba = os;
            if (osoba is KierownikZespolu osobaKierownik)
            {
                txtDoswiadczenie.IsEnabled = true;
                txtPESEL.Text = osobaKierownik.PESEL;
                txtImie.Text = osobaKierownik.Imie;
                txtNazwisko.Text = osobaKierownik.Nazwisko;
                txtDataUrodzenia.Text = $"{osobaKierownik.DataUrodzenia:dd-MMM-yyyy}";
                txtDoswiadczenie.Text = osobaKierownik.Doswiadczenie.ToString();
                cmbPlec.Text = (osobaKierownik.plec == Plcie.K) ? "Kobieta" : "Mężczyzna";
            }
            else
            {
                txtFunkcja.IsEnabled = true;
            }
        }

        private void ZatwierdzButton_Click(object sender, RoutedEventArgs e)
        {
            if(osoba is KierownikZespolu)
            {
                ((KierownikZespolu)osoba).Doswiadczenie = int.Parse(txtDoswiadczenie.Text);
            }
            if(osoba is CzlonekZespolu)
            {
                ((CzlonekZespolu)osoba).funkcja = txtFunkcja.Text;
            }
            osoba.PESEL = txtPESEL.Text;
            osoba.Imie = txtImie.Text;
            osoba.Nazwisko = txtNazwisko.Text;
            DateTime.TryParseExact(txtDataUrodzenia.Text, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy" }, null, DateTimeStyles.None, out DateTime date);
            osoba.DataUrodzenia = date;
            if (cmbPlec.Text == "Kobieta")
                osoba.plec = Plcie.K;
            else
                osoba.plec = Plcie.M;
            DialogResult = true; // zeby działał przycisk i wykonywał swoje zadanie
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }

    
}
