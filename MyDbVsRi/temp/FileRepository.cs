//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ChmodVsRi
//{
//    class TableRepository
//    {
//        List<File> files;
//        public FileRepository()
//        {
//            files = new List<File>();
//        }
//        public void AddToRepository(File file)
//        {
//            files.Add(file);
//        }
//        public string[] getFileNames()
//        {
//            List<string> names = new List<string>();
//            foreach (File el in files)
//            {
//                names.Add(el.fileInfo.Name);
//            }
//            return names.ToArray();
//        }
//        public string[] getFileNamesAndRights()
//        {
//            List<string> names = new List<string>();
//            foreach (File el in files)
//            {
//                names.Add(el.fileInfo.Name + "\t" + el.getRightsString());
//            }
//            return names.ToArray();
//        }
//        public int isFileExist(string name)
//        {
//            for (int i = 0; i < files.Count; i++)
//            {
//                if (files[i].fileInfo.Name == name)
//                {
//                    return i;
//                }
//            }
//            return -1;
//        }
//        public File getFileByName(string name)
//        {
//            if (isFileExist(name) != -1)
//            {
//                return files[isFileExist(name)];
//            }
//            return null;
//        }
//    }
//}
