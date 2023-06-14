using Duplicate_finder.Interface;
using Duplicate_finder.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.Storage.Pickers;

namespace Duplicate_finder.ViewModel
{
    /// <summary>
    /// This is the ViewModel
    /// It´s core function is to work as a connection between the Model (where all the data manipulation mainly takes place)
    /// and the View, which is meant for displaying all information.
    /// 
    /// This program allows the user to:
    /// 1. Select a folder
    /// 2. Search for duplicate files according to seleted criterias
    /// 3. Delete selected files displayed in the main view
    /// </summary>
    public partial class ViewModelBase : INotifyPropertyChanged
    {

        // Using Communitytoolkit.mvvm from Microsoft (see dependencies)
        // Shortens code whilst keeping functionality

        #region Field

        private string selectedPath;

        DuplicateFileManager<FileInformation> fileManager; // All duplicate files

        private IList<object> filesToDelete = new List<object>(); // All files to delete by selection of user

        private bool dateCreated;
        private bool fileName;
        private bool dateModified;
        private bool size;
        private bool type;
        private bool subfolders;


        ObservableCollection<FileInformation> files; // Duplicate files found to display

        #endregion

        public event PropertyChangedEventHandler PropertyChanged; // Eventhandler

        // Invoke event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Properties

        public bool DateCreated
        {
            get => dateCreated;

            set
            {
                dateCreated = value;
                OnPropertyChanged(nameof(DateCreated));

            }

        }

        public bool DateModified
        {
            get => dateModified;

            set
            {
                dateModified = value;
                OnPropertyChanged(nameof(DateModified));

            }

        }

        public bool FileName
        {
            get => fileName;

            set
            {
                fileName = value;
                OnPropertyChanged(nameof(FileName));

            }

        }

        public bool Size
        {
            get => size;

            set
            {
                size = value;
                OnPropertyChanged(nameof(Size));

            }

        }

        public bool Type
        {
            get => type;

            set
            {
                type = value;
                OnPropertyChanged(nameof(Type));

            }

        }

        public bool SubFolders
        {
            get => subfolders;

            set
            {
                subfolders = value;
                OnPropertyChanged(nameof(SubFolders));

            }

        }

        public string SelectedPath 
        {

            get => selectedPath;
            
            set
            {
                if(value != null) 
                    selectedPath = value;
                OnPropertyChanged(nameof(SelectedPath));
            }
        }

        public DuplicateFileManager<FileInformation> FileManager
        {

            get => fileManager;

            set
            {
                if (value != null)
                    fileManager = value;
                OnPropertyChanged(nameof(FileManager));
            }
        }

        public ObservableCollection<FileInformation> Files
        {
            get => files;

            set
            {
                if (value != null)
                    files = value;
                OnPropertyChanged(nameof(Files));
            }


        }

        public IList<object> FilesToDelete
        {
            get => filesToDelete;

            set
            {
                if(value != null)
                    filesToDelete = value;
                OnPropertyChanged(nameof(Files));
            }

        }



        #endregion


        public ViewModelBase()
        {
            Files = new ObservableCollection<FileInformation>();

            SelectPathCommand = new Command(async() => await SelectPath());

            SearchFileCommand = new Command(SearchFiles);

            DeleteFilesCommand = new Command(DeleteFiles);
        }

        #region Select file

        public Command SelectPathCommand { get; }

        /// <summary>
        /// Let´s the user select a file to be compared with.
        /// Calls record "SelectedFileInfo" to create a record with file information of the selected file (name, size etc).
        /// </summary>
        async Task SelectPath()
        {
            // Lets the user pick a folder
            try
            {
                // Code snippet taken from Microsoft

                // Creates new window
                var window = new Microsoft.UI.Xaml.Window();
     
                // To be projected as a Windows window
                var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(window);

                // Class for selecting folder
                var folderPicker = new FolderPicker();
                folderPicker.FileTypeFilter.Add("*");

                // Displays the Windows window
                WinRT.Interop.InitializeWithWindow.Initialize(folderPicker, hwnd);

                // Folder selected by the user
                var folder = await folderPicker.PickSingleFolderAsync();

                if (folder != null) { SelectedPath = folder.Path; }

            }

            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("A error occured!", ex.Message, "OK");
            }

        }

        #endregion

        #region Search file

        public Command SearchFileCommand { get; }

        /// <summary>
        /// Searches similar files to the selected file by the user, if any file has been chosen. The files displayed
        /// are according to the search criteria(s) in the checkboxes.
        /// </summary>
        async void SearchFiles()
        {
            List<FileInformation> files;

            if (SearchParameterSelected())

            {
                try
                {

                    if (SelectedPath != null)
                    {

                        FileManager = new DuplicateFileManager<FileInformation>();
                        files = FileSearcher.GetFiles(SelectedPath, SearchParameter());


                        if (files != null)
                        {
                            FileManager.Add(files);
                            Files.Clear();
                            UpdateCollectionView();
                        }

                    }
                }

                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("A error occured!", ex.Message, "OK");

                }

            }

            if (SelectedPath == null)
            {
                await Application.Current.MainPage.DisplayAlert("No path selected!",
                "You have to select a path, in order to perform a serach", "OK");
            }

            if (!SearchParameterSelected() && SelectedPath != null)
            {
                await Application.Current.MainPage.DisplayAlert("No search parameter selected",
                "You have to select a search parameter, excluding *Subfolders*, in order to perform a search.", "OK");
            }

        }

        /// <summary>
        /// Controlling if any search parameter, excluding subfolders
        /// </summary>
        /// <returns>True if atleast one search parameter has been selected</returns>
        private bool SearchParameterSelected() => DateCreated || DateModified || FileName || Size || Type;

        private (bool DateCreated, bool DateModified, bool FileName, bool Size, bool Type, bool SubFolders) SearchParameter() =>
            (DateCreated, DateModified, FileName, Size, Type, SubFolders);

        #endregion

        /// <summary>
        /// Iterates through all files found and adds them to the collectionview
        /// </summary>
        private void UpdateCollectionView()
        {
            for (short i = 0; i < FileManager.Count; i++)
            {
                Files.Add(FileManager.GetItem(i));
            }
        }
        #region Delete file


        public Command DeleteFilesCommand { get; }

        /// <summary>
        /// This method is responsible for deleting the selected files by the user
        /// </summary>

        protected async void DeleteFiles()
        {
           
            if (SelectedPath != null && FilesToDelete.Count > 0)
            {
                // User warning before deleting
                bool ok = await Application.Current.MainPage.DisplayAlert("WARNING!",
                    "Deleting file(s) can be dangerous. Are you SURE you want to continue?", "Yes", "No");

                if (ok)
                {
                    try
                    {
                        // Deletes each file
                        foreach (FileInformation file in FilesToDelete)
                        {
                            FileManager.DeleteFile(file.FullPath);
                        }
                        SearchFiles();

                    }

                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("A error occured!", ex.Message, "OK");
                    }


                }
            }

            else await Application.Current.MainPage.DisplayAlert("Could not comply",
                    "You have to select a file to search for and files to delete.", "OK");
        }

        #endregion

    }
}
