using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace MyDbVsRi
{
    public class Database
    {
        string FilePath;
        public Database(string filePath)
        {
            FilePath = filePath;
        }
        public int GetTableIndex(Table table)
        {
            using (StreamReader streamReader = File.OpenText(FilePath))
            {
                int count = 0;
                string line = "";
                string[] lineWords = new string[2];

                while ((line = streamReader.ReadLine()) != null)
                {
                    count += 1;
                    if (line == "/START")
                    {
                        line = streamReader.ReadLine();
                        lineWords = line.Split(':');
                        count += 1;
                        if (line != null && line == table.TableName)
                        {
                            return count;
                        }
                    }
                }
                return -1;
            }
        }
        public int GetTableLength(Table table)
        {
            //var test = File.ReadAllLines(FilePath).Skip(GetTableIndex(FilePath, tableName)).Take(1);//.Split(':')[1];
            return table.GetColumnsLength();
        }
        public void CreateTable(Table table)
        {
            using (StreamWriter streamWriter = File.AppendText(FilePath))
            {
                streamWriter.WriteLine("/START");
                streamWriter.WriteLine(table.TableName);
                //Table length
                //streamWriter.WriteLine(";" + 0 + ";");

                for (int i = 0; i < table.TableColumns.Count; i++)
                {
                    streamWriter.WriteLine(table.TableColumns[i] + ":");
                }
                streamWriter.WriteLine("END/");
            }
        }
        public bool IsTableExists(Table table)
        {
            if (GetTableIndex(table) != -1)
            {
                return true;
            }
            return false;
        }
        public void AddTableElement(Table table)
        {
            using (StreamReader streamReader = File.OpenText(FilePath))
            {
                string line = "";
                List<string> lines = new List<string>();
                //string[] tableLines = new string[2];
                ////Object[] objects = entity.GetOblectArray();

                //if (IsTableExists(FilePath, tableName))
                //{
                //    Console.WriteLine(GetTableIndex(FilePath, tableName));
                //    lines = File.ReadLines(FilePath).Skip(GetTableIndex(FilePath, tableName) - 1).Take(objects.Length + 1).ToList();
                //}


            }
        }
        public DbDataReader GetDbDataReader(Table table)
        {
            using (StreamReader streamReader = File.OpenText(FilePath))
            {
                List<string> allTable = new List<string>();
                //string[] tableLines = new string[2];
                
                if (IsTableExists(table))
                {
                    Console.WriteLine(GetTableIndex(table));
                    allTable = File.ReadLines(FilePath).Skip(GetTableIndex(table)).Take(table.GetColumnsLength()).ToList();
                }
                return GetDbDataReader(allTable);
                //foreach (object ob in entity.GetTableColumns())
                //{
                //    string[] data = GetValuesFromListByKey(allTableValues.ToArray(), ob.ToString());
                //    //foreach(string el in date)
                //    //{
                        
                //    //}
                //}

                //foreach (string el in entity.GetTableColumns())
                //{

                //}
            }
        }
        private DbDataReader GetDbDataReader(List<string> allTable)
        {
            DbDataReader reader = new DbDataReader();
            string tableName;
            string[] tableColumns;
            string[] tempArray;
            foreach (string line in allTable)
            {
                tempArray = line.Split(':');
                tableName = tempArray[0];
                tableColumns = tempArray[1].Split(',');
                reader.Dictionary[tableName] = tableColumns.ToList(); 
            }

            return reader;
        }
        private string[] GetValuesFromListByKey(string[] list, string key)
        {
            foreach (string el in list)
            {
                if (el.Split(':')[0] == key)
                {
                    return el.Split(':')[1].Split(',');
                }
            }
            return null;
        }
    }
}