using Project;
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

namespace GUI
{
    /// <summary>
    /// Interaction logic for DodajRezerwacje.xaml
    /// </summary>
    public partial class DodajRezerwacje : Window
    {
        private Rezerwacje r;

        public DodajRezerwacje(Rezerwacje r)
        {

            InitializeComponent();
            this.r = r;
            ComboBox_KlientR.ItemsSource = MainWindow.ListaKlientow;
            ComboBoxPracownikR.ItemsSource = MainWindow.ListaPracownikow;
            ComboBox_PokojR.ItemsSource = MainWindow.ListaPokoi;

        }

        private void Button_ZatwierdzR_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                DateTime zameldowanie;
                DateTime wymeldowanie;
                DateTime.TryParseExact(TextBox_Zameldowanie.Text, new[] { "yyyy-MM-dd", "yyyy/MM/dd",
                "MM/dd/yy", "dd-MMM-yy" }, null, DateTimeStyles.None, out zameldowanie);
                DateTime.TryParseExact(TextBox_Wymeldowanie.Text, new[] { "yyyy-MM-dd", "yyyy/MM/dd",
                "MM/dd/yy", "dd-MMM-yy" }, null, DateTimeStyles.None, out wymeldowanie);

                MainWindow.h1.CreateReservation(
                    TextBox_TytulR.Text,
                    Klient(),
                    zameldowanie.ToString(),
                    wymeldowanie.ToString(),
                    LiczbaDoroslych(),
                    LiczbaDzieci(),
                    LiczbaNiemowlat(),
                    Pracownik(),
                    Pokoj()
                    
                    )
               ;
                
                r.UpdateList();
                this.Close();
            }
             catch (MissingFieldException exc)
            {
                MessageBox.Show("Brak danych!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private int LiczbaDoroslych()
        {
            int y;
            string x;
            x= TextBox_LD1.Text;
            Int32.TryParse(x, out y);
            return y;

        }
        private int LiczbaDzieci()
        {
            int y;
            string x;
            x = TextBox_LDzieci.Text;
            Int32.TryParse(x, out y);
            return y;

        }
        private int LiczbaNiemowlat()
        {
            int y;
            string x;
            x = TextBox_LN.Text;
            Int32.TryParse(x, out y);
            return y;

        }
        private Client Klient()
        {
            Client x = new Client();
            var p = ComboBox_KlientR.SelectedItem;
            x = (Client)p;
            return (Client)p;

        }
        private Employee Pracownik()
        {
            Employee x = new Employee();
            var p = ComboBoxPracownikR.SelectedItem;
            x = (Employee)p;
            return (Employee)p;
        }
        private Room Pokoj()
        {
            Room r = new Room();
            var p = ComboBox_PokojR.SelectedItem;
            r = (Room)p;
            return (Room)p;
        }

    }
}
