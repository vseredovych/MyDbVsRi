using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace MyDbVsRi.TablesRepository
{
    class MerchantsRepository : Repository
    {
        List<Entity> Merchants;

        public MerchantsRepository()
        {
            Merchants = new List<Entity>();
        }
        public void AddToRepository(Entity entity)
        {
            Merchants.Add(entity);
        }
        public void FillRepositoryByDataReader(DbDataReader reader)
        {
            if (!(reader.Dictionary == null || reader.Dictionary.Count == 0) && !(reader.Dictionary["Id"][0] == ""))
                Merchants.Clear();
                for (int i = 0; i < reader.Dictionary["Id"].Count; i++)
                {
                    try
                    {
                        Merchant merchant = new Merchant();
                        merchant.Id = Convert.ToInt32(reader.Dictionary["Id"][i]);
                        merchant.FirstName = Convert.ToString(reader.Dictionary["FirstName"][i]);
                        merchant.LastName = Convert.ToString(reader.Dictionary["LastName"][i]);
                        merchant.Dob = Convert.ToDateTime(reader.Dictionary["Dob"][i]);
                        merchant.CurrentSity = Convert.ToString(reader.Dictionary["CurrentSity"][i]);
                        Merchants.Add(merchant);
                    }
                    catch
                    {

                    }    
                }
        }
        public string[] GetStringArray()
        {
            List<string> list = new List<string>();
            foreach (Merchant merchant in Merchants)
            {
                list.Add(merchant.ToString());
            }
            return list.ToArray();
        } 
        public void WriteEntities()
        {
            foreach (Merchant merchant in Merchants)
            {
                Console.WriteLine(merchant);
            }
        }

    }
}
