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
        public void FillRepositoryByDataReader(Table table)
        {
            //if (!(table.TableDictionary == null || table.TableDictionary.Count == 0) && !(table.TableDictionary["Id"][0] == ""))
            Merchants.Clear();
            for (int i = 0; i < table.TableValuesCount; i++)
            {
                Merchant merchant = new Merchant();
                merchant.Id = Convert.ToInt32(table.TableDictionary["Id"][i]);
                merchant.FirstName = Convert.ToString(table.TableDictionary["FirstName"][i]);
                merchant.LastName = Convert.ToString(table.TableDictionary["LastName"][i]);
                merchant.Dob = Convert.ToDateTime(table.TableDictionary["Dob"][i]);
                merchant.CurrentSity = Convert.ToString(table.TableDictionary["CurrentSity"][i]);
                Merchants.Add(merchant);
                //}
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
