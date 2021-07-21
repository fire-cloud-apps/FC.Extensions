using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace FC.Extension.Office.ExcelHandlers
{
    /// <summary>
    /// Class Converts the Excel data into the given List
    /// </summary>
    public static class ConvertToListFromExcel
    {
        /// <summary>
        /// Converts the Excel data into the given List
        /// </summary>
        /// <typeparam name="T">Model Type</typeparam>
        /// <param name="excelPath">Excel Path</param>
        /// <param name="sheetName">Sheet Name</param>
        /// <param name="skipHeader">Skip header or not</param>
        /// <example>
        /// <code lang="csharp">
        /// ConvertToListFromExcel.ConvertToList &lt;DummyDataExport&gt;(excelPath, "Sheet2");
        /// </code>
        /// </example>
        /// <returns>List of Model</returns>
        public static IList<T> ConvertToList<T>(string excelPath, string sheetName, bool skipHeader = true) where T: new()
        {
            IList<T> listModel = new List<T>();
            using (SLDocument sl = new SLDocument(excelPath, sheetName))
            {
                SLWorksheetStatistics statistics = sl.GetWorksheetStatistics();
                int rows = statistics.NumberOfRows;
                int columns = statistics.NumberOfColumns;
                int startRow = 0;

                IList<string> headers = new List<string>();
                for (int iCol = 1; iCol <= columns; iCol++)
                {
                    headers.Add(sl.GetCellValueAsString(1, iCol));
                }

                if (skipHeader) startRow = startRow + 2;
               
                Type modelType = typeof(T);

                for (int iRows = startRow; iRows <= rows; iRows++)
                {
                    T model = new T();
                    for (int iCol = 1; iCol <= columns; iCol++)
                    {                                              
                        PropertyInfo pInfo = modelType.GetProperty(headers[iCol - 1]);
                        if (pInfo == null)
                        {
                            Debug.WriteLine($"PropertyInfo is null. Name : {headers[iCol - 1]}");
                            continue;
                        }
                        SetProperty(sl, iRows, model, iCol, pInfo);

                    }
                    listModel.Add(model);
                }

            }
                return listModel;
        }

        private static void SetProperty<T>(SLDocument sl, int iRows, T model, int iCol, PropertyInfo pInfo) where T : new()
        {
            string output;
            switch (pInfo.PropertyType.Name)
            {
                case "Int32":
                    int iCellValue = sl.GetCellValueAsInt32(iRows, iCol);
                    pInfo.SetValue(model, iCellValue);
                    output = $"({iRows}, {iCol}) Value {iCellValue}";
                    break;
                case "Double":
                    double doCellValue = sl.GetCellValueAsDouble(iRows, iCol);
                    pInfo.SetValue(model, doCellValue);
                    output = $"({iRows}, {iCol}) Value {doCellValue}";
                    break;
                case "Decimal":
                    decimal dCellValue = sl.GetCellValueAsDecimal(iRows, iCol);
                    pInfo.SetValue(model, dCellValue);
                    output = $"({iRows}, {iCol}) Value {dCellValue}";
                    break;
                case "Boolean":
                    bool bCellValue = sl.GetCellValueAsBoolean(iRows, iCol);
                    pInfo.SetValue(model, bCellValue);
                    output = $"({iRows}, {iCol}) Value {bCellValue}";
                    break;
                case "Int64":
                    long lCellValue = sl.GetCellValueAsInt64(iRows, iCol);
                    pInfo.SetValue(model, lCellValue);
                    output = $"({iRows}, {iCol}) Value {lCellValue}";
                    break;
                case "DateTime":
                    DateTime dtCellValue = sl.GetCellValueAsDateTime(iRows, iCol);
                    pInfo.SetValue(model, dtCellValue);
                    output = $"({iRows}, {iCol}) Value {dtCellValue}";
                    break;
                case "String":
                default:
                    string sCellValue = sl.GetCellValueAsString(iRows, iCol);
                    pInfo.SetValue(model, sCellValue);
                    output = $"({iRows}, {iCol}) Value {sCellValue}";
                    break;

            }

            Debug.WriteLine($"Property Name {pInfo.Name } - Property Type: {pInfo.PropertyType.Name}");

            Debug.WriteLine(output);
        }

    }
}
