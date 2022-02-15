//<copyright file ="ListToDataTable.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/4/2021</date>

namespace POS_OJT.Utilities
{
    using System.Collections.Generic;
    using System.Data;
    using System.Reflection;

    /// <summary>
    /// Defines the <see cref="ListToDataTable" />.
    /// </summary>
    public class ListToDataTable
    {
        /// <summary>
        /// The ToDataTable.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="items">The items<see cref="List{T}"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
