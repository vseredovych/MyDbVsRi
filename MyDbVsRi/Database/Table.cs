using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDbVsRi
{
    public class Table
    {
        public string TableName { get; set; }                   // = "Merchants";
        public List<string> TableColumns { get; set; }          //=  new List<string>{ "Id", "FirstName", "LastName", "Dob", "CurrentSity" };

        public Table()
        {
            TableColumns = new List<string>(); 
        }
        public Table(string tableName, string[] tableColumns)
        {
            this.TableName = tableName;
            this.TableColumns = new List<string>(tableColumns);
        }
        public int GetColumnsLength()
        {
            return TableColumns.Count;
        }
        public string[] GetTableColumns()
        {
            return TableColumns.ToArray();
        }
    }
}
