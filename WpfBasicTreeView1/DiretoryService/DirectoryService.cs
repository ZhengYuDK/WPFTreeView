using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WpfBasicTreeView1
{
    /// <summary>
    /// Helper class to query information about directories
    /// </summary>
    public static class DirectoryService
    {
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

        public static List<DirectoryItem> GetLogicalDrives()
        {
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive,Type =DirectoryItemType.Drive}).ToList();
        }

        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            var items = new List<DirectoryItem>();

            #region Get Folders
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem{ FullPath = dir, Type = DirectoryItemType.Folder}));
            }
            catch { }
            #endregion

            #region Get Files
            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                    items.AddRange(fs.Select(file => new DirectoryItem { FullPath = file, Type = DirectoryItemType.File }));
            }
            catch { }
            #endregion

            return items;
        }
    }
}
