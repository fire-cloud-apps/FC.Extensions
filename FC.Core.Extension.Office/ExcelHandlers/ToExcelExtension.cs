using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

//Ref: https://spreadsheetlight.com/downloads/samplecode/HelloWorld.cs

namespace FC.Core.Extension.Office.ExcelHandlers
{

    /// <summary>
    /// Extension method to process Excel Files. An easy way to export Excel file.
    /// </summary>
    public static class ToExcelExtension
    {
        /// <summary>
        /// Converts the List of Items to Excel
        /// </summary>
        /// <typeparam name="T">Model Type</typeparam>
        /// <param name="listOfData">List of Model Data</param>
        /// <param name="pathToSave">Path to save Excel file with file name</param>
        /// <param name="needHeader">if yes, excel will have header else no header</param>
        /// <example>
        /// <code>
        /// IList datalist;
        /// ...
        /// dataList.ToExcel("ExcelProcess.xlsx")        
        /// </code>
        /// </example>
        public static void ToExcel<T>(this List<T> listOfData, string pathToSave, bool needHeader = true) where T : class
        {
            #region Validate the Parameters
            if (string.IsNullOrEmpty(pathToSave))
            {
                throw new ArgumentException($"Invalid File Path 'pathToSave'");
            }

            if(listOfData == null)
            {
                throw new ArgumentException($"Invalid Data 'listofData'");
            }
            #endregion

            Dictionary<string, string> objHeaders = GetHeaders<T>();            
            dynamic[,] objData = GetData(listOfData, objHeaders);
           
            using (SLDocument sl = new SLDocument())
            {
                int rowStart = 1;
                rowStart = EnableHeader(needHeader, objHeaders, sl, rowStart);

                //Set the Rows in the list
                int colLength = objHeaders.Count;
                AddRows(listOfData, objData, sl, rowStart, colLength);
                sl.SaveAs(pathToSave);
            }
        }

        #region Support Methods for 'ToExcel'
        /// <summary>
        /// Appends list of data into Excel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listOfData"></param>
        /// <param name="objData"></param>
        /// <param name="sl"></param>
        /// <param name="rowStart"></param>
        /// <param name="colLength"></param>
        /// <returns></returns>
        public static void AddRows<T>(List<T> listOfData, dynamic[,] objData, SLDocument sl, int rowStart, int colLength) where T : class
        {
            for (int row = 0; row < listOfData.Count; row++)
            {
                for (int col = 0; col < colLength; col++)
                {
                    var value = objData[row, col];
                    sl.SetCellValue(
                        RowIndex: rowStart,
                        ColumnIndex: col + 1,
                        Data: value);
                }
                rowStart++;
            }            
        }

        /// <summary>
        /// Enables Header based on the given parameter
        /// </summary>
        /// <param name="needHeader">bool value true or false</param>
        /// <param name="objHeaders">List of Headers</param>
        /// <param name="sl">Excel Object</param>
        /// <param name="rowStart">Row incremented Count</param>
        /// <returns>returns the updated row count</returns>
        public static int EnableHeader(bool needHeader, Dictionary<string, string> objHeaders, SLDocument sl, int rowStart)
        {
            int hCol = 1;
            if (needHeader)
            {
                foreach (var header in objHeaders)
                {
                    sl.SetCellValue(RowIndex: rowStart, ColumnIndex: hCol, Data: header.Value);
                    hCol++;
                }
                rowStart++;//move to next row;
            }

            return rowStart;
        }

