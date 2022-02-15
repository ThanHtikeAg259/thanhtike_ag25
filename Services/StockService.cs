//<copyright file ="StockService.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/4/2021</date>

namespace POS_OJT.Services
{
    using POS_OJT.DAOs;
    using POS_OJT.Models;
    using POS_OJT.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="StockService" />.
    /// </summary>
    public class StockService
    {
        /// <summary>
        /// Defines the stockDAO.
        /// </summary>
        private StockDAO stockDAO = new StockDAO();

        /// <summary>
        /// The GetWarehouseList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetWarehouseList()
        {
            return stockDAO.GetWarehouseName();
        }

        /// <summary>
        /// The GetShopList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetShopList()
        {
            return stockDAO.GetShopName();
        }

        /// <summary>
        /// The GetStockList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetStockList()
        {
            return stockDAO.GetStock();
        }

        /// <summary>
        /// The GetParentCategoryNameList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetParentCategoryNameList()
        {
            return stockDAO.GetParentCategoryName();
        }

        /// <summary>
        /// The GetProductNameList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetProductNameList()
        {
            return stockDAO.GetProductName();
        }

        /// <summary>
        /// The GetSubCategoryNameList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSubCategoryNameList()
        {
            return stockDAO.GetSubCategoryName();
        }

        /// <summary>
        /// The GetProductQuantityList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetProductQuantityList()
        {
            return stockDAO.GetProductQuantity();
        }

        /// <summary>
        /// The TransferOut.
        /// </summary>
        /// <param name="stock">The stock<see cref="Stock"/>.</param>
        public void TransferOut(Stock stock)
        {
            stockDAO.TransferOut(stock);
        }

        /// <summary>
        /// The RemainStock.
        /// </summary>
        /// <param name="stock">The stock<see cref="Stock"/>.</param>
        public void RemainStock(Stock stock)
        {
            int remainStock = Convert.ToInt32(stockDAO.RemainStock(stock));
            stockDAO.RemainStock(remainStock, stock);
            stockDAO.Update(stock);
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="stock">The stock<see cref="Stock"/>.</param>
        public void Delete(Stock stock)
        {
            stockDAO.Delete(stock);
        }

        /// <summary>
        /// The GetEdit.
        /// </summary>
        /// <returns>The <see cref="List{StockViewModel}"/>.</returns>
        public List<StockViewModel> GetEdit()
        {
            List<StockViewModel> stockList = new List<StockViewModel>();
            DataTable dtStockList = new DataTable();
            dtStockList = stockDAO.GetEdit();

            foreach (DataRow rows in dtStockList.Rows)
            {
                stockList.Add(new StockViewModel
                {
                    stock_id = Convert.ToInt32(rows[0]),
                    product_id = Convert.ToInt32(rows[1]),
                    product_name = Convert.ToString(rows[2]),
                    product_code = Convert.ToString(rows[3]),
                    shop_id = Convert.ToInt32(rows[4]),
                    shop_name = Convert.ToString(rows[5]),
                    warehouse_id = Convert.ToInt32(rows[6]),
                    warehouse_name = Convert.ToString(rows[7]),
                    stock_quantity = Convert.ToInt32(rows[8]),
                    stock_price = Convert.ToInt32(rows[9])
                });
            }
            return stockList;
        }

        /// <summary>
        /// The GetLessStock.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetLessStock()
        {
            return stockDAO.GetLessStock();
        }

        /// <summary>
        /// The GetStockASC.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetStockASC()
        {
            return stockDAO.GetStockASC();
        }
    }
}
