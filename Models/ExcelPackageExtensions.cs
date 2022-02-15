//<copyright file ="ExcelPackageExtensions.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/4/2021</date>

namespace POS_OJT.Models
{
    using OfficeOpenXml;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="ExcelPackageExtensions" />.
    /// </summary>
    public static class ExcelPackageExtensions
    {
        /// <summary>
        /// The ToDataTable.
        /// </summary>
        /// <param name="package">The package<see cref="ExcelPackage"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public static DataTable ToDataTable(this ExcelPackage package)
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.First();
            DataTable dt = new DataTable();
            foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                dt.Columns.Add(firstRowCell.Text);
            }
            for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
            {
                var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                var newRow = dt.NewRow();
                foreach (var cell in row)
                {
                    newRow[cell.Start.Column - 1] = cell.Text;
                }
                dt.Rows.Add(newRow);
            }

            return dt;
        }
    }
}
