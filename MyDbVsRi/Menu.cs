using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace MyDbVsRi
{
    public class Menu
    {
        string[] tables = { "Merchants", "Products" };
        string[] mainMenuStrings = { "show Tables" };
        string[] operations = { "AddItem", "DeleteItem", "CloneItem", "Save" };

        FileHelper fileHelper;
        Database dataBase;
        TablesRepository tableRepository;
        public Menu()
        {
            fileHelper = new FileHelper();
            fileHelper.CreateFile("Tables", "TableFolder");
            dataBase = new Database(fileHelper.getFilePath());
            tableRepository = new TablesRepository();
          
            Table merchant = dataBase.GetTableFromDatabase("Merchants");
            Table product = dataBase.GetTableFromDatabase("Products");

            tableRepository.AddToRepository(merchant);
            tableRepository.AddToRepository(product);

            dataBase.CreateEmptyTable(merchant);
            dataBase.CreateEmptyTable(product);
            //merchant.FillWithDatabase(merchant, dataBase);

        }
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
                    case ConsoleKey.Enter:
                        TableOperationsMenu(tableRepository.Tables[chooseKey]);
                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.Escape:
                        break;
                }

            } while (action != ConsoleKey.Escape);
        }
        public void TableOperationsMenu(Table table)
        {
            ConsoleKey action;
            int chooseKey = 0;

            do
            {
                Console.Clear();
                PrintTable(table, ref chooseKey);
                PrintOperations();
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
                        AddItem(table);
                        break;
                    case ConsoleKey.D2:
                        RemoveItem(table, chooseKey);
                        break;
                    case ConsoleKey.D3:
                        break;
                    case ConsoleKey.D4:
                        SaveTable(table);
                        break;

                    case ConsoleKey.Escape:
                        break;
                }
            } while (action != ConsoleKey.Escape);
        }

        void printMainMenu(ref int chooseKey)
        {
            Console.WriteLine("Tables");
            HandleIndex(ref chooseKey, 0, tableRepository.GetLength() - 1);
            for (int i = 0; i < tableRepository.GetLength(); i++)
            {
                if (i == chooseKey)
                {
                    Console.Write("-->");
                }
                Console.WriteLine("\t" + tableRepository.Tables[i].TableName);
            }
            Console.WriteLine("Enter - choose table");
        }
        void PrintTable(Table table, ref int chooseKey)
        {
            Console.WriteLine(table.TableName);
            HandleIndex(ref chooseKey, 0, table.TableValuesCount - 1);

            for (int i = 0; i < table.TableValuesCount; i++)
            {
                if (i == chooseKey)
                {
                    Console.Write("-->");
                }
                for (int j = 0; j < table.GetColumnsLength(); j++)
                {
                    Console.Write("\t" + table.TableDictionary[ table.TableColumns[j] ][i]);
                    if (j != table.GetColumnsLength() - 1)
                    {
                        Console.Write("\t|");
                    }
                }
                Console.WriteLine();
            }
        }
        void AddItem(Table table)
        {
            string insertValue;
            List<string> insertList = new List<string>();
            for (int i = 0; i < table.GetColumnsLength(); i++)
            {
                Console.Write(table.TableColumns[i] + ":");
                insertValue = Console.ReadLine();
                insertList.Add(insertValue);
            }
            table.AddToRepository(insertList);
        }
        void RemoveItem(Table table, int chooseKey)
        {
            table.RemoveFromTable(chooseKey);
            Console.WriteLine("Item " + chooseKey + " was removed!");
        }
        void SaveTable(Table table)
        {
            dataBase.UpdateTable(table);
            Console.WriteLine("Table is saved!");
        }
        void HandleIndex(ref int chooseKey, int min, int max)
        {
            if (chooseKey < min)
            {
                chooseKey = min;
            }
            if (chooseKey >= max)
            {
                chooseKey = max;
            }
        }
        void PrintOperations()
        {
            for (int i = 0; i < operations.Length; i++)
            {
                Console.Write(i + 1);
                Console.WriteLine(" - " + operations[i] + "\t");
            }
        }
        //void ManuallyFillEntity()
        //{
        //    return Entyt
        //}

    }
}