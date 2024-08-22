using System.Data.SQLite;

namespace HabitLogger.Anvinalias;

internal class Program
{
    static void Main(string[] args)
    {
        string? userChoice;

        SQLiteConnection connection;
        SQLiteCommand command;
        SQLiteDataReader reader;

        string connectionString = @$"Data Source= HabitTracker.db";

        try
        {
            using (connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = @"CREATE TABLE IF NOT EXISTS habitLog
                        (Id INTEGER PRIMARY KEY AUTOINCREMENT, Date TEXT, Quantity INTEGER)"; ;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        do
        {
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("\n\nWhat would you like to do?");
            Console.WriteLine("\nType '0' to Close Application.");
            Console.WriteLine("Type '1' to View All Record.");
            Console.WriteLine("Type '2' to Insert Record.");
            Console.WriteLine("Type '3' to Update Record.");
            Console.WriteLine("Type '4' to Delete Record.");

            Console.WriteLine("\nEnter your choice: ");
            userChoice = Console.ReadLine();

        } while (userChoice != "0");

        switch (userChoice)
        {
            case "1":
                DisplayAllRecord();
                break;
            case "2":
                InsertRecord();
                break;
                //case "3":
                //    UpdateRecord();
                //    break;
                //case "4":
                //    DeleteRecord();
                //    break;
                //default:
                //    Console.WriteLine("Invalid Choice");
                //    break;
        }

         void DisplayAllRecord()
        {
            using (connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM habitLog";
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader.GetString(0)} date: {reader.GetString(1)} Quantity: {reader.GetString(2)}");
                    }
                }
                else
                {
                    Console.WriteLine("No record found");
                }
                connection.Close();
            }
        }

        void InsertRecord()
        {
            string logDate = GetLogDate();
            int logQuantity = GetLogQuantity();

            string insertQuery =
                $"INSERT INTO habitLog (Date, Quantity) VALUES ('{logDate}',{logQuantity})";

            connection.Open();
            command = new SQLiteCommand(insertQuery, connection);
            command.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine("Data Inserted");
        }

        string GetLogDate()
        {
            string date;

            Console.WriteLine("Enter the date (dd-mm-yy) of habit");
            date = Console.ReadLine();

            return date;
        }

        int GetLogQuantity()
        {
            int quantity;

            Console.WriteLine("Enter the quantity of water to be logged");
            quantity = Convert.ToInt32(Console.ReadLine());

            return quantity;
        }

    }
}
