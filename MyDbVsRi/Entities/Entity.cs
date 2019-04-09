using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public interface Entity
    {
        Object[] GetObjectArray();
        //void ManuallyFillEntity();
        //string GetTableName();
        //string[] GetTableColumns();
        //int GetLength();
       string ToString();
    }
}
