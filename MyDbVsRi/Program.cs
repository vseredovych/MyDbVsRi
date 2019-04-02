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

            string[] tableColumnsM = { "Id", "FirstName", "LastName", "Dob", "CurrentSity" };
            string[] tableColumnsP = { "Products", "Id", "Name", "Price", "Status", "MerchantId", "CreatedAt" };

            Table merchants = new Table("Merchants", tableColumnsM);
            Table product = new Table("Products", tableColumnsP);


            Database dataBase = new Database(fileHelper.getFilePath());
            if (!dataBase.IsTableExists(merchants))
            {
                dataBase.CreateTable(merchants);
            }
            if (!dataBase.IsTableExists(product))
            {
                dataBase.CreateTable(product);
            }

            //Merchant merchant = new Merchant(1, "a", "b", Convert.ToDateTime("2019-10-10"), "Lviv");
            //Product product = new Product(1, "asd", 12, "asd", 1, Convert.ToDateTime("2019-10-10"));

            //dataBase.GetListOfObjectsInTable(fileHelper.getFilePath(), merchant, Merchant.TableName, Merchant.TableColumns);
            //dataBase.GetListOfObjectsInTable(fileHelper.getFilePath(), product, Product.TableName, Product.TableColumns);

            Console.Read();
        }
    }
}
