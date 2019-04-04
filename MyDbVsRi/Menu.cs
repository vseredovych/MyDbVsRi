using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDbVsRi
{
    public class Menu
    {
        string[] tables = { "Merchants", "Products" };

        string[] mainMenuStrings = { "show Tables" };
        string[] operations = { "Print", "AddItem", "DeleteItem" };
        public void MainMenu()
        {
            ConsoleKey action;
            int chooseKey = 1;

            do
            {
                Console.Clear();
                
                printMainMenu(ref chooseKey);
                action = Console.ReadKey(true).Key;

                switch (action)
                {
                    case ConsoleKey.UpArrow:
                        chooseKey -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        chooseKey += 1;
                        break;
                    case ConsoleKey.D1:
                        break;
                    case ConsoleKey.D2:

                        break;
                    case ConsoleKey.Escape:
                        break;
                }

            } while (action != ConsoleKey.Escape);
        }
        void printMainMenu(ref int chooseKey)
        {
            Console.WriteLine("Tables");
            if (chooseKey < 0)
            {
                chooseKey = 0;
            }
            if (chooseKey >= tables.Length)
            {
                chooseKey = tables.Length - 1;
            }
            for(int i = 0; i < tables.Length; i++)
            {
                if (i == chooseKey)
                {
                    Console.Write("->\t");
                }
                Console.WriteLine(tables[i]);
            }
            for(int i = 0; i < operations.Length; i++)
            {
                Console.Write(i);
                Console.WriteLine(" - " + operations[i] + "\t" );
            }
        }
    }
}
