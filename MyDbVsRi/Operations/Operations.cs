using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Operations
{
    public class Operations
    {
        public void createTable(string filePath, string[] TableNames)
        {
            using (StreamWriter streamWriter = File.AppendText(filePath))
            {
                streamWriter.WriteLine("$$");
                streamWriter.WriteLine("TableName" + ":" + TableNames[0]);
                streamWriter.WriteLine("TableLenght:" + 0);

                for (int i = 1; i < TableNames.Length; i++)
                {
                    streamWriter.WriteLine(TableNames[i] + ":");
                }
            }
        }
        public bool isTableExists(string filePath, string tableName)
        {
            using (StreamReader streamReader = File.OpenText(filePath))
            {
                string line = "";
                string[] lineWords = new string[2]; 
                while ((line = streamReader.ReadLine()) != null)
                {
                    lineWords = line.Split(':');
                    if (lineWords[0] == "TableName")
                    {
                        if (lineWords[1] == tableName)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}
