using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDbVsRi
{
    class TablesRepository
    {
        public List<Table> Tables { get; set; }

        public TablesRepository()
        {
            Tables = new List<Table>();
        }
        public void AddToRepository(Table table)
        {
            Tables.Add(table);
        }
        public void RemoveFromRepository(int index)
        {
            Tables.RemoveAt(index);
        }
        public int GetLength()
        {
            return Tables.Count;
        }
    }
}
