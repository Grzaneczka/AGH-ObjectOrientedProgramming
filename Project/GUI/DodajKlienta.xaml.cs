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
        private KliencieOkno parentWindow;

        public DodajKlienta(KliencieOkno parentWindow)
        {
            InitializeComponent();
            this.parentWindow = parentWindow;
        }


        private void Button_ZatwierdzK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.h1.CreateClient(
                    TextBox_ImieK.Text,
                    TextBox_NazwK.Text,
                    TextBox_TelK.Text,
                    GetSex(),
                    TextBox_EmailK.Text,
                    TextBox_NrDow.Text,
                    null // nie obslugujemy logowania do aplikacji wiec mozna pracownika rownie dobrze ustawic na null
                );
                parentWindow.UpdateList();
                this.Close();
            }
            catch (WrongPhoneException exc)
            {
                // TODO: display error in GUI
            }
            catch (WrongEmailException exc)
            {
                // TODO: display error in GUI
            }
            catch (WrongIDNumberException exc)
            {
                // TODO: display error in GUI
            }
            catch (MissingFieldException exc)
            {
                // TODO: display error in GUI
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
