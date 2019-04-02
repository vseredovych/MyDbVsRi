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
        List<Merchant> Merchants;

        public MerchantsRepository()
        {
            Merchants = new List<Merchant>(); 
        }
        public void AddTorepository(Merchant merchant)
        {
            Merchants.Add(merchant);
        }
        public void FillRepositoryByDataReader(DbDataReader reader)
        {
            for (int i = 0; i < reader.Dictionary["Id"].Count; i++)
            {
                Merchant merchant = new Merchant();
                merchant.Id = Convert.ToInt32(reader.Dictionary["Id"][i]);
                merchant.FirstName = Convert.ToString(reader.Dictionary["FirstName"][i]);
                merchant.LastName = Convert.ToString(reader.Dictionary["LastName"][i]);
                merchant.Dob = Convert.ToDateTime(reader.Dictionary["Dob"][i]);
                merchant.CurrentSity = Convert.ToString(reader.Dictionary["CurrentSity"][i]);
                Merchants.Add(merchant); 
            }
        }
        public void WriteMerchnts()
        {
            foreach(Merchant merchant in Merchants)
            {
                Console.WriteLine(merchant);
            }
        }

    }
}
