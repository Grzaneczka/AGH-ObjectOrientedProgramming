using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace Project
{
    class Sql
    {
        // metoda pobierająca "adres" odpowiedniej bazy danych
        public static string LoadConnectionString(string id = "Default")
        {
            // pobieram connection string o nazwie "Default" z app.config
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }


        // metoda ktora pozwoli na wykonanie w bazie danych dowolnej komendy i zwroci rezultat w formie listy list stringow
        // innymi slowy zwraca liste wierszy z tabeli (kazdy wiersz jest lista stringow)
        public static List<List<string>> ExecuteSelectQuerry(string querry)
        {
            List<List<string>> table = new List<List<string>>();

            // tworzę nowe połączenie z bazą danych
            // używam metody "using" aby w razie błędnego polecenia nie pozostawić po crashu otwartego połączenia
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                // otwieram polaczenie z baza danych
                // pozniej automatycznie zostanie zamkniete
                connection.Open();
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    // ustawiam parametry komendy ktora zostanie wykonana w bazie danych
                    command.CommandText = @querry;
                    command.CommandType = CommandType.Text;

                    // tworzę obiekt który przechowa odpowiedz bazy danych na wprowadzoną komendę
                    SQLiteDataReader reader = command.ExecuteReader();

                    // tak długo jak w tabeli jest wiersz który mozna odczytac pozostan w petli
                    while (reader.Read())
                    {
                        List<string> row = new List<string>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row.Add(reader.GetValue(i).ToString());
                        }
                        table.Add(row);
                    }
                }
                return table;
            }
        }

        /*
         * FUNKCJE KONWERTUJĄCE
         */

        public static List<Employee> ConvertToEmployee(List<List<string>> table)
        {
            List<Employee> AllEmployees = new List<Employee>();

            foreach (List<string> row in table)
            {
                string tmp_name = row[1];
                string tmp_surname = row[2];
                string tmp_phone = row[3];
                Sex tmp_sex;
                switch (row[4])
                {
                    case "Man":
                        tmp_sex = Sex.Man;
                        break;
                    case "Woman":
                        tmp_sex = Sex.Woman;
                        break;
                    default:
                        tmp_sex = Sex.Unknown;
                        break;
                }
                string tmp_function = row[5];

                Employee tmp_empoloyee = new Employee(tmp_name, tmp_surname, tmp_phone, tmp_sex, tmp_function);
                AllEmployees.Add(tmp_empoloyee);
            }
            return AllEmployees;
        }

        public static List<Client> ConvertToClient(List<List<string>> table)
        {
            List<Client> AllClients = new List<Client>();

            foreach (List<string> row in table)
            {
                string tmp_name = row[1];
                string tmp_surname = row[2];
                string tmp_phone = row[3];
                Sex tmp_sex;
                switch (row[4])
                {
                    case "Man":
                        tmp_sex = Sex.Man;
                        break;
                    case "Woman":
                        tmp_sex = Sex.Woman;
                        break;
                    case "Company":
                        tmp_sex = Sex.Company;
                        break;
                    default:
                        tmp_sex = Sex.Unknown;
                        break;
                }
                string tmp_email = row[5];
                string tmp_idnumber = row[6];

                Client tmp_client = new Client(tmp_name, tmp_surname, tmp_phone, tmp_sex, tmp_email, tmp_idnumber);
                AllClients.Add(tmp_client);
            }
            return AllClients;
        }

        public static List<Room> ConvertToRoom(List<List<string>> table)
        {
            List<Room> AllRooms = new List<Room>();

            foreach (List<string> row in table)
            {
                int tmp_number = Int32.Parse(row[0]);
                int tmp_single = Int32.Parse(row[1]);
                int tmp_mariage = Int32.Parse(row[2]);
                bool tmp_balcony = TrueOrFalse(row[3]);
                bool tmp_clear = TrueOrFalse(row[4]);

                Room tmp_room = new Room(tmp_number, tmp_single, tmp_mariage, tmp_balcony, tmp_clear);
                AllRooms.Add(tmp_room);
            }
            return AllRooms;
        }

        public static List<SinglePayment> ConvertToSinglePayment(List<List<string>> table)
        {
            List<SinglePayment> Allpayments = new List<SinglePayment>();

            foreach (List<string> row in table)
            {
                string tmp_name = row[1];
                double tmp_price = Double.Parse(row[2]);
                double tmp_quantity = Double.Parse(row[3]);
                bool tmp_paid = TrueOrFalse(row[4]);
                DateTime tmp_date = DateTime.Parse(row[5]);

                SinglePayment tmp_payment = new SinglePayment(tmp_name, tmp_price, tmp_quantity, tmp_paid);
                Allpayments.Add(tmp_payment);
            }
            return Allpayments;
        }

        // ta funkcja działa
        public static List<Employee> LoadAllEmployees()
        {
            List<Employee> output = new List<Employee>();

            // tworzę nowe połączenie z bazą danych
            // używam metody "using" aby w razie błędnego polecenia nie pozostawić po crashu otwartego połączenia
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT * FROM Employees";
                    command.CommandType = CommandType.Text;

                    SQLiteDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        string tmp_name = reader.GetString(1);
                        string tmp_surname = reader.GetString(2);
                        string tmp_phone = reader.GetString(3);

                        Sex tmp_sex;
                        switch (reader.GetString(4))
                        {
                            case "Man":
                                tmp_sex = Sex.Man;
                                break;
                            case "Woman":
                                tmp_sex = Sex.Woman;
                                break;
                            case "Company":
                                tmp_sex = Sex.Company;
                                break;
                            default:
                                tmp_sex = Sex.Unknown;
                                break;
                        }

                        string tmp_function = reader.GetString(5);


                        Employee tmp_empoloyee = new Employee(tmp_name, tmp_surname, tmp_phone, tmp_sex, tmp_function);

                        output.Add(tmp_empoloyee);
                    }
                }

                return output;
            }
        }

        static bool TrueOrFalse(string str)
        {
            if (str == "True"   ||
                str == "true"   ||
                str == "T"      ||
                str == "t"      ||
                str == "Y"      ||
                str == "y"      ||
                str == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
