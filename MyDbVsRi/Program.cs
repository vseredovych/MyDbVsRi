using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using MyDbVsRi.TablesRepository;

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
            string[] tableColumnsP = { "Id", "Name", "Price", "Status", "MerchantId", "CreatedAt" };

            Table merchant = new Table("Merchants", tableColumnsM);
            Table product = new Table("Products", tableColumnsP);
            Merchant newMerchant = new Merchant(1, "asd", "asd", Convert.ToDateTime("2019-10-10"), "asdasd");
            Product newProduct = new Product(1, "asd", 123, "as", 1, Convert.ToDateTime("2019-10-10"));

            MerchantsRepository repoMerchants = new MerchantsRepository();
            ProductsRepository repoProducts = new ProductsRepository();
   


            Database dataBase = new Database(fileHelper.getFilePath());
            if (!dataBase.IsTableExists(merchant))
            {
                dataBase.CreateTable(merchant);
            }
            if (!dataBase.IsTableExists(product))
            {
                dataBase.CreateTable(product);
            }

            repoMerchants.AddToRepository(newMerchant);
            repoProducts.AddToRepository(newProduct);
            dataBase.UpdateTable(merchant, repoMerchants);
            dataBase.UpdateTable(product, repoProducts);

            DbDataReader readerMerchants = dataBase.GetDbDataReader(merchant);
            repoMerchants.FillRepositoryByDataReader(readerMerchants);
            DbDataReader readerProducts = dataBase.GetDbDataReader(product);
            repoProducts.FillRepositoryByDataReader(readerProducts);

            Console.WriteLine("Merchants");
            repoMerchants.WriteMerchants();
            Console.WriteLine("Product");
            repoProducts.WriteProducts();
            //dataBase.DeleteTable(merchant);

            //dataBase.DeleteTable(product);
            //dataBase.DeleteTable(merchant);

            //Merchant merchant = new Merchant(1, "a", "b", Convert.ToDateTime("2019-10-10"), "Lviv");
            //Product product = new Product(1, "asd", 12, "asd", 1, Convert.ToDateTime("2019-10-10"));

            //dataBase.GetListOfObjectsInTable(fileHelper.getFilePath(), merchant, Merchant.TableName, Merchant.TableColumns);
            //dataBase.GetListOfObjectsInTable(fileHelper.getFilePath(), product, Product.TableName, Product.TableColumns);


            Console.Read();
        }
    }
}
