using BattleshipLibrary;
using BattleshipLibrary.Models;

namespace BattleshipUI;

public class Program
{
    static void Main()
    {
        WelcomeMessage();


    }

    private static void WelcomeMessage()
    {
        Console.WriteLine("Welcome to Battleship!");
        Console.WriteLine("Brought to you by Ivan Riumkin!");
    }

    private static PlayerInfoModel CreatePlayer()
    {
        PlayerInfoModel output = new PlayerInfoModel();

        // Ask user for their name
        output.UsersName = AskForName();

        // Load up shot grid
        GameLogic.InitializeGrid(output);

        // Ask for ship placements
        PlaceShips(output);
        // Clear
        Console.Clear();

        return output;

    }

    private static string AskForName()
    {
        Console.WriteLine("Enter your name");
        string output = Console.ReadLine();
        return output;
    }

    private static void PlaceShips(PlayerInfoModel model)
    {
        do
        {
            Console.WriteLine($"Where do you want to place ship {model.ShipLocations.Count + 1}/5");

            string location = Console.ReadLine();
            bool isValidLocation = GameLogic.PlaceShip(model, location);

            if (isValidLocation == false)
            {
                Console.WriteLine("Not a valid location!");
            }

        } while (model.ShipLocations.Count < 5);
    }

}
