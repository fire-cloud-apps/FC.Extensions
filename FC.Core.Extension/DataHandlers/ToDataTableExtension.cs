using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace FC.Core.Extension.DataHandlers
{
	/// <summary>
	/// Convert Model List to DataTable Object
	/// </summary>
    public static class ToDataTableExtension
    {
		/// <summary>
		/// Convert List of Model into DataTable
		/// </summary>
		/// <typeparam name="T">Model Type</typeparam>
		/// <param name="items">List of Model</param>
		/// <example>
		/// <code lang="csharp">
		/// DataTable dtModel = iListModel.ToDataTable();
		/// </code>
		/// </example>
		/// <returns>Model list as DataTable</returns>
		public static DataTable ToDataTable<T>(this IList<T> items)
		{
			if(items == null)
            {
				throw new ArgumentException("parameter 'items' is null");
            }
			DataTable dataTable = new DataTable(typeof(T).Name);

			//Get all the properties
			PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			foreach (PropertyInfo prop in Props)
			{
				//Defining type of data column gives proper data table 
				var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
				//Setting column names as Property names
				dataTable.Columns.Add(prop.Name, type);
			}
			foreach (T item in items)
			{
				var values = new object[Props.Length];
				for (int i = 0; i < Props.Length; i++)
				{
					//inserting property values to datatable rows
					values[i] = Props[i].GetValue(item, null);
				}
				dataTable.Rows.Add(values);
			}
			//put a breakpoint here and check datatable
			return dataTable;
		}

	}
}
