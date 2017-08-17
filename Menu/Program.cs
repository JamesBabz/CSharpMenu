using System;
using System.Net.Security;
using static System.Console;

namespace Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] menuItems =
            {
                "Show Videos",
                "Add Video",
                "Delete Video",
                "Edit Video",
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        WriteLine("Show Videos");
                        break;
                    case 2:
                        WriteLine("Add Video");
                        break;
                    case 3:
                        WriteLine("Delete Video");
                        break;
                    case 4:
                        WriteLine("Edit Videos");
                        break;
                    default:
                        WriteLine("Mojn");
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            ReadLine();
        }

        private static int ShowMenu(string[] menuItems)
        {
            Clear();
            WriteLine("Select what to do:\n");
            for (int i = 0; i < menuItems.Length; i++)
            {
                WriteLine($"{i + 1}. {menuItems[i]}");
            }
            int selection;
            while (!int.TryParse(ReadLine(), out selection)
                   || selection < 1 || selection > menuItems.Length)
            {
                WriteLine("That is not a valid input");
            }
            return selection;
        }
    }
}