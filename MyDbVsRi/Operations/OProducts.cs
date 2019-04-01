using System;
using System.Diagnostics;
using System.IO;

namespace DAL.Operations
{
    public class OPruduct
    {
        public static readonly string[] TableNames = { "Products", "Id", "Name", "Price", "Status", "MerchantId", "CreatedAt" };

        //public void createTable(string filePath)
        //{
        //    using (StreamWriter streamWriter = File.AppendText(filePath))
        //    {
        //        streamWriter.WriteLine("TableName" + ": " + TableNames[0]);

        //        for (int i = 1; i < TableNames.Length; i++)
        //        {
        //            streamWriter.WriteLine(TableNames[i] + ":");
        //        }
        //    }
        //}
    }
}
