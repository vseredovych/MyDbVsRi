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
        void FillRepositoryByDataReader(DbDataReader reader);
        void WriteEntities();
    }
}
