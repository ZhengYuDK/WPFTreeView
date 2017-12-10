using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Input;
using WpfBasicTreeView1.DiretoryService.ViewModels;

namespace WpfBasicTreeView1.ViewModels
{
    public class DirectoryItemViewModel : BaseViewModel
    {
        private const string USERNAME = "Xu Xin 徐鑫";
        private string _title ;

        // User PropertyChanged.Fody it requires a FodyWeater.xml
        public string Counter { get; set; }

        public ICommand ExpandCommand { get; set; }

        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            this.FullPath = fullPath;
            this.Type = type;
            this.ExpandCommand = new RelayCommand(Expand);
            ClearChildren();
            Task.Run(async () =>
            {
                int i = 0;
                while (true)
                {
                    await Task.Delay(200);
                    var newCounter = (i++).ToString();
                    //Title = USERNAME + newCounter;
                    Counter = newCounter;
                }
            });
        }

        public DirectoryItemType Type { get; set; }
        public string FullPath { get; set; }

        public string Name => this.Type == DirectoryItemType.Drive
            ? this.FullPath
            : DirectoryService. GetFileFolderName(FullPath);

        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        public bool CanExpand => this.Type != DirectoryItemType.File;

        public bool IsExpanded
        {
            get => Children?.Count(qq => qq != null) > 0;

            set
            {
                if(value == true)  // If UI tells us to expand
                    Expand();      // Find all children 
                else
                {                           
                    this.ClearChildren();   // if UI tells us to close
                }
            }
        }

        private void ClearChildren()
        {
            this.Children = new ObservableCollection<DirectoryItemViewModel>();

            // Show the expand arrow if we are not a file ( By default, if any item has a subitem , even it is null, WPF shows it with arrow 
            if(this.Type!= DirectoryItemType.File)
                this.Children.Add(null);
        }

        // Expands this directory and finds all chilren 
        private void Expand()
        {
            if (this.Type == DirectoryItemType.File)
                return;

            var contents = DirectoryService.GetDirectoryContents(this.FullPath);
            this.Children = new ObservableCollection<DirectoryItemViewModel>(contents.Select(content => new DirectoryItemViewModel(content.FullPath, content.Type))); 

        }




    }
}
