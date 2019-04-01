using System;
using System.IO;

namespace DAL.Operations
{
    public class OMerchant
    {
        public static readonly string[] TableNames = { "Merchants", "Id", "FirstName", "LastName", "Dob", "CurrentSity" };

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