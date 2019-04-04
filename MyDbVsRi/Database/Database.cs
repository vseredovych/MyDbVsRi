using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using MyDbVsRi.TablesRepository;

namespace MyDbVsRi
{
    public class Database
    {
        string FilePath;
        public Database(string filePath)
        {
            FilePath = filePath;
        }
        public int GetTableIndex(string tableName)
        {
            using (StreamReader streamReader = File.OpenText(FilePath))
            {
                int count = 0;
                string line = "";
                string[] lineWords = new string[2];

                while ((line = streamReader.ReadLine()) != null)
                {
                    count += 1;
                    if (line == "/START@" +tableName)
                    {
                        count += 1;
                        return count;
                    }
                }
                return -1;
            }
        }
        public int GetTableLength(Table table)
        {
            //var test = File.ReadAllLines(FilePath).Skip(GetTableIndex(FilePath, tableName)).Take(1);//.Split('@')[1];
            return table.GetColumnsLength();
        }
        public void CreateEmptyTable(Table table)
        {
            using (StreamWriter streamWriter = File.AppendText(FilePath))
            {
                streamWriter.WriteLine("/START@" + table.TableName);

                for (int i = 0; i < table.TableColumns.Count; i++)
                {
                    streamWriter.WriteLine(table.TableColumns[i] + "@");
                }
                streamWriter.WriteLine("END@" + table.TableName + "/");
            }
        }
        public void UpdateTable(Table table)
        {
            List<string> datatable = GetDbList(table);
            //List<string> newItems = repository.GetStringArray().ToList();

            DeleteTable(table);

            using (StreamWriter streamWriter = File.AppendText(FilePath))
            {
                streamWriter.WriteLine("/START@" + table.TableName);

                for (int i = 0; i < table.TableColumns.Count; i++)
                {
                    streamWriter.Write(table.TableColumns[i] + "@");
                    for (int j = 0; j < table.TableValuesCount; j++)
                    {
                        streamWriter.Write(table.TableDictionary[table.TableColumns[j]][i]);
                    }
                    streamWriter.WriteLine();
                }
                streamWriter.WriteLine("END@" + table.TableName + "/");
            }
        }

        private void CreateTable(List<string> database)
        {
            using (StreamWriter streamWriter = new StreamWriter(FilePath))
            {
                foreach (string line in database)
                {
                    streamWriter.WriteLine(line);
                }
            }
        }
        public bool IsTableExists(Table table)
        {
            if (GetTableIndex(table.TableName) != -1)
            {
                return true;
            }
            return false;
        }
        public void DeleteTable(Table table)
        {
            List<string> beforeDatabase = new List<string>();
            List<string> afterDatabase = new List<string>();

            if (IsTableExists(table))
            {
                GetTableIndex(table.TableName);
                beforeDatabase = File.ReadLines(FilePath).TakeWhile(x => x != "/START@" + table.TableName).ToList();
                afterDatabase = File.ReadLines(FilePath).SkipWhile(x => x != "END@" + table.TableName + "/").Skip(1).ToList();

                beforeDatabase.AddRange(afterDatabase);
                CreateTable(beforeDatabase);
            }
        }

        public Table GetTableFromDatabase(string tableName)
        {
            Table table = new Table();
            table.TableName = tableName;

            List<string> allTable = GetDbList(table);

            string[] columnsValuesArray;
            string[] valuesArray;

            foreach (string line in allTable)
            {
                columnsValuesArray = line.Split('@').ToArray();
                valuesArray = columnsValuesArray[1].Split(',').ToArray();
                table.TableValuesCount = valuesArray.Length;

                foreach (string str in columnsValuesArray);
                {
                    table.TableDictionary[columnsValuesArray[0]] = valuesArray.ToList();
                }
            }
            return table;
        }
        private List<string> GetDbList(Table table)
        {
            List<string> allTable = new List<string>();

            if (IsTableExists(table))
            {
                string temp = "END@" + table.TableName + "/";
                allTable = File.ReadLines(FilePath).Skip(GetTableIndex(table.TableName) - 1).TakeWhile(x=>x != temp).ToList();
            }
            return allTable;
        }
        //private DbDataReader GetDbDataReader(List<string> allTable)
        //{
        //    DbDataReader reader = new DbDataReader();
        //    string tableName;
        //    string[] tableColumns;
        //    string[] tempArray;
        //    foreach (string line in allTable)
        //    {
        //        tempArray = line.Split('@');
        //        tableName = tempArray[0];
        //        tableColumns = tempArray[1].Split(',');
        //        reader.Dictionary[tableName] = tableColumns.ToList(); 
        //    }

        //    return reader;
        //}
    }
}