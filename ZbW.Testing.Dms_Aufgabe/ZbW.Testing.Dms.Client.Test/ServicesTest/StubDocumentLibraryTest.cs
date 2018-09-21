using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.Test.ServicesTest
{
    class StubDocumentLibraryTest
    {
        public string FilePath
        {
            get
            {
                return "C:\\test\\test";
            }
        }

        public string ID;

        public StubDocumentLibraryTest()
        {
        }

        public StubDocumentLibraryTest(string id)
        {
            this.ID = id;
        }

        public string GetFileNameFromPath(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }

        public string CreateDmsSaveFileName(string filePath, string fileTyp)
        {
            switch (fileTyp)
            {
                case ".pdf":
                    return this.ID + "_" + this.GetFileNameFromPath(filePath) + ".pdf";
                    break;

                case ".xml":
                    return this.ID + "_" + this.GetFileNameFromPath(filePath) + "_" + "Metadaten" + ".xml";
                    break;
            }

            return null;
        }
    }
}
