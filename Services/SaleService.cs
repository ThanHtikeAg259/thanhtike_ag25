//<copyright file ="SaleService.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/4/2021</date>

namespace POS_OJT.Services
{
    using POS_OJT.DAOs;
    using POS_OJT.Models;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="SaleService" />.
    /// </summary>
    public class SaleService
    {
        /// <summary>
        /// Defines the saleDAO.
        /// </summary>
        private SaleDAO saleDAO = new SaleDAO();

        /// <summary>
        /// The GetShopList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetShopList()
        {
            return saleDAO.GetShopName();
        }

        /// <summary>
        /// The GetStatusList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetStatusList()
        {
            return saleDAO.GetStatus();
        }

        /// <summary>
        /// The GetSaleList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSaleList()
        {
            return saleDAO.GetSale();
        }

        /// <summary>
        /// The GetEdit.
        /// </summary>
        /// <param name="sid">The sid<see cref="int"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetEdit(int sid)
        {
            return saleDAO.GetEdit(sid);
        }

        /// <summary>
        /// The GetProductInvoice.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetProductInvoice()
        {
            return saleDAO.GetProduct();
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="sale">The sale<see cref="Sale"/>.</param>
        public void Update(Sale sale)
        {
            saleDAO.Update(sale);
        }

        /// <summary>
        /// The GetTodaySale.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetTodaySale()
        {
            return saleDAO.GetTodaySale();
        }

        /// <summary>
        /// The GetWeekSale.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetWeekSale()
        {
            return saleDAO.GetWeekSale();
        }

        /// <summary>
        /// The GetMonthSale.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetMonthSale()
        {
            return saleDAO.GetMonthSale();
        }

        /// <summary>
        /// The GetYearSale.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetYearSale()
        {
            return saleDAO.GetYearSale();
        }
    }
}
