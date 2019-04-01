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
                streamWriter.WriteLine("TableName" + ": " + TableNames[0]);

                for (int i = 1; i < TableNames.Length; i++)
                {
                    streamWriter.WriteLine(TableNames[i] + ":");
                }
            }
        }
    }
}
