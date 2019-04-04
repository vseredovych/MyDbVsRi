using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace MyDbVsRi
{
    public class Table
    {
        public string TableName { get; set; }                   // = "Merchants";
        public List<string> TableColumns { get; set; }          //=  new List<string>{ "Id", "FirstName", "LastName", "Dob", "CurrentSity" };
        public Dictionary<string, List<string>> TableDictionary { get; set; }
        public int TableValuesCount;

        public Table()
        {
            TableColumns = new List<string>(); 
        }
        public Table(string tableName, string[] tableColumns)
        {
            TableDictionary = new Dictionary<string, List<string>>();
            this.TableName = tableName;
            this.TableColumns = new List<string>(tableColumns);
            foreach (string str in tableColumns)
            {
                TableDictionary[str] = new List<string>();
            }
        }
        public void AddTableValue(Entity entity)
        {
            string[] values = entity.ToString().Split(',');
            for (int i = 0; i < values.Length;i++)
            {
                TableDictionary[TableColumns[i]].Add(values[i]);
            }
            TableValuesCount += 1;
        }
        public void WriteTable()
        {
            Console.WriteLine(TableName + ":");
            for (int i = 0; i < TableDictionary.Count; i++)
            {
                for (int j = 0; j < TableValuesCount; j++)
                {
                    Console.Write(TableDictionary[TableColumns[i]][j] + ",");
                }
            }
        }
        public void FillWithDatabase(Table table, Database dataBase)
        {
            table = dataBase.GetTableFromDatabase(table.TableName);
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
