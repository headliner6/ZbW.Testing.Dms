using System.IO;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.ViewModels
{
    using System.Collections.Generic;

    using Prism.Commands;
    using Prism.Mvvm;

    using ZbW.Testing.Dms.Client.Model;
    using ZbW.Testing.Dms.Client.Repositories;

    internal class SearchViewModel : BindableBase
    {
        private List<MetadataItem> _filteredMetadataItems;

        private MetadataItem _selectedMetadataItem;

        private string _selectedTypItem;

        private string _suchbegriff;

        private List<string> _typItems;

        private SearchDocumentService searchService;

        public SearchViewModel()
        {
            TypItems = ComboBoxItems.Typ;

            CmdSuchen = new DelegateCommand(OnCmdSuchen);
            CmdReset = new DelegateCommand(OnCmdReset);
            CmdOeffnen = new DelegateCommand(OnCmdOeffnen, OnCanCmdOeffnen); // OnCanCmdOeffnen
        }

        public DelegateCommand CmdOeffnen { get; }

        public DelegateCommand CmdSuchen { get; }

        public DelegateCommand CmdReset { get; }

        public string Suchbegriff
        {
            get
            {
                return _suchbegriff;
            }

            set
            {
                SetProperty(ref _suchbegriff, value);
            }
        }

        public List<string> TypItems
        {
            get
            {
                return _typItems;
            }

            set
            {
                SetProperty(ref _typItems, value);
            }
        }

        public string SelectedTypItem
        {
            get
            {
                return _selectedTypItem;
            }

            set
            {
                SetProperty(ref _selectedTypItem, value);
            }
        }

        public List<MetadataItem> FilteredMetadataItems
        {
            get
            {
                return _filteredMetadataItems;
            }

            set
            {
                SetProperty(ref _filteredMetadataItems, value);
            }
        }

        public MetadataItem SelectedMetadataItem
        {
            get
            {
                return _selectedMetadataItem;
            }

            set
            {
                if (SetProperty(ref _selectedMetadataItem, value))
                {
                    CmdOeffnen.RaiseCanExecuteChanged();
                }
            }
        }

        private bool OnCanCmdOeffnen()
        {
            return SelectedMetadataItem != null;
        }

        private void OnCmdOeffnen()
        {
            // TODO: Add your Code here
            var pdfDataWithExtension = searchService.PdfItemFile;
            var pdfData = Path.ChangeExtension(pdfDataWithExtension, ".pdf");

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.EnableRaisingEvents = false;
            process.StartInfo.FileName = pdfData;
            process.Start();
        }

        private void OnCmdSuchen()
        {
            this.searchService = new SearchDocumentService();
            //searchService.FileOpen();
            // TODO: Add your Code here
            {
                this.FilteredMetadataItems = searchService.SearchMetaDataItemsAndAddToList();

                if (_suchbegriff != null || _selectedTypItem != null)
                {
                    if (_suchbegriff != null && _selectedTypItem == null)
                    {
                        FilteredMetadataItems = searchService.SearchItemsByKeywordOrTyp(_suchbegriff);

                    }
                    else if (_selectedTypItem != null && _suchbegriff == null)
                    {
                        FilteredMetadataItems = searchService.SearchItemsByKeywordOrTyp(_selectedTypItem);
                    }
                    else if (_selectedTypItem != null && _selectedTypItem != null)
                    {
                        FilteredMetadataItems =
                            searchService.SearchItemsByKeywordAndTyp(_suchbegriff, _selectedTypItem);
                    }


                }

            }
        }

        private void OnCmdReset()
        {
            // TODO: Add your Code here
        }
    }
}