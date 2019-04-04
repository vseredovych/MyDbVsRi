using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace MyDbVsRi.TablesRepository
{
    public interface Repository
    {
        string[] GetStringArray();
        void AddToRepository(Entity entity);
        void FillRepositoryByDataReader(Table table);
        void WriteEntities();
    }
}
