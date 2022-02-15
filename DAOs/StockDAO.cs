//<copyright file ="StockDAO.cs"  company ="Seattle Consulting Myanmar">
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
    /// Defines the <see cref="StockDAO" />.
    /// </summary>
    public class StockDAO
    {
        /// <summary>
        /// Defines the strSql.
        /// </summary>
        private string strSql = String.Empty;

        /// <summary>
        /// Defines the connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        // STOCK LIST TABLE
        /// <summary>
        /// The GetStock.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetStock()
        {
            strSql = "SELECT DISTINCT t_stock.id as stock_id, m_product.name AS product_name, m_product.product_code AS product_code," +
                    "m_product.product_image_path AS product_image, " +
                    "m_shop.name AS shop_name, m_warehouse.name AS warehouse_name, t_stock.quantity AS stock_quantity, " +
                    "t_stock.price AS stock_price, m_shop.id AS shop_id, m_warehouse.id AS warehouse_id " +
                    "FROM t_stock " +
                    "INNER JOIN m_product ON m_product.id = t_stock.product_id " +
                    "INNER JOIN m_shop ON m_shop.id = t_stock.shop_id " +
                    "INNER JOIN m_warehouse ON m_warehouse.id = t_stock.warehouse_id; ";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // PARENT CATEGORY NAME
        /// <summary>
        /// The GetParentCategoryName.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetParentCategoryName()
        {
            strSql = "SELECT DISTINCT id, name FROM m_category WHERE parent_category_id IS NULL;";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // SUBCATEGORY NAME
        /// <summary>
        /// The GetSubCategoryName.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSubCategoryName()
        {
            strSql = "SELECT DISTINCT id, name FROM m_category WHERE parent_category_id IS NOT NULL;";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // PRODUCT NAME
        /// <summary>
        /// The GetProductName.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetProductName()
        {
            strSql = "SELECT DISTINCT m_product.id, m_product.name " +
                    "FROM m_product " +
                    "INNER JOIN m_category ON m_product.product_type_id = m_category.id " +
                    "WHERE is_deleted = 0; ";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        //PRODUCT NAME, SHOP LIST, WAREHOUSE LIST
        /// <summary>
        /// The GetProductQuantity.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetProductQuantity()
        {
            strSql = "SELECT DISTINCT t_stock.id as stock_id,m_product.name AS product_name, m_shop.name AS shop_name," +
                    "m_warehouse.name AS warehoue_name, t_stock.quantity AS stock_quantity, m_product.minimum_quantity AS minimum_quantity," +
                    "m_product.sale_price AS sale_price, t_stock.remark As stock_remark " +
                    "FROM t_stock " +
                    "INNER JOIN m_product ON m_product.id = t_stock.product_id " +
                    "INNER JOIN m_shop ON m_shop.id = t_stock.shop_id " +
                    "INNER JOIN m_warehouse ON m_warehouse.id = t_stock.warehouse_id " +
                    "WHERE t_stock.is_deleted = 0 ;";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // WAREHOUSE NAME LIST
        /// <summary>
        /// The GetWarehouseName.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetWarehouseName()
        {
            strSql = "SELECT id,name FROM m_warehouse WHERE is_deleted = 0;";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // SHOP NAME LIST
        /// <summary>
        /// The GetShopName.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetShopName()
        {
            strSql = "SELECT id, name FROM m_shop WHERE is_deleted = 0;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // GET STOCK LIST BY LESS STOCK
        /// <summary>
        /// The GetLessStock.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetLessStock()
        {
            strSql = "SELECT DISTINCT t_stock.id as stock_id, m_product.name AS product_name, " +
                    "m_product.product_code AS product_code, " +
                    "m_product.product_image_path AS product_image, m_shop.name AS shop_name," +
                    " m_warehouse.name AS warehouse_name, t_stock.quantity AS stock_quantity, " +
                    "t_stock.price AS stock_price " +
                    "FROM t_stock " +
                    "INNER JOIN m_product ON m_product.id = t_stock.product_id " +
                    "INNER JOIN m_shop ON m_shop.id = t_stock.shop_id " +
                    "INNER JOIN m_warehouse ON m_warehouse.id = t_stock.warehouse_id " +
                    "INNER JOIN t_warehouse_shop_product ON t_warehouse_shop_product.warehouse_id = t_stock.warehouse_id " +
                    "AND t_stock.quantity <= t_warehouse_shop_product.minimum_quantity; ";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // GET STOCK LIST BY QUANTITY ASC
        /// <summary>
        /// The GetStockASC.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetStockASC()
        {
            strSql = "SELECT DISTINCT t_stock.id as stock_id, m_product.name AS product_name, " +
                "m_product.product_code AS product_code, " +
                "m_product.product_image_path AS product_image, m_shop.name AS shop_name," +
                " m_warehouse.name AS warehouse_name, t_stock.quantity AS stock_quantity, " +
                "t_stock.price AS stock_price " +
                "FROM t_stock " +
                "INNER JOIN m_product ON m_product.id = t_stock.product_id " +
                "INNER JOIN m_shop ON m_shop.id = t_stock.shop_id " +
                "INNER JOIN m_warehouse ON m_warehouse.id = t_stock.warehouse_id " +
                "INNER JOIN t_warehouse_shop_product ON t_warehouse_shop_product.warehouse_id = t_stock.warehouse_id " +
                "ORDER BY t_stock.quantity ASC; ";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // TO GET EDIT/ID
        /// <summary>
        /// The GetEdit.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetEdit()
        {
            strSql = "SELECT DISTINCT t_stock.id as stock_id, m_product.id AS product_id, m_product.name AS product_name, " +
                    "m_product.product_code AS product_code," +
                    "m_shop.id AS shop_id, m_shop.name AS shop_name, m_warehouse.id AS warehouse_id, m_warehouse.name AS warehouse_name,t_stock.quantity AS stock_quantity, " +
                    "t_stock.price AS stock_price" +
                    " FROM t_stock " +
                    "INNER JOIN m_product ON m_product.id = t_stock.product_id " +
                    "INNER JOIN m_shop ON m_shop.id = t_stock.shop_id " +
                    "INNER JOIN m_warehouse ON m_warehouse.id = t_stock.warehouse_id; ";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // UPDATE T_STOCK
        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="stock">The stock<see cref="Stock"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int Update(Stock stock)
        {
            strSql = "UPDATE t_stock SET inout_flg=@inout_flg" +
                    "quantity = quantity- @quantity WHERE quantity >= @quantity and id = @id RETURNING quantity;";

            NpgsqlParameter[] npgsqlParameters =
            {
                new NpgsqlParameter("@id",stock.id),
                new NpgsqlParameter("@inout_flg",1),
                new NpgsqlParameter("@quantity",stock.quantity),
            };

            int returnID = Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, npgsqlParameters));
            return returnID;
        }

        // INSERT INTO T_STOCK IN
        /// <summary>
        /// The TransferOut.
        /// </summary>
        /// <param name="stock">The stock<see cref="Stock"/>.</param>
        public void TransferOut(Stock stock)
        {
            strSql = "INSERT INTO public.t_stock(warehouse_id, shop_id, " +
                    "product_id, quantity, inout_flg, source_location_id, price, " +
                    "remark, is_deleted, create_user_id, update_user_id, " +
                    "create_datetime, update_datetime) " +
                    "VALUES(@warehouse_id, @shop_id, @product_id," +
                    "@quantity, @inout_flg, @source_location_id, @price, " +
                    "@remark, @is_deleted, @create_user_id, @update_user_id, @create_datetime, @update_datetime); ";

            NpgsqlParameter[] npgsqlParameters =
            {
                //new NpgsqlParameter("@id",stock.id),
                new NpgsqlParameter("@warehouse_id", stock.warehouse_id),
                new NpgsqlParameter("@shop_id", stock.shop_id),
                new NpgsqlParameter("@product_id", stock.product_id),
                new NpgsqlParameter("@quantity", stock.quantity),
                new NpgsqlParameter("@inout_flg", 1),
                new NpgsqlParameter("@source_location_id", stock.source_location_id),
                new NpgsqlParameter("@price", stock.price),
                new NpgsqlParameter("@remark", stock.remark),
                new NpgsqlParameter("@is_deleted", stock.is_deleted),
                new NpgsqlParameter("@create_user_id", stock.create_user_id),
                new NpgsqlParameter("@update_user_id", stock.update_user_id),
                new NpgsqlParameter("@create_datetime", stock.create_datetime),
                new NpgsqlParameter("@update_datetime", stock.update_datetime)
            };
            connection.ExecuteScalar(CommandType.Text, strSql, npgsqlParameters);
        }

        // INSERT INTO T_STOCK IN
        /// <summary>
        /// The RemainStock.
        /// </summary>
        /// <param name="qty">The qty<see cref="int"/>.</param>
        /// <param name="stock">The stock<see cref="Stock"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int RemainStock(int qty, Stock stock)
        {
            strSql = "INSERT INTO public.t_stock(warehouse_id, shop_id, " +
                    "product_id, quantity, inout_flg, source_location_id, price, " +
                    "remark, is_deleted, create_user_id, update_user_id, " +
                    "create_datetime, update_datetime) " +
                    "VALUES(@warehouse_id, @shop_id, @product_id," +
                    "@quantity, @inout_flg, @source_location_id, @price, " +
                    "@remark, @is_deleted, @create_user_id, @update_user_id,@create_datetime, @update_datetime) RETURNING quantity; ";

            NpgsqlParameter[] npgsqlParameters =
            {
                new NpgsqlParameter("@warehouse_id", stock.warehouse_id),
                new NpgsqlParameter("@shop_id", stock.shop_id),
                new NpgsqlParameter("@product_id", stock.product_id),
                new NpgsqlParameter("@quantity", stock.quantity),
                new NpgsqlParameter("@inout_flg", 1),
                new NpgsqlParameter("@source_location_id", stock.source_location_id),
                new NpgsqlParameter("@price", stock.price),
                new NpgsqlParameter("@remark", stock.remark),
                new NpgsqlParameter("@is_deleted", stock.is_deleted),
                new NpgsqlParameter("@create_user_id", stock.create_user_id),
                new NpgsqlParameter("@update_user_id", stock.update_user_id),
                new NpgsqlParameter("@create_datetime", stock.create_datetime),
                new NpgsqlParameter("@update_datetime", stock.update_datetime)
            };

            int returnID = Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, npgsqlParameters));
            return returnID;
        }

        /// <summary>
        /// The RemainStock.
        /// </summary>
        /// <param name="stock">The stock<see cref="Stock"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int RemainStock(Stock stock)
        {
            strSql = "INSERT INTO public.t_stock(warehouse_id, shop_id, " +
                    "product_id, quantity, inout_flg, source_location_id, price, " +
                    "remark, is_deleted, create_user_id, update_user_id, " +
                    "create_datetime, update_datetime) " +
                    "VALUES(@warehouse_id, @shop_id, @product_id," +
                    "@quantity, @inout_flg, @source_location_id, @price, " +
                    "@remark, @is_deleted, @create_user_id, @update_user_id, @create_datetime, @update_datetime); ";

            NpgsqlParameter[] npgsqlParameters =
            {
                //new NpgsqlParameter("@id",stock.id),
                new NpgsqlParameter("@warehouse_id", stock.warehouse_id),
                new NpgsqlParameter("@shop_id", stock.shop_id),
                new NpgsqlParameter("@product_id", stock.product_id),
                new NpgsqlParameter("@quantity", stock.quantity),
                new NpgsqlParameter("@inout_flg", 2),
                new NpgsqlParameter("@source_location_id", stock.source_location_id),
                new NpgsqlParameter("@price", stock.price),
                new NpgsqlParameter("@remark", stock.remark),
                new NpgsqlParameter("@is_deleted", stock.is_deleted),
                new NpgsqlParameter("@create_user_id", stock.create_user_id),
                new NpgsqlParameter("@update_user_id", stock.update_user_id),
                new NpgsqlParameter("@create_datetime", stock.create_datetime),
                new NpgsqlParameter("@update_datetime", stock.update_datetime)
            };

            int returnID = Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, npgsqlParameters));

            return returnID;
        }

        // UPDATE T_WAREHOUSE_SHOP_PRODUCT
        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="warehouseShopProduct">The warehouseShopProduct<see cref="WarehouseShopProduct"/>.</param>
        /// <param name="product_id">The product_id<see cref="int"/>.</param>
        /// <param name="quantity">The quantity<see cref="int?"/>.</param>
        public void Update(WarehouseShopProduct warehouseShopProduct, int product_id, int? quantity)
        {
            strSql = "UPDATE t_warehouse_shop_product SET " +
                    "quantity = quantity + " + quantity + " WHERE product_id = " + product_id + ";";

            connection.ExecuteNonQuery(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The GetProductID.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetProductID(int id)
        {
            strSql = "SELECT product_id from t_stock where id = " + id + ";";

            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        // SET IS_DELETED = 1
        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="stock">The stock<see cref="Stock"/>.</param>
        public void Delete(Stock stock)
        {
            strSql = "UPDATE public.t_stock SET is_deleted = @is_deleted WHERE id = @id;";

            NpgsqlParameter[] npgsqlParameters =
            {
                new NpgsqlParameter("@id", stock.id),
                new NpgsqlParameter("@is_deleted", stock.is_deleted)
            };
            connection.ExecuteNonQuery(CommandType.Text, strSql, npgsqlParameters);
        }
    }
}
