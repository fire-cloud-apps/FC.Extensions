using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FC.Core.Extension.FileHanders
{
	/// <summary>
	/// Deletes All the files with the given extension
	/// </summary>
    public static class DeleteFilesExtension
    {
		/// <summary>
		/// Deletes the files with the given extension
		/// </summary>
		/// <param name="folderPath">Folder path to which the file to be searched</param>
		/// <param name="ext">extension eg. 'cs', 'xlsx', etc</param>
		/// <example>
		/// <code lang="csharp">
		/// string path = @"C:\Temp\test";
		/// path.DeleteFiles("cs"); // Deletes all files with a CS extension
		/// </code>
		/// </example>
		/// <returns>Status of deleted files</returns>
		public static IList<DeletedFilesInfo> DeleteFiles(this string folderPath, string ext)
		{
			string mask = "*." + ext;
			IList<DeletedFilesInfo> delInfo = new List<DeletedFilesInfo>();
			string[] fileList = Directory.GetFiles(folderPath, mask);
			foreach (string file in fileList)
			{
				FileInfo fileInfo = new FileInfo(file);
				DeletedFilesInfo deletedFilesInfo = new DeletedFilesInfo()
				{
					FileName = fileInfo.FullName					
				};

                #region Error Handling
                try
                {
					fileInfo.Delete();
					deletedFilesInfo.Status = true;
				}
				catch(IOException ex)
                {
					deletedFilesInfo.ExceptionDetail = ex;
                }
				catch (System.Security.SecurityException ex)
				{
					deletedFilesInfo.ExceptionDetail = ex;
				}
				catch (UnauthorizedAccessException ex)
				{
					deletedFilesInfo.ExceptionDetail = ex;
				}
				#endregion
				delInfo.Add(deletedFilesInfo);

			}
			return delInfo;
        }

		/// <summary>
		/// Deletes the List of Files that has not accessed based on the given days.
		/// </summary>
		/// <param name="directoryPath">Directory Path Name</param>
		/// <param name="expiryInDays">Days in negative value</param>
		/// <param name="searchPattern">search pattern eg. *.txt, s*</param>
		/// <param name="notContains">skip the folder or file that contains the word or char eg. _t</param>
		/// <example>
		/// <code lang="csharp">
		/// var fileList = FileExtensions.GetLastModified(@"C:\Test", -60, "web*");
		/// </code>
		/// </example>
		/// <returns>List of deleted files</returns>
		/// <remarks>
		/// https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.enumeratefiles?view=net-5.0
		/// </remarks>
		public static IList<DeletedFilesInfo> DeleteExpiredFiles(this string directoryPath, int expiryInDays = -60, string searchPattern = null, string notContains = null)
        {
			IList<DeletedFilesInfo> delInfo = new List<DeletedFilesInfo>();
			IList<FileInfo> listOfFiles = FileExtensions.GetFilesByLastModified(directoryPath, expiryInDays, searchPattern, notContains);

			foreach (FileInfo fileInfo in listOfFiles)
			{
				DeletedFilesInfo deletedFilesInfo = new DeletedFilesInfo()
				{
					FileName = fileInfo.FullName
				};

				#region Error Handling
				try
				{
					fileInfo.Delete();
					deletedFilesInfo.Status = true;
				}
				catch (IOException ex)
				{
					deletedFilesInfo.ExceptionDetail = ex;
				}
				catch (System.Security.SecurityException ex)
				{
					deletedFilesInfo.ExceptionDetail = ex;
				}
				catch (UnauthorizedAccessException ex)
				{
					deletedFilesInfo.ExceptionDetail = ex;
				}                
				#endregion

				delInfo.Add(deletedFilesInfo);

			}

			try
			{
				DeleteEmptyDirectory(directoryPath);
			}
			catch { }

			return delInfo;
		}

		/// <summary>
		/// Deletes the List of Files that has not accessed based on the given days.
		/// </summary>
		/// <param name="directoryPath">Directory Path Name</param>
		/// <param name="expiryInDays">Days in negative value</param>
		/// <param name="searchPattern">search pattern eg. *.txt, s*</param>
		/// <param name="notContains">skip the folder or file that contains the word or char eg. _t</param>
		/// <example>
		/// <code lang="csharp">
		/// public void SmoothDeleteFiles_Test()
		///        {
		///            string path = @"C:\Test\MiniProfilerDemo";
		///		string[] folders = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
		///            foreach (var folder in folders)
		///            {
		///                _output.WriteLine($"Folder Name : {folder}");
		///                foreach(var file in folder.SmoothDelete(-45))
		///                {
		///                    _output.WriteLine($"---- Deleted File : {file.FileName}");
		///                }
		///}
		///        }
		/// </code>
		/// </example>
		/// <returns>List of deleted files</returns>
		/// <remarks>
		/// https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.enumeratefiles?view=net-5.0
		/// </remarks>
		public static IEnumerable<DeletedFilesInfo> SmoothDelete(this string directoryPath, int expiryInDays = -60, string searchPattern = null, string notContains = null)
		{
			IList<FileInfo> listOfFiles = FileExtensions.GetFilesByLastModified(directoryPath, expiryInDays, searchPattern, notContains);

			if (listOfFiles != null)
			{
				foreach (FileInfo fileInfo in listOfFiles)
				{
					DeletedFilesInfo deletedFilesInfo = new DeletedFilesInfo()
					{
						FileName = fileInfo.FullName
					};

					#region Error Handling
					try
					{
						fileInfo.Delete(); //for debug prupose deletion is removed.
						deletedFilesInfo.Status = true;
					}
					catch (IOException ex)
					{
						deletedFilesInfo.ExceptionDetail = ex;
					}
					catch (System.Security.SecurityException ex)
					{
						deletedFilesInfo.ExceptionDetail = ex;
					}
					catch (UnauthorizedAccessException ex)
					{
						deletedFilesInfo.ExceptionDetail = ex;
					}
					#endregion

					yield return deletedFilesInfo;


				}
			}
			DeleteEmptyDirectory(directoryPath);
		}

		/// <summary>
		/// Delete all the Empty Directory
		/// </summary>
		/// <param name="rootDirectory">Root Folder to scan</param>
		public static void DeleteEmptyDirectory(string rootDirectory)
		{
			foreach (var directory in Directory.GetDirectories(rootDirectory))
			{
				DeleteEmptyDirectory(directory);
				if (Directory.GetFiles(directory).Length == 0 &&
					Directory.GetDirectories(directory).Length == 0)
				{
					Directory.Delete(directory, false);
				}
			}
		}
	}

	/// <summary>
	/// Delete File helper class to get the details of file status
	/// </summary>
	public class DeletedFilesInfo
    {
		/// <summary>
		/// File Name
		/// </summary>
		public string FileName { get; set; }
		/// <summary>
		/// Status false or true
		/// </summary>
		public bool Status { get; set; }
		/// <summary>
		/// Error information if status is false
		/// </summary>
		public Exception ExceptionDetail { get; set; }
    }
}
