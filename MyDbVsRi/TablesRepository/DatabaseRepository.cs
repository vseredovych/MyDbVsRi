//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MyDbVsRi;

//namespace MyDbVsRi.TablesRepository
//{
//    class DatabaseRepository
//    {
//        public Database dataBase { get; set; }
//        public Dictionary<string, Repository> Repositories { get; set; }
//        public Dictionary<string, List<string>> TableColumns { get; set; }
//        FileHelper FileHelper { get; set; }

//        List<Table> Tables;
//        public DatabaseRepository(FileHelper fileHelper)
//        {
//            FileHelper = fileHelper;
//            dataBase = new Database(fileHelper.getFilePath());
//            Tables = new List<Table>();
//            Repositories = new Dictionary<string, Repository>();
//            TableColumns = new Dictionary<string, List<string>>();
//        }
//        public void UpdateTableRepositories()
//        {
//            //dataBase.GetDbDataReader();
//        }
//        public void AddTable(string tableName, string[] tableColumns, Repository repository)
//        {

//            Table newTable = new Table(tableName, tableColumns);
//            if (!dataBase.IsTableExists(newTable))
//            {
//                dataBase.CreateEmptyTable(newTable);
//            }

//            Tables.Add(new Table(tableName, tableColumns));
//            Repositories[tableName] = repository;
//            TableColumns[tableName] = tableColumns.ToList();
//        }
//    }
//}
