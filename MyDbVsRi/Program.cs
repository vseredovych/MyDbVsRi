using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Operations;

namespace MyDbVsRi
{
    class Program
    {

        public static readonly string[] TableNamesMerchants = { "Merchants", "Id", "FirstName", "LastName", "Dob", "CurrentSity" };
        public static readonly string[] TableNamesProducts = { "Products", "Id", "Name", "Price", "Status", "MerchantId", "CreatedAt" };

        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            FileHelper fileHelper = new FileHelper();
            fileHelper.CreateFile("Tables", "TableFolder");

            Operations operations = new Operations();
            operations.createTable(fileHelper.getFilePath(), TableNamesMerchants);
            operations.createTable(fileHelper.getFilePath(), TableNamesProducts);

            Console.Read();
        }
    }
}
