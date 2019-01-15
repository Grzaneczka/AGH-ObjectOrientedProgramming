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

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy Rezerwacje.xaml
    /// </summary>
    public partial class Rezerwacje : Window
    {
        public Rezerwacje()
        {
            InitializeComponent();
            ListBox_Rezerwacje.ItemsSource = MainWindow.ListaRezerwacji;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_DodajRezerwacje_Click(object sender, RoutedEventArgs e)
        {
            DodajRezerwacje okno = new DodajRezerwacje();
            okno.ShowDialog();
        }
    }
}
