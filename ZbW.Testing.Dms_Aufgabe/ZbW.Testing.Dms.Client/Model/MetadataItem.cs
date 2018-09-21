using System;
using System.Data;

namespace ZbW.Testing.Dms.Client.Model
{
    public class MetadataItem
    {
        // TODO: Write your Metadata properties here

        public string Bezeichnung { get; set; } //Required Fields
        public DateTime ValutaDatum { get; set; } //Required Fields
        public string Typ { get; set; } //Required Fields
        public string Stichwoerter { get; set; } //Optional Fields

        public MetadataItem(string bezeichnung, DateTime valutaDatum, string type, string stichwoerter)
        {
            this.Bezeichnung = bezeichnung;
            this.ValutaDatum = valutaDatum;
            this.Typ = type;
            this.Stichwoerter = stichwoerter;

        }
        public MetadataItem()
        {
        }
    }
}