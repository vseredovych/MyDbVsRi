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
        public string TableName { get; set; }
        public List<string> TableColumns { get; set; }
        public Dictionary<string, List<string>> TableDictionary { get; set; }
        public int TableValuesCount;

        public Table()
        {
            TableColumns = new List<string>();
            TableDictionary = new Dictionary<string, List<string>>();

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
        //public int AddToRepository(Entity entity)
        //{
        //    string[] values = entity.ToString().Split(',');

        //    if (TableDictionary.Count == 0)
        //    {
        //        for (int i = 0; i < values.Length; i++)
        //        {
        //            TableDictionary[TableColumns[i]] = new List<string>();
        //        }
        //        TableValuesCount += 1;
        //        return 1;
        //    }
        //    else
        //    {
        //        values = entity.ToString().Split(',');
        //        for (int i = 0; i < values.Length; i++)
        //        {
        //            TableDictionary[TableColumns[i]].Add(values[i]);
        //        }
        //        TableValuesCount += 1;
        //        return 1;
        //    }
        //}
        public int AddToRepository(List<string> insertList)
        {
            if (insertList.Count < this.TableColumns.Count)
            {
                return -1;
            }

            for (int i = 0; i < insertList.Count; i++)
            {
                this.TableDictionary[TableColumns[i]].Add(insertList[i]);
            }
            TableValuesCount += 1;
            return 1;
        } 
        public void RemoveFromTable(int index)
        {
            for (int i = 0; i < TableColumns.Count; i++)
            {
                TableDictionary[TableColumns[i]].RemoveAt(index);
            }
            TableValuesCount -= 1;
        }
        public void WriteTable()
        {
            Console.WriteLine(TableName + ":");
            for (int i = 0; i < TableDictionary.Count; i++)
            {
                for (int j = 0; j < TableValuesCount; j++)
                {
                    Console.Write(TableDictionary[TableColumns[i]][j]);
                    if (j != TableValuesCount - 1)
                    {
                        Console.Write("\t|\t");
                    }
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
