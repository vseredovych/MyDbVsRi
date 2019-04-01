using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace MyDbVsRi.TablesRepository
{

    class ProductsRepository
    {
        List<Product> products;

        public ProductsRepository()
        {
            products = new List<Product>();
        }
        public void AddTorepository(Product product)
        {
            products.Add(product);
        }

    }
}

