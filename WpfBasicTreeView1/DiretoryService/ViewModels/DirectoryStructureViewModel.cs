using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfBasicTreeView1.ViewModels;

namespace WpfBasicTreeView1.DiretoryService.ViewModels
{
    /// <summary>
    /// The view model for the applications main directory view
    /// </summary>
    public class DirectoryStructureViewModel : BaseViewModel
    {
        /// <summary>
        /// A list of all directories on the machine
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        public DirectoryStructureViewModel()
        {
            var children = DirectoryService.GetLogicalDrives();
            this.Items = new ObservableCollection<DirectoryItemViewModel>(children.Select(drive =>
                new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive)));
        }
    }
}
