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
    /// Interaction logic for DodajRezerwacje.xaml
    /// </summary>
    public partial class DodajRezerwacje : Window
    {
        public DodajRezerwacje()
        {
            InitializeComponent();
            ComboBox_KlientR.ItemsSource = MainWindow.ListaKlientow;
            ComboBoxPracownikR.ItemsSource = MainWindow.ListaPracownikow;
            ComboBox_PokojR.ItemsSource = MainWindow.ListaPokoi;

        }

        
    }
}
