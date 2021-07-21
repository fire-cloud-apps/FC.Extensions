using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FC.Core.Extension.FileHanders
{
    public static class FileExtensions
    {
        /// <summary>
        /// Get the List of Files that has not accessed based on the given days.
        /// </summary>
        /// <param name="dirName">Directory Path Name</param>
        /// <param name="days">Days in negative value</param>
        /// <param name="searchPattern">search pattern eg. *.txt, s*</param>
        /// <param name="notContains">skip the folder or file that contains the word or char eg. _t</param>
        /// <example>
        /// <code lang="csharp">
        /// var fileList = FileExtensions.GetLastModified(@"C:\Test", -60, "web*");
        /// </code>
        /// </example>
        /// <returns>List of Files</returns>
        /// <remarks>
        /// https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.enumeratefiles?view=net-5.0
        /// </remarks>
        public static IList<FileInfo> GetFilesByLastModified(string dirName, int days = -60, string searchPattern = null, string notContains = null)
        {
            IList<FileInfo> fileList = new List<FileInfo>();
            IEnumerable<string> files = null;

            try
            {
                files = searchPattern == null
                    ? Directory.EnumerateFiles(dirName, "*.*", SearchOption.AllDirectories)
                    : Directory.EnumerateFiles(dirName, searchPattern, SearchOption.AllDirectories);
            }
            catch { }

            if (files == null)
            {
                return null;
            }
            else
            {
                files = notContains == null ? files : files.Where(x => !x.Contains(notContains)).ToArray();
                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.LastWriteTime < DateTime.Now.AddDays(days))
                    {
                        fileList.Add(fi);
                    }
                }
            }
            return fileList;
        }
    }
}
