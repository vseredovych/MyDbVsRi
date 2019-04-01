using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDbVsRi
{
    class FileHelper
    {
        string folderName;
        string workDirectoryPath;
        string fileName;
        public FileHelper()
        {
            folderName = "defaultFolder";
            fileName = "defaultFileName.txt";

            workDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
        }
        private void CreateFolder(string folderName)
        {
            this.folderName = folderName;
            if (!Directory.Exists(workDirectoryPath + folderName))
            {
                Directory.CreateDirectory(folderName);
            }
        }
        public void CreateFile(string fileName)
        {
            this.fileName = fileName + ".txt";
            if (!File.Exists(getFilePath()))
            {
                File.Create(getFilePath()).Close();
            }
        }
        public void CreateFile(string fileName, string folderName)
        {
            CreateFolder(folderName);
            CreateFile(fileName);
        }
        public void DeleteFolder()
        {
            if (Directory.Exists(workDirectoryPath + folderName))
            {
                Directory.Delete(folderName);
            }
        }
        public void DeleteFile()
        {
            if (File.Exists(getFilePath()))
            {
                File.Delete(getFilePath());
            }
        }
        public string getFilePath()
        {
            return (workDirectoryPath + folderName + "\\" + fileName);
        }



        public string getDirectoryPath()
        {
            return workDirectoryPath;
        }
        public string getDirectoryName()
        {
            return folderName;
        }
    }
}
