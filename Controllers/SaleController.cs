//<copyright file ="SaleController.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/4/2021</date>

namespace POS_OJT.Controllers
{
    using POS_OJT.Models;
    using POS_OJT.Services;
    using POS_OJT.Utilities;
    using POS_OJT.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Web.Mvc;
    using static POS_OJT.Models.Sale;
    using Excel = Microsoft.Office.Interop.Excel;

    /// <summary>
    /// Defines the <see cref="SaleController" />.
    /// </summary>
    public class SaleController : Controller
    {
        /// <summary>
        /// Defines the saleService.
        /// </summary>
        private SaleService saleService = new SaleService();

        /// <summary>
        /// Defines the dtSale.
        /// </summary>
        private DataTable dtSale = new DataTable();

        /// <summary>
        /// Defines the sale.
        /// </summary>
        private Sale sale;

        // GET: SaleClasses
        /// <summary>
        /// The Index.
        /// </summary>
        /// <param name="invoiceNumber">The invoiceNumber<see cref="string"/>.</param>
        /// <param name="status">The status<see cref="string"/>.</param>
        /// <param name="fromDate">The fromDate<see cref="string"/>.</param>
        /// <param name="toDate">The toDate<see cref="string"/>.</param>
        /// <param name="shopName">The shopName<see cref="string"/>.</param>
        /// <param name="today">The today<see cref="string"/>.</param>
        /// <param name="weekly">The weekly<see cref="string"/>.</param>
        /// <param name="monthly">The monthly<see cref="string"/>.</param>
        /// <param name="dateSearch">The dateSearch<see cref="string"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Index(string invoiceNumber, string status, string fromDate, string toDate, string shopName, string today, string weekly, string monthly, string dateSearch)
        {
            //Get Shop Name List
            DataTable dtShop = saleService.GetShopList();
            List<Shop> shops = new List<Shop>();

            shops = (from DataRow datarow in dtShop.Rows
                     select new Shop()
                     {
                         id = Convert.ToInt32(datarow["id"]),
                         name = datarow["name"].ToString()
                     }).ToList();

            SelectList shopname = new SelectList(shops, "id", "name");
            ViewBag.shoplistname = shopname;

            // INVOICE STATUS LIST
            List<SelectListItem> statusList = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "Pending", Value = "1"
                },
                new SelectListItem
                {
                    Text = "Confirmed", Value = "2"
                },
                new SelectListItem
                {
                    Text = "Cancelled",Value="3"
                }
            };

            ViewBag.statusList = statusList;

