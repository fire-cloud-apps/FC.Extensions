using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FC.Core.Extension.Office.ExcelHandlers
{
    /// <summary>
    /// An Extension method to retun excel data as memory stream.
    /// </summary>
    public static class ToExcelAsStreamExtension
    {
        /// <summary>
        /// Converts the List of Items to Excel
        /// </summary>
        /// <typeparam name="T">Model Type</typeparam>
        /// <param name="listOfData">List of Model Data</param>        
        /// <param name="needHeader">if yes, excel will have header else no header</param>
        /// <example>
        /// <code>
        /// IList datalist;
        /// ...
        /// MemoryStream ms = dataList.ToExcel()  
        /// return File(ms, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report.xlsx");
        /// </code>
        /// </example>
        /// <returns>MemoryStream</returns> 
        /// <remarks>
        /// https://spreadsheetlight.com/sample-code/ 
        /// -
        /// https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.file?view=aspnetcore-5.0
        /// </remarks>
        public static MemoryStream ToExcelAsStream<T>(this List<T> listOfData,  bool needHeader = true) where T : class
        {
            #region Validate the Parameters

            if (listOfData == null)
            {
                throw new ArgumentException($"Invalid Data 'listofData'");
            }
            #endregion

            Dictionary<string, string> objHeaders = ToExcelExtension.GetHeaders<T>();
            dynamic[,] objData = ToExcelExtension.GetData(listOfData, objHeaders);
            MemoryStream ms = new MemoryStream();

            using (SLDocument sl = new SLDocument())
            {
                int rowStart = 1;
                rowStart = ToExcelExtension.EnableHeader(needHeader, objHeaders, sl, rowStart);

                //Set the Rows in the list
                int colLength = objHeaders.Count;
                ToExcelExtension.AddRows(listOfData, objData, sl, rowStart, colLength);
                //sl.SaveAs(pathToSave);
                sl.SaveAs(ms);
            }
            ms.Position = 0;

            return ms;
        }
    }
}
