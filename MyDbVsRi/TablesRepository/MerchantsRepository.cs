using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace MyDbVsRi.TablesRepository
{
    class MerchantsRepository
    {
        List<Merchant> merchants;

        public MerchantsRepository()
        {
            merchants = new List<Merchant>(); 
        }
        public void AddTorepository(Merchant merchant)
        {
            merchants.Add(merchant);
        }

    }
}
