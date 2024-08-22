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
                command.CommandText = "CREATE TABLE IF NOT EXISTS habitLog (Id INTEGER PRIMARY KEY AUTOINCREMENT, Date TEXT, Quantity INTEGER)"; ;
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
    }
}
