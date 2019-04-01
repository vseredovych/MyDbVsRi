using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
namespace DAL.Operations
{
    public class Operations
    {
        public int GetTableIndex(string filePath, string tableName)
        {
            using (StreamReader streamReader = File.OpenText(filePath))
            {
                int count = 0;
                string line = "";
                string[] lineWords = new string[2];

                while ((line = streamReader.ReadLine()) != null)
                {
                    count += 1;
                    if (line == "/$$")
                    {
                        line = streamReader.ReadLine();
                        lineWords = line.Split(':');
                        count += 1;
                        if (lineWords != null && lineWords.Length > 1 && lineWords[1] == tableName)
                        {
                            return count;
                        }
                    }
                }
                return -1;
            }
        }

        public void createTable(string filePath, string[] tableColumns, string tableName)
        {
            using (StreamWriter streamWriter = File.AppendText(filePath))
            {
                streamWriter.WriteLine("/$$");
                streamWriter.WriteLine("TableName" + ":" + tableName);
                streamWriter.WriteLine("TableLenght:" + 0);

                for (int i = 1; i < tableColumns.Length; i++)
                {
                    streamWriter.WriteLine(tableColumns[i] + ":");
                }
                streamWriter.WriteLine("$$/");
            }
        }
        public bool IsTableExists(string filePath, string tableName)
        {
            if (GetTableIndex(filePath, tableName) != -1)
            {
                return true;
            }
            return false;
        }
        public void AddTableElement(string filePath, Entity entity, string tableName, string[] tableColumns)
        {
            using (StreamReader streamReader = File.OpenText(filePath))
            {
                string line = "";
                List<string> lines = new List<string>();
                //string[] tableLines = new string[2];
                Object[] objects = entity.GetOblectArray();

                if (IsTableExists(filePath, tableName))
                {
                    Console.WriteLine(GetTableIndex(filePath, tableName));
                    lines = File.ReadLines(filePath).Skip(GetTableIndex(filePath, tableName) - 1).Take(objects.Length + 1).ToList();
                }


            }
        }
        public void GetListOfObjectsInTable(string filePath, Entity entity, string tableName, string[] tableColumns)
        {
            using (StreamReader streamReader = File.OpenText(filePath))
            {
                string line = "";
                List<string> lines = new List<string>();
                //string[] tableLines = new string[2];
                Object[] objects = entity.GetObjectArray();

                if (IsTableExists(filePath, tableName))
                {
                    Console.WriteLine(GetTableIndex(filePath, tableName));
                    lines = File.ReadLines(filePath).Skip(GetTableIndex(filePath, tableName) - 1).Take(objects.Length + 1).ToList();
                }

                foreach (object ob in entity.ge)
                {
                    GetValuesFromListByKey(ob.ToString())
                }

            }
        }
        private string[] GetValuesFromListByKey(string[] list, string key)
        {
            foreach (string el in list)
            {
                if (el.Split(':')[0] == key)
                {
                    return el.Split(':').Skip(1).ToArray();
                }
            }
            return null;
        }
    }
}