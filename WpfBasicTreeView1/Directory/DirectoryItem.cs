using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBasicTreeView1.Directory
{

    public enum DirectoryItemType
    {
        Drive,
        Folder,
        File
         
    }

    /// <summary>
    /// Information about directory item, whether it is drive, folder or file
    /// </summary>
    public class DirectoryItem
    {
        string FullPath { get; set; }
        string Name { get { return DirectoryService.GetFileFolderName(FullPath); } }
        string DirectoryItemType { get; set; }
    }
}
