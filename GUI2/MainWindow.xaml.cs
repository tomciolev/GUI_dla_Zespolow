using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using cwiczenia2;
using System.Windows.Forms;

namespace GUI2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Zespol zespol;
        public MainWindow()
        {
            InitializeComponent();
            zespol = (Zespol)Zespol.OdczytajXML(@"C:\Users\tomec\Desktop\GUI_dla_Zespolu-master\cwiczenia2\bin\Debug\zespolxml.xml"); // nazwa pliku + właściwa ścieżka!
            if (zespol is object)
            {
                lstCzlonkowie.ItemsSource = new ObservableCollection<CzlonekZespolu>(zespol.czlonkowie);
                txtNazwa.Text = zespol.Nazwa;
                txtKierownik.Text = zespol.kierownik.ToString();
            }

        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            CzlonekZespolu cz = new CzlonekZespolu();
            OsobaWindow okno = new OsobaWindow(cz);
            bool? result = okno.ShowDialog();
            if (result == true)
            {
                zespol.DodajCzlonka(cz); //dodajemy członka
                lstCzlonkowie.ItemsSource = new ObservableCollection<CzlonekZespolu>(zespol.czlonkowie);
                //kolekcja.Add(cz);
                //lstCzlonkowie.Items.Refresh();
            }

        }

        private void ZmienButton_Click(object sender, RoutedEventArgs e)
        {
            OsobaWindow okno = new OsobaWindow(zespol.kierownik);
            bool? result = okno.ShowDialog();
            if (result == true)
            {
                txtKierownik.Text = zespol.kierownik.ToString();
            }

        }
        private void UsunButton_Click(object sender, RoutedEventArgs e)
        {
            if (lstCzlonkowie.SelectedIndex > -1)
            {
                for(int i=0;i<=lstCzlonkowie.SelectedItems.Count;i++)
                {
                    zespol.UsunCzlonka((CzlonekZespolu)(lstCzlonkowie.SelectedItem));
                    lstCzlonkowie.ItemsSource = new ObservableCollection<CzlonekZespolu>(zespol.czlonkowie);
                }
                
            }
        }
        private void MenuZapiszClick(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                zespol.Nazwa = txtNazwa.Text;
                Zespol.ZapiszXML(filename, zespol);
            }

        }
        private void MenuOtworzClick(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                Zespol z = new Zespol();
                z = Zespol.OdczytajXML(filename);
                txtKierownik.Text = z.kierownik.ToString();
                txtNazwa.Text = z.Nazwa;
                lstCzlonkowie.ItemsSource = new ObservableCollection<CzlonekZespolu>(z.czlonkowie);
            }

        }
        private void SortujPoPESELButton_Click(object sender, RoutedEventArgs e)
        {
            //lstCzlonkowie.Items.SortDescriptions.Add(new SortDescription("PESEL", ListSortDirection.Ascending));
            zespol.SortujPoPESEL();
            lstCzlonkowie.ItemsSource = new ObservableCollection<CzlonekZespolu>(zespol.czlonkowie);
        }

        private void SortujButton_Click(object sender, RoutedEventArgs e)
        {
            //lstCzlonkowie.Items.SortDescriptions.Add(new SortDescription("Imie", ListSortDirection.Ascending));
            //lstCzlonkowie.Items.SortDescriptions.Add(new SortDescription("Nazwisko", ListSortDirection.Ascending));
            zespol.Sortuj();
            lstCzlonkowie.ItemsSource = new ObservableCollection<CzlonekZespolu>(zespol.czlonkowie);
        }
        private void ZnajdzButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (CzlonekZespolu czlonek in lstCzlonkowie.Items)
            {
                if (czlonek.funkcja == txtFunkcjaSzukaj.Text)
                    lstCzlonkowie.SelectedItems.Add(czlonek);
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Dokonałeś zmiany w pliku, czy chcesz je zapisać?", "Ostrzeżenie", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == System.Windows.MessageBoxResult.No)
                e.Cancel = false;
        }
    }
}
