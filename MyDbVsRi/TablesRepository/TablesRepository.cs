using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDbVsRi.TablesRepository
{
    class TablesRepository
    {
        List<Table> Tables;

        public TablesRepository()
        {
            Tables = new List<Table>();
        }
        public void AddToRepository(Table table)
        {
            Tables.Add(table);
        }
    }
}
