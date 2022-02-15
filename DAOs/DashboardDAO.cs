//<copyright file ="DashboardDAO.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/3/2021</date>

namespace POS_OJT.DAOs
{
    using POS_OJT.Config;
    using System;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="DashboardDAO" />.
    /// </summary>
    public class DashboardDAO
    {
        /// <summary>
        /// Defines the strSql.
        /// </summary>
        private string strSql = String.Empty;

        /// <summary>
        /// Defines the connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        // DASHBOARD
        // TODAY'S SALE AMOUNT
        /// <summary>
        /// The GetTodaySale.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetTodaySale()
        {
            strSql = "SELECT sum(amount) AS todaySale FROM t_sale " +
                    "WHERE create_datetime > current_timestamp - interval '1 day';";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // MONTH'S SALE AMOUNT
        /// <summary>
        /// The GetMonthSale.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetMonthSale()
        {
            strSql = "SELECT sum(amount) AS monthSale FROM t_sale " +
                    "WHERE create_datetime > current_timestamp - interval '30 days';";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // YEAR'S SALE AMOUNT
        /// <summary>
        /// The GetYearSale.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetYearSale()
        {
            strSql = "SELECT sum(amount) AS yearSale FROM t_sale " +
                     "WHERE create_datetime > current_timestamp - interval '365 days';";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // TOTALS SALE AMOUNT
        /// <summary>
        /// The GetTotalSale.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetTotalSale()
        {
            strSql = "SELECT sum(amount) AS totalSale FROM t_sale " +
                    "WHERE create_datetime > current_timestamp - interval '365 days';";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // WEEKLY SALE AMOUNT
        /// <summary>
        /// The GetWeekSale.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetWeekSale()
        {
            strSql = "SELECT sum(amount) AS weekSale FROM t_sale " +
                    "WHERE create_datetime > current_timestamp - interval '7 days';";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }
    }
}
