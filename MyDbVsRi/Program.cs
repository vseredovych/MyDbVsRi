using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace MyDbVsRi
{
    class Program
    {


        static void Main(string[] args)
        {

            Menu menu = new Menu();
            menu.MainMenu();
            Console.WriteLine("Hello World!");

            //MerchantsRepository repoMerchants = new MerchantsRepository();
            //ProductsRepository repoProducts = new ProductsRepository();

            

            //DatabaseRepository repo = new DatabaseRepository(fileHelper);
            //repo.AddTable("Merchants", tableColumnsM, repoMerchants);
            //repo.AddTable("Products", tableColumnsP, repoProducts);
            //repo.Repositories["Products"].AddToRepository(newProduct);
            //repo.Repositories["Products"].WriteEntities();
            ////repo.
            //
            //Database dataBase = new Database(fileHelper.getFilePath());


            //repoMerchants.AddToRepository(newMerchant);
            //repoProducts.AddToRepository(newProduct);
            //dataBase.UpdateTable(merchant, repoMerchants);
            //dataBase.UpdateTable(product, repoProducts);

            //DbDataReader readerMerchants = dataBase.GetDbDataReader(merchant);
            //repoMerchants.FillRepositoryByDataReader(readerMerchants);
            //DbDataReader readerProducts = dataBase.GetDbDataReader(product);
            //repoProducts.FillRepositoryByDataReader(readerProducts);

            //Console.WriteLine("Merchants");
            //repoMerchants.WriteEntities();
            //Console.WriteLine("Product");
            //repoProducts.WriteEntities();
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
