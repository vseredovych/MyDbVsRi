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
                        streamWriter.Write(FillScreeningCharacters(table.TableDictionary[table.TableColumns[i]][j]) );
                        streamWriter.Write(",");
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

                    table.TableColumns.Add(columnsValuesArray[0]);
                }
                return table;
            }
            else
            {
                foreach (string line in allTable)
                {
                    columnsValuesArray = line.Split('@').ToArray();

                    valuesArray = GetScreeningString(columnsValuesArray[1]);
                    table.TableValuesCount = valuesArray.Length;

                    table.TableColumns.Add(columnsValuesArray[0]);
                    table.TableDictionary[columnsValuesArray[0]] = valuesArray.ToList();
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

        private string FillScreeningCharacters(string dbString)
        {
            if (dbString.Contains(","))
            {
                dbString.Replace(",",",,");
                return dbString;
            }
            else
            {
                return dbString;
            }
        }
        private string[] GetScreeningString(string dbString) 
        {

            List<string> dbElements = new List<string>();
            int lastSeparator = -1;

            for (int i = 0; i < dbString.Length; i++)
            {
                if (dbString[i] == ',')
                {
                    if ((i + 1 < dbString.Length) && dbString[i + 1] == ',')
                    {
                        continue;
                    }
                    else
                    {
                        if (lastSeparator == -1)
                        {
                            dbElements.Add(dbString.Substring(0, i));
                            lastSeparator = i;
                        }
                        else
                        {
                            dbElements.Add(dbString.Substring(lastSeparator + 1, i - lastSeparator - 1));
                            lastSeparator = i;
                        }
                    }
                }
            }

            return dbElements.ToArray();
        }
    }
}