            // SHOW LIST
            dtSale = saleService.GetSaleList();
            if (!String.IsNullOrEmpty(invoiceNumber) || !String.IsNullOrEmpty(status) || !String.IsNullOrEmpty(fromDate)
                || !String.IsNullOrEmpty(toDate) || !String.IsNullOrEmpty(shopName) || !String.IsNullOrEmpty(dateSearch))
            {
                if (dateSearch == "today")
                {
                    var dttodaySale = saleService.GetTodaySale();
                    List<SaleViewModel> gettodaySale = new List<SaleViewModel>();
                    List<SaleViewModel> todaySale = new List<SaleViewModel>();
                    gettodaySale = DataTableToList.ConvertToList<SaleViewModel>(dttodaySale);
                    todaySale = gettodaySale.Where(s => s.invoice_number == invoiceNumber || invoiceNumber == null
                        || Convert.ToString(s.invoice_status) == status || status == null
                        || Convert.ToString(s.shop_id) == shopName || shopName == null
                        || Convert.ToString(s.sale_date) == fromDate || fromDate == null
                        || Convert.ToString(s.sale_date) == toDate || toDate == null
                        || Convert.ToString(s.sale_date) == DateTime.Now.Date.ToString()
                        ).ToList();

                    ListToDataTable lsttodaysale = new ListToDataTable();
                    dttodaySale = lsttodaysale.ToDataTable(todaySale);
                    dtSale = dttodaySale;
                }
                else if (dateSearch == "weekly")
                {
                    DayOfWeek currentDay = DateTime.Now.DayOfWeek;
                    int daysTillCurrentDay = currentDay - DayOfWeek.Monday;
                    DateTime currentWeekStartDate = DateTime.Now.AddDays(-daysTillCurrentDay);
                    var dtweekSale = saleService.GetWeekSale();
                    List<SaleViewModel> getweekSale = new List<SaleViewModel>();
                    List<SaleViewModel> weekSale = new List<SaleViewModel>();
                    getweekSale = DataTableToList.ConvertToList<SaleViewModel>(dtweekSale);
                    weekSale = getweekSale.Where(s => s.invoice_number == invoiceNumber || invoiceNumber == null
                        || Convert.ToString(s.invoice_status) == status || status == null
                        || Convert.ToString(s.shop_id) == shopName
                        || shopName == null
                        || Convert.ToString(s.sale_date) == fromDate || fromDate == null || Convert.ToString(s.sale_date) == toDate || toDate == null
                        || Convert.ToString(s.sale_date) == DateTime.Now.Date.ToString()
                        || String.Compare(Convert.ToString(s.sale_date), currentWeekStartDate.ToString()) >= 0 && String.Compare(Convert.ToString(s.sale_date), DateTime.Now.Date.ToString()) <= 0).ToList();

                    ListToDataTable lsttodaysale = new ListToDataTable();
                    dtweekSale = lsttodaysale.ToDataTable(weekSale);
                    dtSale = dtweekSale;
                }
                else if (dateSearch == "monthly")
                {
                    DateTime dtFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    DateTime dtTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    var dtmonthSale = saleService.GetMonthSale();
                    List<SaleViewModel> getmonthSale = new List<SaleViewModel>();
                    List<SaleViewModel> monthSale = new List<SaleViewModel>();
                    getmonthSale = DataTableToList.ConvertToList<SaleViewModel>(dtmonthSale);
                    monthSale = getmonthSale.Where(s => s.invoice_number == invoiceNumber || invoiceNumber == null
                        || Convert.ToString(s.invoice_status) == status || status == null
                        || Convert.ToString(s.shop_id) == shopName
                        || shopName == null
                        || Convert.ToString(s.sale_date) == fromDate || fromDate == null || Convert.ToString(s.sale_date) == toDate || toDate == null
                        || Convert.ToString(s.sale_date) == DateTime.Now.Date.ToString()
                        || String.Compare(Convert.ToString(s.sale_date), dtFrom.ToString()) >= 0 && String.Compare(Convert.ToString(s.sale_date), dtTo.ToString()) <= 0).ToList();

                    ListToDataTable lsttodaysale = new ListToDataTable();
                    dtmonthSale = lsttodaysale.ToDataTable(monthSale);
                    dtSale = dtmonthSale;
                }
                else if (dateSearch == "yearly")
                {
                    MonthOfYear currentMonth = (MonthOfYear)DateTime.Now.Month;
                    int daysTillCurrentmonth = currentMonth - MonthOfYear.January;
                    DateTime currentMonthStartDate = DateTime.Now.AddMonths(-daysTillCurrentmonth);
                    var dtyearSale = saleService.GetYearSale();
                    List<SaleViewModel> getyearSale = new List<SaleViewModel>();
                    List<SaleViewModel> yearSale = new List<SaleViewModel>();
                    getyearSale = DataTableToList.ConvertToList<SaleViewModel>(dtyearSale);
                    yearSale = getyearSale.Where(s => s.invoice_number == invoiceNumber || invoiceNumber == null
                        || Convert.ToString(s.invoice_status) == status || status == null
                        || Convert.ToString(s.shop_id) == shopName
                        || shopName == null
                        || Convert.ToString(s.sale_date) == fromDate || fromDate == null || Convert.ToString(s.sale_date) == toDate || toDate == null
                        || Convert.ToString(s.sale_date) == DateTime.Now.Date.ToString()
                        || String.Compare(Convert.ToString(s.sale_date), currentMonthStartDate.ToString()) >= 0 && String.Compare(Convert.ToString(s.sale_date), DateTime.Now.Date.ToString()) <= 0).ToList();

                    ListToDataTable lsttodaysale = new ListToDataTable();
                    dtyearSale = lsttodaysale.ToDataTable(yearSale);
                    dtSale = dtyearSale;
                }
                else
                {
                    List<SaleViewModel> dtToList = new List<SaleViewModel>();
                    List<SaleViewModel> newList = new List<SaleViewModel>();
                    dtToList = DataTableToList.ConvertToList<SaleViewModel>(dtSale);

                    newList = dtToList.Where(s => s.invoice_number == invoiceNumber || invoiceNumber == null
                        || Convert.ToString(s.invoice_status) == status || status == null
                        || Convert.ToString(s.shop_id) == shopName
                        || shopName == null
                        || Convert.ToString(s.sale_date) == fromDate || fromDate == null || Convert.ToString(s.sale_date) == toDate || toDate == null).ToList();

                    ListToDataTable lsttodt = new ListToDataTable();
                    dtSale = lsttodt.ToDataTable(newList);
                }
            }
            else
            {
                dtSale = saleService.GetSaleList();
            }
            return View(dtSale);
        }

        // GET: SaleClasses/Edit/5
        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dtSale = saleService.GetEdit(id);
            return View(dtSale);
        }

        // POST: SaleClasses/Edit/5
        /// <summary>
        /// The EditPost.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <param name="collection">The collection<see cref="FormCollection"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id, FormCollection collection)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sale = new Sale();
            sale.id = (int)id;
            sale.invoice_status = 3;
            sale.reason = collection[2];
            sale.update_user_id = 1;
            sale.update_datetime = DateTime.Now;
            saleService.Update(sale);

            return RedirectToAction("Index");
        }

        // EXPORT TO EXCEL WITH DOWNLOAD BUTTON
        /// <summary>
        /// The Download.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Download()
        {
            dtSale = saleService.GetSaleList();

            List<SaleViewModel> saleListModel = new List<SaleViewModel>();
            saleListModel = DataTableToList.ConvertToList<SaleViewModel>(dtSale);
            ViewBag.staffListDL = saleListModel;

            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet worksheet = workbook.ActiveSheet;
            worksheet.Cells[1, 1] = "Date";
            worksheet.Cells[1, 2] = "Invoice Number";
            worksheet.Cells[1, 3] = "Shop Name";
            worksheet.Cells[1, 4] = "Terminal Name";
            worksheet.Cells[1, 5] = "Staff Name";
            worksheet.Cells[1, 6] = "Amount Tax";
            worksheet.Cells[1, 7] = "Amount";
            worksheet.Cells[1, 8] = "Total";
            worksheet.Cells[1, 9] = "Remark";

            int row = 2;
            foreach (var item in saleListModel)
            {
                worksheet.Cells[row, 1] = item.sale_date;
                worksheet.Cells[row, 2] = item.invoice_number;
                worksheet.Cells[row, 3] = item.shop_name;
                worksheet.Cells[row, 4] = item.terminal_name;
                worksheet.Cells[row, 5] = item.staff_name;
                worksheet.Cells[row, 6] = item.amount_tax;
                worksheet.Cells[row, 7] = item.amount;
                worksheet.Cells[row, 8] = item.paid_amount;
                worksheet.Cells[row, 9] = item.remark;
                row++;
            }
            workbook.SaveAs("d:\\demo4.xls");
            workbook.Close();
            Marshal.ReleaseComObject(workbook);

            application.Quit();
            Marshal.FinalReleaseComObject(application);
            ViewBag.Result = "Success";
            return RedirectToAction("Index");
        }

        /// <summary>
        /// The ExportExcel.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult ExportExcel(int id)
        {
            var sale = saleService.GetSaleList();
            DataTable dt = sale;
            List<SaleViewModel> saleListModel = new List<SaleViewModel>();
            saleListModel = DataTableToList.ConvertToList<SaleViewModel>(sale);
            //List
            var taku = saleListModel.Find(item => item.id == id);
            ViewBag.staffListDL = saleListModel;

            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet worksheet = workbook.ActiveSheet;
            worksheet.Cells[1, 1] = "Date";
            worksheet.Cells[1, 2] = "Invoice Number";
            worksheet.Cells[1, 3] = "Shop Name";
            worksheet.Cells[1, 4] = "Terminal Name";
            worksheet.Cells[1, 5] = "Staff Name";
            worksheet.Cells[1, 6] = "Amount Tax";
            worksheet.Cells[1, 7] = "Amount";
            worksheet.Cells[1, 8] = "Total";
            worksheet.Cells[1, 9] = "Remark";

            int row = 2;
            //foreach (var item in taku)
            //{
            worksheet.Cells[row, 1] = taku.sale_date;
            worksheet.Cells[row, 2] = taku.invoice_number;
            worksheet.Cells[row, 3] = taku.shop_name;
            worksheet.Cells[row, 4] = taku.terminal_name;
            worksheet.Cells[row, 5] = taku.staff_name;
            worksheet.Cells[row, 6] = taku.amount_tax;
            worksheet.Cells[row, 7] = taku.amount;
            worksheet.Cells[row, 8] = taku.paid_amount;
            worksheet.Cells[row, 9] = taku.remark;
            row++;
            //}
            workbook.SaveAs("d:\\onelinelist.xls");
            workbook.Close();
            Marshal.ReleaseComObject(workbook);

            application.Quit();
            Marshal.FinalReleaseComObject(application);
            ViewBag.Result = "Success";
            return RedirectToAction("Index");
        }

        /// <summary>
        /// The Reset.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Reset()
        {
            return RedirectToAction("Index");
        }
    }
}
