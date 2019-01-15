using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for KliencieOkno.xaml
    ///</summary>
    public partial class KliencieOkno : Window
    {
        
        
        public KliencieOkno()
        {
            InitializeComponent();
            UpdateList();
            
        }

        public void UpdateList()
        {
            ListBox_ListaKlientow.ItemsSource = null;
            ListBox_ListaKlientow.ItemsSource = MainWindow.h1.Clients;
        }

        private void Button_DodajK_Click(object sender, RoutedEventArgs e)
        {
            DodajKlienta child = new DodajKlienta(this);
            child.ShowDialog();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
