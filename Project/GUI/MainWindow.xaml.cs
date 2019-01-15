﻿using Project;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Hotel h1 = (Hotel)Hotel.ReadXML("C:/Users/kgrza/Desktop/Studia_Semestr_III/Programowanie_obiektowe/AGH-ObjectOrientedProgramming/Project/bin/Debug/hotel.xml");
        public static List<Client> ListaKlientow = h1.Clients;
        public static List<Employee> ListaPracownikow = h1.Employees;
        public static List<Reservation> ListaRezerwacji = h1.Reservations;
        public static List<Room> ListaPokoi = h1.Rooms;
        

        public MainWindow()
        {
            InitializeComponent();
        }

      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new KliencieOkno().ShowDialog(); ;
        }

        private void OpenEmployee(object sender, RoutedEventArgs e)
        {
            Pracownicy okno = new Pracownicy();
            okno.ShowDialog();
        }

        private void OpenReservations(object sender, RoutedEventArgs e)
        {
           Rezerwacje okno = new Rezerwacje();
            okno.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
