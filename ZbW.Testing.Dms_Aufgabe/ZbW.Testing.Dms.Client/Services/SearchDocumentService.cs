using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    class SearchDocumentService
    {
        private string _filePath;
        public string MetadataItemFile { get; private set; }
        public string PdfItemFile { get; private set; }

        public SearchDocumentService()
        {
            this._filePath = ConfigurationManager.AppSettings["RepositoryDir"];
        }

        public List<MetadataItem> SearchMetaDataItemsAndAddToList()
        {
            var directories = Directory.GetFiles(this._filePath);
            var foundItems = new List<MetadataItem>();
            foreach (var file in directories)
            {
                if (Path.GetExtension(file).Equals(".pdf"))
                {
                    this.PdfItemFile = file;
                }

                if (Path.GetExtension(file).Equals(".xml"))
                {
                    {
                        this.MetadataItemFile = file;
                        using (var fileStream = File.Open(file, FileMode.Open, FileAccess.Read))
                        {
                            System.Xml.Serialization.XmlSerializer writer =
                                new System.Xml.Serialization.XmlSerializer(typeof(MetadataItem));
                            var item = writer.Deserialize(fileStream) as MetadataItem;

                            foundItems.Add(item);

                        }
                    }
                }
            }

            return foundItems;
        }
        public List<MetadataItem> SearchItemsByKeywordOrTyp(string value)
        {
            var allItems = new List<MetadataItem>();
            allItems = this.SearchMetaDataItemsAndAddToList();
            var foundItems = new List<MetadataItem>();

            foreach (var item in allItems)
            {
                if (item.Bezeichnung.Contains(value) || item.Typ.Contains(value))
                {
                    foundItems.Add(item);
                }

            }

            return foundItems;

        }

        public List<MetadataItem> SearchItemsByKeywordAndTyp(string keyword, string typ)
        {
            var allItems = new List<MetadataItem>();
            allItems = this.SearchMetaDataItemsAndAddToList();
            var foundItems = new List<MetadataItem>();


            foreach (var item in allItems)
            {
                if (item.Bezeichnung.Contains(keyword) && item.Typ.Contains(typ))
                {
                    foundItems.Add(item);
                }


            }

            return foundItems;

        }
    }
}
