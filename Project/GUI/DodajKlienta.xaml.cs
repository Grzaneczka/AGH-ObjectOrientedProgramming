using System;
using System.Collections.Generic;
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
using Project;

namespace GUI
{
    /// <summary>
    /// Interaction logic for DodajKlienta.xaml
    /// </summary>
    public partial class DodajKlienta : Window
    {
        Client k = new Client();

        public DodajKlienta()
        {
            InitializeComponent();
        }

        private void Button_ZatwierdzK_Click(object sender, RoutedEventArgs e)
        {
           
            k.Name= TextBox_ImieK.Text;
            k.Surname = TextBox_NazwK.Text;
            if (ComboBox_PlecK.Text == "kobieta")
                k.Sex = Sex.Woman;
            else
                k.Sex = Sex.Man;
            k.Phone = TextBox_TelK.Text;

            MainWindow.h1.CreateAccount(k);
            MainWindow.ListaKlientow.Add(k);

            this.Close();
        }
    }
}
