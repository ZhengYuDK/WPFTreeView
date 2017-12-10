using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfBasicTreeView1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var allLogicDrives = Directory.GetLogicalDrives();
            foreach (var drive in allLogicDrives)
            {
                var item = new TreeViewItem();
                item.Header = drive;
                item.Tag = drive;
                item.Items.Add(null);
                item.Expanded += Folder_Explanded;
                FolderView.Items.Add(item);
            }
        }

        private void Folder_Explanded(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;

            if (item.Items.Count != 1 || item.Items[0] != null)
                return;

            //Clear dummy data
            item.Items.Clear();

            //Get full path
            var fullPath = (string) item.Tag;

            #region Get folder
            var directories = new List<string>(); 

            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                    directories.AddRange(dirs);
            }
            catch { }

            directories.ForEach(directoryPath =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = GetFileFolderName(directoryPath),
                    Tag = directoryPath  
                };
                subItem.Items.Add(null);
                subItem.Expanded += Folder_Explanded;
                item.Items.Add(subItem);
            });
            #endregion

            #region Get files
            var files = new List<string>();
            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                    files.AddRange(fs);
            }
            catch { }

            files.ForEach(filePath =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = GetFileFolderName(filePath),
                    Tag = filePath
                };
                item.Items.Add(subItem);
            });
            #endregion
        }

        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            var normalizedPath = path.Replace('/', '\\');
            var lastIndex = normalizedPath.LastIndexOf('\\');

            // if we don't find a backslash, return the path itself 
            if (lastIndex <= 0)
                return path;

            var output = path + "  ==>  " + path.Substring(lastIndex + 1);
            Console.WriteLine(output);
            return path.Substring(lastIndex + 1);
        }

        
    }
}
