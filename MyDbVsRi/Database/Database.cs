using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace MyDbVsRi
{
    public class Database           //All Db operations
    {
        string FilePath;
        public Database(string filePath)
        {
            FilePath = filePath;
        }
        public bool IsTableExists(string tableName)
        {
            if (GetTableIndex(tableName) != -1)
            {
                return true;
            }
            return false;
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
        public void DeleteTable(string tableName)
        {
            List<string> beforeDatabase = new List<string>();
            List<string> afterDatabase = new List<string>();

            if (IsTableExists(tableName))
            {
                GetTableIndex(tableName);
                beforeDatabase = File.ReadLines(FilePath).TakeWhile(x => x != "/START@" + tableName).ToList();
                afterDatabase = File.ReadLines(FilePath).SkipWhile(x => x != "END@" + tableName + "/").Skip(1).ToList();

                beforeDatabase.AddRange(afterDatabase);
                CreateTable(beforeDatabase);
            }
        }
        public void CreateEmptyTable(Table table)
        {
            if (!IsTableExists(table.TableName))
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
        }
        public void UpdateTable(Table table)
        {
            DeleteTable(table.TableName);

            using (StreamWriter streamWriter = File.AppendText(FilePath))
            {
                streamWriter.WriteLine("/START@" + table.TableName);

                for (int i = 0; i < table.TableDictionary.Count; i++)
                {
                    streamWriter.Write(table.TableColumns[i] + "@");
                    for (int j = 0; j < table.TableValuesCount; j++)
                    {
                        streamWriter.Write(table.TableDictionary[table.TableColumns[i]][j]);
                        if (j != table.TableValuesCount - 1)
                        {
                            streamWriter.Write(",");
                        }
                    }
                    streamWriter.WriteLine();
                }
                streamWriter.WriteLine("END@" + table.TableName + "/");
            }
        }

        public Table GetTableFromDatabase(string tableName)
        {
            Table table = new Table();
            table.TableName = tableName;

            List<string> allTable = GetDbList(tableName);

            string[] columnsValuesArray;
            string[] valuesArray;

            if (!IsTableExists(tableName))
            {
                foreach (string line in allTable)
                {
                    columnsValuesArray = line.Split('@').ToArray();
                    table.TableValuesCount = 0;
                    foreach (string str in columnsValuesArray) ;
                    {
                        table.TableColumns.Add(columnsValuesArray[0]);
                    }
                }
                return table;
            }
            else
            {
                foreach (string line in allTable)
                {
                    columnsValuesArray = line.Split('@').ToArray();
                    valuesArray = columnsValuesArray[1].Split(',').ToArray();
                    table.TableValuesCount = valuesArray.Length;
                    foreach (string str in columnsValuesArray) ;
                    {
                        table.TableColumns.Add(columnsValuesArray[0]);
                        table.TableDictionary[columnsValuesArray[0]] = valuesArray.ToList();
                    }
                }
                return table;
            }
        }
        private List<string> GetDbList(string tableName)
        {
            List<string> allTable = new List<string>();

            if (IsTableExists(tableName))
            {
                string temp = "END@" + tableName + "/";
                allTable = File.ReadLines(FilePath).Skip(GetTableIndex(tableName) - 1).TakeWhile(x=>x != temp).ToList();
            }
            return allTable;
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
    }
}