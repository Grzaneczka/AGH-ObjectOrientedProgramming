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
                // zamykam polaczenie z baza danych
                connection.Close();
                return table;
            }
        }


        /*
         * FUNKCJE WPROWADZAJACE DANE DO BAZY
         */

        public static void InsertEmployee(Employee employee)
        {
            using(SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Open();
                using(SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Employees (Name, Surname, Phone, Sex, Function) VALUES (@p1, @p2, @p3, @p4, @p5)";

                    command.Parameters.Add(new SQLiteParameter("@p1", employee.Name));
                    command.Parameters.Add(new SQLiteParameter("@p2", employee.Surname));
                    command.Parameters.Add(new SQLiteParameter("@p3", employee.Phone));
                    command.Parameters.Add(new SQLiteParameter("@p4", employee.Sex.ToString()));
                    command.Parameters.Add(new SQLiteParameter("@p5", employee.Function));
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                }
                connection.Close();
            }
        }

        public static void InsertClient(Client client)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Open();
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Clients (Name, Surname, Phone, Sex, Email, IdNumber) VALUES (@p1,@p2,@p3,@p4,@p5,@p6)";

                    command.Parameters.Add(new SQLiteParameter("@p1", client.Name));
                    command.Parameters.Add(new SQLiteParameter("@p2", client.Surname));
                    command.Parameters.Add(new SQLiteParameter("@p3", client.Phone));
                    command.Parameters.Add(new SQLiteParameter("@p4", client.Sex.ToString()));
                    command.Parameters.Add(new SQLiteParameter("@p5", client.Email));
                    command.Parameters.Add(new SQLiteParameter("@p6", client.IDNumer));
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                }
                connection.Close();
            }
        }
        
        public static void InsertRoom(Room room)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Open();
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Clients (RoomNumber, SingleBeds, MarriageBeds, IsBalcony, IsClear, IsFree) VALUES (@p1,@p2,@p3,@p4,@p5,@p6)";

                    command.Parameters.Add(new SQLiteParameter("@p1", room.RoomNumber));
                    command.Parameters.Add(new SQLiteParameter("@p2", room.NumberOfSingleBeds));
                    command.Parameters.Add(new SQLiteParameter("@p3", room.NumberOfMarriageBeds));
                    command.Parameters.Add(new SQLiteParameter("@p4", room.IsBalcony));
                    command.Parameters.Add(new SQLiteParameter("@p5", room.IsClear));
                    command.Parameters.Add(new SQLiteParameter("@p6", room.IsFree));

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                }
                connection.Close();
            }
        }

        public static void InsertSinglePayment(SinglePayment singlePayment)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Open();
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO SinglePayment (Name, Price, Quantity) VALUES (@p1, @p2, @p3)";

                    command.Parameters.Add(new SQLiteParameter("@p1", singlePayment.Title));
                    command.Parameters.Add(new SQLiteParameter("@p2", singlePayment.Price));
                    command.Parameters.Add(new SQLiteParameter("@p3", singlePayment.Quantity));
                }
                connection.Close();
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
                bool tmp_free = TrueOrFalse(row[5]);

                Room tmp_room = new Room(tmp_number, tmp_single, tmp_mariage, tmp_balcony, tmp_clear, tmp_free);
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

                SinglePayment tmp_payment = new SinglePayment(tmp_name, tmp_price, tmp_quantity);
                Allpayments.Add(tmp_payment);
            }
            return Allpayments;
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
