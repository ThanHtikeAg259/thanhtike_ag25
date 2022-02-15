//<copyright file ="SaleDAO.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/4/2021</date>

namespace POS_OJT.DAOs
{
    using Npgsql;
    using POS_OJT.Config;
    using POS_OJT.Models;
    using System;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="SaleDAO" />.
    /// </summary>
    public class SaleDAO
    {
        /// <summary>
        /// Defines the strSql.
        /// </summary>
        private string strSql = String.Empty;

        /// <summary>
        /// Defines the connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        // GET SHOP NAME
        /// <summary>
        /// The GetShopName.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetShopName()
        {
            strSql = "SELECT id, name FROM m_shop WHERE is_deleted = 0;";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // GET STATUS
        /// <summary>
        /// The GetStatus.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetStatus()
        {
            strSql = "SELECT id, invoice_status FROM t_sale;";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // GET SALE LIST
        /// <summary>
        /// The GetSale.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSale()
        {
            strSql = "SELECT distinct t_sale.id,t_sale.sale_date, t_sale.invoice_number, m_shop.name AS shop_name," +
                     "m_terminal.name AS terminal_name, m_staff.name AS staff_name, t_sale.amount_tax, t_sale.amount," +
                     "t_sale.paid_amount,t_sale.remark AS reason, t_sale.invoice_status " +
                     "FROM t_sale JOIN m_shop ON m_shop.id = t_sale.shop_id " +
                     "JOIN m_terminal ON t_sale.terminal_id = m_terminal.id " +
                     "Left JOIN m_staff ON  m_staff.id = t_sale.create_user_id;";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // GET SALE EDIT WITH DATATABLE
        /// <summary>
        /// The GetEdit.
        /// </summary>
        /// <param name="sid">The sid<see cref="int"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetEdit(int sid)
        {
            strSql = "SELECT distinct t_sale.id AS sid, t_sale.sale_date, t_sale.invoice_number,m_shop.name AS shop_name, " +
                     "m_terminal.name AS terminal_name, m_staff.name AS staff_name, t_sale.amount_tax, t_sale.amount, t_sale.paid_amount, t_sale.remark, " +
                     "m_product.name AS product_name, t_sale_details.price, t_sale_details.quantity, t_sale_details.remark " +
                     "FROM t_sale " +
                     "JOIN t_sale_details ON t_sale.id = t_sale_details.sale_id " +
                     "Left JOIN m_shop ON  m_shop.id = t_sale.shop_id " +
                     "JOIN m_terminal ON t_sale.terminal_id = m_terminal.id Left JOIN m_staff ON  m_staff.id = t_sale.create_user_id " +
                     "JOIN m_product on t_sale_details.product_id = m_product.id AND t_sale.id = t_sale_details.sale_id " +
                     "WHERE t_sale.id =" + sid + "OR 0 = " + sid + ";";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // GET PRODUCT LIST
        /// <summary>
        /// The GetProduct.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetProduct()
        {
            strSql = "SELECT DISTINCT t_stock.id as stock_id, m_product.name AS product_name, " +
                     "t_stock.price AS stock_price, t_stock.quantity AS stock_quantity, " +
                     "t_stock.remark AS stock_remark " +
                     "FROM t_stock " +
                     "JOIN m_product ON m_product.id = t_stock.product_id " +
                     "JOIN m_shop ON m_shop.id = t_stock.shop_id;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // UPDATE SALE WITH CANCLE INVOICE
        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="sale">The sale<see cref="Sale"/>.</param>
        public void Update(Sale sale)
        {
            strSql = "UPDATE public.t_sale SET invoice_status = @invoice_status, reason = @reason, update_datetime = @update_datetime WHERE id = @id;";

            NpgsqlParameter[] npgsqlParameter =
            {
                new NpgsqlParameter("@id",sale.id),
                new NpgsqlParameter("@invoice_status",sale.invoice_status),
                new NpgsqlParameter("@reason",sale.reason),
                new NpgsqlParameter("@update_datetime",sale.update_datetime)
            };
            connection.ExecuteNonQuery(CommandType.Text, strSql, npgsqlParameter);
        }

        // GET SALE LIST WITH TODAY'S DATE
        /// <summary>
        /// The GetTodaySale.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetTodaySale()
        {
            strSql = "SELECT distinct t_sale.id, t_sale.sale_date, t_sale.invoice_number, m_shop.name AS shop_name," +
                    "m_terminal.name AS terminal_name, m_staff.name AS staff_name, t_sale.amount_tax, t_sale.amount," +
                    "t_sale.paid_amount,t_sale.remark AS reason, t_sale.invoice_status " +
                    "FROM t_sale " +
                    "INNER JOIN m_shop ON m_shop.id = t_sale.shop_id " +
                    "INNER JOIN m_terminal ON t_sale.terminal_id = m_terminal.id " +
                    "Left JOIN m_staff ON  m_staff.id = t_sale.create_user_id WHERE t_sale.sale_date > current_timestamp - interval '1 day';";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // GET SALE LIST WITH WEEKLY'S DATE
        /// <summary>
        /// The GetWeekSale.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetWeekSale()
        {
            strSql = "SELECT distinct t_sale.id, t_sale.sale_date, t_sale.invoice_number, m_shop.name AS shop_name," +
                    "m_terminal.name AS terminal_name, m_staff.name AS staff_name, t_sale.amount_tax, t_sale.amount," +
                    "t_sale.paid_amount,t_sale.remark AS reason, t_sale.invoice_status " +
                    "FROM t_sale " +
                    "INNER JOIN m_shop ON m_shop.id = t_sale.shop_id " +
                    "INNER JOIN m_terminal ON t_sale.terminal_id = m_terminal.id " +
                    "Left JOIN m_staff ON  m_staff.id = t_sale.create_user_id " +
                    "WHERE t_sale.sale_date > current_timestamp - interval '7 days';";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // GET SALE LIST WITH MONTHLY'S DATE
        /// <summary>
        /// The GetMonthSale.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetMonthSale()
        {
            strSql = "SELECT distinct t_sale.id, t_sale.sale_date, t_sale.invoice_number, m_shop.name AS shop_name," +
                    "m_terminal.name AS terminal_name, m_staff.name AS staff_name, t_sale.amount_tax, t_sale.amount," +
                    "t_sale.paid_amount,t_sale.remark AS reason, t_sale.invoice_status " +
                    "FROM t_sale " +
                    "INNER JOIN m_shop ON m_shop.id = t_sale.shop_id " +
                    "INNER JOIN m_terminal ON t_sale.terminal_id = m_terminal.id " +
                    "Left JOIN m_staff ON  m_staff.id = t_sale.create_user_id " +
                    "WHERE t_sale.sale_date > current_timestamp - interval '30 days';";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // GET SALE LIST WITH YEARLY'S DATE
        /// <summary>
        /// The GetYearSale.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetYearSale()
        {
            strSql = "SELECT distinct t_sale.id, t_sale.sale_date, t_sale.invoice_number, m_shop.name AS shop_name," +
                    "m_terminal.name AS terminal_name, m_staff.name AS staff_name, t_sale.amount_tax, t_sale.amount," +
                    "t_sale.paid_amount, t_sale.remark AS reason, t_sale.invoice_status " +
                    "FROM t_sale " +
                    "INNER JOIN m_shop ON m_shop.id = t_sale.shop_id " +
                    "INNER JOIN m_terminal ON t_sale.terminal_id = m_terminal.id " +
                    "Left JOIN m_staff ON  m_staff.id = t_sale.create_user_id " +
                    "WHERE t_sale.sale_date > current_timestamp - interval '365 days';";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }
    }
}