        /// <summary>
        /// Get the data from List of Object
        /// </summary>
        /// <typeparam name="T">Model Type</typeparam>
        /// <param name="listOfData">List of Data</param>
        /// <param name="objHeaders">Header details</param>
        /// <returns>Returns Data in 2 dimension array</returns>
#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional
        public static dynamic[,] GetData<T>(List<T> listOfData, Dictionary<string, string> objHeaders) where T : class
#pragma warning restore CA1814 // Prefer jagged arrays over multidimensional
        {
            #region Get Property Values
            int count = listOfData.Count;
            dynamic[,] objData = new dynamic[count, objHeaders.Count];

            for (int j = 0; j < count; j++)
            {
                var item = listOfData[j];
                int i = 0;
                foreach (KeyValuePair<string, string> entry in objHeaders)
                {
                    var y = typeof(T).InvokeMember(entry.Key.ToString(), BindingFlags.GetProperty, null, item, null);
                    objData[j, i++] = (y == null) ? "" : y.ToString();
                }
            }
            #endregion
            return objData;
        }

        /// <summary>
        /// Gets the Header information, Property name is considered as Header Name
        /// </summary>
        /// <typeparam name="T">Model Type</typeparam>
        /// <returns>List of Header</returns>
        public static Dictionary<string, string> GetHeaders<T>() where T : class
        {
            #region Get Headers
            PropertyInfo[] headerInfo = typeof(T).GetProperties();

            Dictionary<string, string> objHeaders = new Dictionary<string, string>();
            foreach (var property in headerInfo)
            {
                var attribute = property.GetCustomAttributes(typeof(DisplayNameAttribute), false)
                                        .Cast<DisplayNameAttribute>().FirstOrDefault();
                objHeaders.Add(property.Name, attribute == null ?
                                    property.Name : attribute.DisplayName);
            }
            #endregion
            return objHeaders;
        }

        #endregion

        private static void Sample()
        {
            SLDocument sl = new SLDocument();

            // set a boolean at "A1"
            sl.SetCellValue("A1", true);

            // set at row 2, columns 1 through 20, a value that's equal to the column index
            for (int i = 1; i <= 20; ++i) sl.SetCellValue(2, i, i);

            // set the value of PI
            sl.SetCellValue("B3", 3.14159);

            // set the value of PI at row 4, column 2 (or "B4") in string form.
            // use this when you already have numeric data in string form and don't
            // want to parse it to a double or float variable type
            // and then set it as a value.
            // Note that "3,14159" is invalid. Excel (or Open XML) stores numerals in
            // invariant culture mode. Frankly, even "1,234,567.89" is invalid because
            // of the comma. If you can assign it in code, then it's fine, like so:
            // double fTemp = 1234567.89;
            sl.SetCellValueNumeric(4, 2, "3.14159");

            // normal string data
            sl.SetCellValue("C6", "This is at C6!");

            // typical XML-invalid characters are taken care of,
            // in particular the & and < and >
            sl.SetCellValue("I6", "Dinner & Dance costs < $10");

            // this sets a cell formula
            // Note that if you want to set a string that starts with the equal sign,
            // but is not a formula, prepend a single quote.
            // For example, "'==" will display 2 equal signs
            sl.SetCellValue(7, 3, "=SUM(A2:T2)");

            // if you need cell references and cell ranges *really* badly, consider the SLConvert class.
            sl.SetCellValue(SLConvert.ToCellReference(7, 4), string.Format("=SUM({0})", SLConvert.ToCellRange(2, 1, 2, 20)));

            // dates need the format code to be displayed as the typical date.
            // Otherwise it just looks like a floating point number.
            sl.SetCellValue("C8", new DateTime(3141, 5, 9));
            SLStyle style = sl.CreateStyle();
            style.FormatCode = "d-mmm-yyyy";
            sl.SetCellStyle("C8", style);

            sl.SetCellValue(8, 6, "I predict this to be a significant date. Why, I do not know...");

            sl.SetCellValue(9, 4, 456.123789);
            // we don't have to create a new SLStyle because
            // we only used the FormatCode property
            style.FormatCode = "0.000%";
            sl.SetCellStyle(9, 4, style);

            sl.SetCellValue(9, 6, "Perhaps a phenomenal growth in something?");

            sl.SaveAs("HelloWorld.xlsx");

            Console.WriteLine("End of program");
            //Console.ReadLine();
        }
    }
}
