using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Operations;
using DAL.Entities;

namespace MyDbVsRi
{
    class Program
    {

        
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            FileHelper fileHelper = new FileHelper();
            fileHelper.CreateFile("Tables", "TableFolder");

            Operations operations = new Operations();
            if (!operations.IsTableExists(fileHelper.getFilePath(), Merchant.TableName))
            {
                operations.createTable(fileHelper.getFilePath(), Merchant.TableColumns, Merchant.TableName);
            }
            if (!operations.IsTableExists(fileHelper.getFilePath(), Product.TableName))
            {
                operations.createTable(fileHelper.getFilePath(), Product.TableColumns, Product.TableName);
            }

            Merchant merchant = new Merchant(1, "a", "b", Convert.ToDateTime("2019-10-10"), "Lviv");
            Product product = new Product(1, "asd", 12, "asd", 1, Convert.ToDateTime("2019-10-10"));
                
            operations.AddTableElement(fileHelper.getFilePath(), merchant, Merchant.TableName, Merchant.TableColumns);
            operations.AddTableElement(fileHelper.getFilePath(), product, Product.TableName, Product.TableColumns);

            Console.Read();
        }
    }
}
