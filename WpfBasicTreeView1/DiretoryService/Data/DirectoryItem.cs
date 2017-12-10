
namespace WpfBasicTreeView1
{

    /// <summary>
    /// Information about directory item, whether it is drive, folder or file
    /// </summary>
    public class DirectoryItem
    {
        public string FullPath { get; set; }

        public string Name
        {
            get
                {
                    return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryService.GetFileFolderName(FullPath);
                    
                }
        } 

        public DirectoryItemType Type { get; set; }
    }
}
