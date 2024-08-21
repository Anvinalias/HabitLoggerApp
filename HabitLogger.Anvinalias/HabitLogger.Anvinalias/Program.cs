namespace HabitLogger.Anvinalias;
    internal class Program
    {
        static void Main(string[] args)
        {
            string? userChoice;

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
