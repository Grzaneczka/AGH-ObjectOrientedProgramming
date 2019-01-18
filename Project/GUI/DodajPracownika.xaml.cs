using Project;
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
    /// Interaction logic for DodajPracownika.xaml
    /// </summary>
    public partial class DodajPracownika : Window
    {
        private Pracownicy parentWindow;


        public DodajPracownika(Pracownicy parentWindow)
        {
            InitializeComponent();
            this.parentWindow = parentWindow;
        }


        private void Button_ZatwierdzP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.h1.CreateEmplyee(
                   TextBox_ImieP.Text,
                   TextBox_NazwiskoP.Text,
                   TextBox_TelP.Text,
                   GetSex(),
                   TextBox_Funkcja.Text
               );
                parentWindow.UpdateList();


                this.Close();
            }
            catch (WrongPhoneException exc)
            {
                MessageBox.Show("Bledny numer telefonu!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (MissingFieldException exc)
            {
                MessageBox.Show("Brak danych!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }

        private Sex GetSex()
        {
            switch (ComboBox_PlecK.SelectedIndex)
            {
                case 1:
                    return Sex.Man;
                case 0:
                    return Sex.Woman;
                default:
                    throw new MissingFieldException();
            }
        }

        
    }
}
