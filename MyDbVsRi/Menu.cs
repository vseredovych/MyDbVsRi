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
        string[] operations = { "Print", "AddItem", "DeleteItem" };

        FileHelper fileHelper;
        Database dataBase;
        TablesRepository tableRepository;
        public Menu()
        {
            fileHelper = new FileHelper();
            fileHelper.CreateFile("Tables", "TableFolder");
            dataBase = new Database(fileHelper.getFilePath());
            tableRepository = new TablesRepository();
            string[] tableColumnsM = { "Id", "FirstName", "LastName", "Dob", "CurrentSity" };
            string[] tableColumnsP = { "Id", "Name", "Price", "Status", "MerchantId", "CreatedAt" };

            Table merchant = dataBase.GetTableFromDatabase("Merchants"); ;// new Table("Merchants", tableColumnsM);
            Table product = dataBase.GetTableFromDatabase("Products");

            tableRepository.AddToRepository(merchant);
            tableRepository.AddToRepository(product);

            dataBase.CreateEmptyTable(merchant);
            dataBase.CreateEmptyTable(product);
            //merchant.FillWithDatabase(merchant, dataBase);

        }
        public void MainMenu()
        {
            Merchant newMerchant = new Merchant(1, "asd", "asd", Convert.ToDateTime("2019-10-10"), "asdasd");
            Product newProduct = new Product(1, "asd", 123, "as", 1, Convert.ToDateTime("2019-10-10"));

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

                PrintTable(table, chooseKey);

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
                    case ConsoleKey.D3:
                        break;
                    case ConsoleKey.Escape:
                        break;
                }

            } while (action != ConsoleKey.Escape);
        }

        void printMainMenu(ref int chooseKey)
        {
            Console.WriteLine("Tables");
            HandleIndex(ref chooseKey, 0, tableRepository.GetLength());
            for (int i = 0; i < tableRepository.GetLength(); i++)
            {
                if (i == chooseKey)
                {
                    Console.Write("\t-->");
                }
                Console.WriteLine(tableRepository.Tables[i].TableName);
            }
            Console.WriteLine("Enter - choose table");
        }
        void PrintTable(Table table, int chooseKey)
        {
            Console.WriteLine(table.TableName + ":");
            HandleIndex(ref chooseKey, 0, table.TableColumns.Count);

            for (int i = 0; i < table.TableValuesCount; i++)
            {


                if (i == chooseKey)
                {
                    Console.Write("->\t");
                }
                for (int j = 0; j < table.GetColumnsLength(); j++)
                {
                    
                    Console.Write(table.TableDictionary[ table.TableColumns[j] ][i]);
                    if (j != table.TableValuesCount - 1)
                    {
                        Console.Write("\t|\t");
                    }
                }
                Console.WriteLine();
            }
        }
        void HandleIndex(ref int chooseKey, int min, int max)
        {
            if (chooseKey < min)
            {
                chooseKey = min;
            }
            if (chooseKey >= max)
            {
                chooseKey = max - 1;
            }
        }
        void PrintOperations()
        {
            for (int i = 0; i < tableRepository.GetLength(); i++)
            {
                Console.Write(i);
                Console.WriteLine(" - " + operations[i] + "\t");
            }
        }
    }
}
