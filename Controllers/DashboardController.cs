//<copyright file ="DashboardController.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/3/2021</date>

namespace POS_OJT.Controllers
{
    using POS_OJT.Models;
    using POS_OJT.Services;
    using POS_OJT.Utilities;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="DashboardController" />.
    /// </summary>
    public class DashboardController : Controller
    {
        /// <summary>
        /// Defines the dashboardService.
        /// </summary>
        private DashboardService dashboardService = new DashboardService();

        /// <summary>
        /// The Index.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Index()
        {
            DataTable todaySale = dashboardService.GetTodaySale();
            List<Dashboard> todays = new List<Dashboard>();
            todays = DataTableToList.ConvertToList<Dashboard>(todaySale);
            ViewBag.todaySale = todays;

            DataTable monthSale = dashboardService.GetMonthSale();
            List<Dashboard> months = new List<Dashboard>();
            months = DataTableToList.ConvertToList<Dashboard>(monthSale);
            ViewBag.monthSale = months;

            DataTable yearSale = dashboardService.GetYearSale();
            List<Dashboard> years = new List<Dashboard>();
            years = DataTableToList.ConvertToList<Dashboard>(yearSale);
            ViewBag.yearSale = years;

            DataTable totalSale = dashboardService.GetTotalSale();
            List<Dashboard> totals = new List<Dashboard>();
            totals = DataTableToList.ConvertToList<Dashboard>(totalSale);
            ViewBag.totalSale = totals;

            DataTable weeksSale = dashboardService.GetWeekSale();
            List<Dashboard> weeks = new List<Dashboard>();
            weeks = DataTableToList.ConvertToList<Dashboard>(weeksSale);
            ViewBag.weekSale = weeks;

            return View();
        }

        /// <summary>
        /// The makechart.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult MakeChart()
        {
            return View();
        }
    }
}
