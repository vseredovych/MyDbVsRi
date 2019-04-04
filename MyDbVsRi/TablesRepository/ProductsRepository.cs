using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace MyDbVsRi.TablesRepository
{

    class ProductsRepository : Repository
    {
        List<Entity> Products;

        public ProductsRepository()
        {
            Products = new List<Entity>();
        }
        public void AddToRepository(Entity entity)
        {
            Products.Add(entity);
        }
        public void FillRepositoryByDataReader(Table table)
        {
            Products.Clear();
            for (int i = 0; i < table.TableDictionary["Id"].Count; i++)
            {
                Product product = new Product();
                product.Id = Convert.ToInt32(table.TableDictionary["Id"][i]);
                product.Name = Convert.ToString(table.TableDictionary["Name"][i]);
                product.Price = Convert.ToDouble(table.TableDictionary["Price"][i]);
                product.Status = Convert.ToString(table.TableDictionary["Status"][i]);
                product.MerchantId = Convert.ToInt32(table.TableDictionary["MerchantId"][i]);
                product.CreatedAt = Convert.ToDateTime(table.TableDictionary["CreatedAt"][i]);
                Products.Add(product);
            }

        }
        public string[] GetStringArray()
        {
            List<string> list = new List<string>();
            foreach (Product product in Products)
            {
                list.Add(product.ToString());
            }
            return list.ToArray();
        }
        public void WriteEntities()
        {
            foreach (Product merchant in Products)
            {
                Console.WriteLine(merchant);
            }
        }
    }
}

