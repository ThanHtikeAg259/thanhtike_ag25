//<copyright file ="DashboardService.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/3/2021</date>

namespace POS_OJT.Services
{
    using POS_OJT.DAOs;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="DashboardService" />.
    /// </summary>
    public class DashboardService
    {
        /// <summary>
        /// Defines the dashboardDAO.
        /// </summary>
        private DashboardDAO dashboardDAO = new DashboardDAO();

        /// <summary>
        /// The GetTodaySale.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetTodaySale()
        {
            return dashboardDAO.GetTodaySale();
        }

        /// <summary>
        /// The GetMonthSale.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetMonthSale()
        {
            return dashboardDAO.GetMonthSale();
        }

        /// <summary>
        /// The GetYearSale.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetYearSale()
        {
            return dashboardDAO.GetYearSale();
        }

        /// <summary>
        /// The GetTotalSale.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetTotalSale()
        {
            return dashboardDAO.GetTotalSale();
        }

        /// <summary>
        /// The GetWeekSale.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetWeekSale()
        {
            return dashboardDAO.GetWeekSale();
        }
    }
}
