using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Drawing;

namespace ZbW.Testing.Dms.Client.Services
{
    class DocumentLibrary
    {
        private string targetPath = @"C:\Temp\DMS";
        private string id;

        public string FilePath;

        public DocumentLibrary()
        {
            var newGuid = Guid.NewGuid();
            this.id = newGuid.ToString();
        }

        public DocumentLibrary(string guid)
        {
            this.id = guid;
        }

        public void SaveFileInFolder(string path, string fileTyp)
        {
            var fileName = CreateDmsSaveFileName(path, fileTyp);
            this.FilePath = Path.Combine(targetPath, fileName);
            File.Copy(Path.Combine(path), Path.Combine(targetPath, fileName), true);

        }

        public void CheckIfFolderExists()
        {

        }

        //Only .pdf files can be saved
        public string CreateDmsSaveFileName(string filePath, string fileTyp)
        {

            switch (fileTyp)
            {
                case ".pdf":
                    return this.id + "_" + this.GetFileNameFromPath(filePath) + ".pdf";
                    break;
                    
                case ".xml":
                    return this.id + "_" + "Metadaten" + ".xml";
                    break;
            }

            return null;
        }


        public string GetFileNameFromPath(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }
    }
}
