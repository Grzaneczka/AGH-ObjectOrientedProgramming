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
    /// Logika interakcji dla klasy Pracownicy.xaml
    /// </summary>
    public partial class Pracownicy : Window
    {
        public Pracownicy()
        {
            InitializeComponent();
            UpdateList();            
        }

        public void UpdateList()
        {
            ListBox_Pracownicy.ItemsSource = null;
            ListBox_Pracownicy.ItemsSource = MainWindow.h1.Employees;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DodajPracownika okno = new DodajPracownika(this);
            okno.ShowDialog();
        }
    }
}
