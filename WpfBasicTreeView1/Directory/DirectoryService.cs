using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBasicTreeView1.Directory
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
    }
}
