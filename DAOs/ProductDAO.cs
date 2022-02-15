//<copyright file ="ProductDAO.cs"  company ="Seattle Consulting Myanmar">
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
    using System.Collections;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="ProductDAO" />.
    /// </summary>
    public class ProductDAO
    {
        /// <summary>
        /// Defines the strSql.
        /// </summary>
        private string strSql = String.Empty;

        /// <summary>
        /// Defines the connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="product">The product<see cref="Product"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int Insert(Product product)
        {
            strSql = "INSERT INTO public.m_product(product_type_id, product_code,barcode,name,short_name,sale_price,description,product_image_path," +
                     "mfd_date,expire_date,minimum_quantity, product_status, create_user_id, update_user_id, create_datetime, update_datetime, company_id) " +
                     "VALUES(@product_type_id, @product_code, @barcode, @name, @short_name, @sale_price, @description, @product_image_path," +
                     "@mfd_date, @expire_date, @minimum_quantity, @product_status, @create_user_id, @update_user_id, @create_datetime, @update_datetime, @company_id) " +
                     "RETURNING id";

            NpgsqlParameter[] npgSqlParams = {
                new NpgsqlParameter("@product_type_id", product.product_type_id),
                new NpgsqlParameter("@product_code", product.product_code),
                new NpgsqlParameter("@barcode", product.barcode),
                new NpgsqlParameter("@name", product.name),
                new NpgsqlParameter("@short_name", product.short_name),
                new NpgsqlParameter("@sale_price", product.sale_price),
                new NpgsqlParameter("@description", product.description),
                new NpgsqlParameter("@product_image_path", product.product_image_path),
                new NpgsqlParameter("@mfd_date", product.mfd_date),
                new NpgsqlParameter("@expire_date", product.expire_date),
                new NpgsqlParameter("@minimum_quantity", product.minimum_quantity),
                new NpgsqlParameter("@product_status", product.product_status),
                new NpgsqlParameter ("@create_user_id", product.create_user_id),
                new NpgsqlParameter ("@update_user_id", product.update_user_id),
                new NpgsqlParameter ("@create_datetime",product.create_datetime),
                new NpgsqlParameter ("@update_datetime", product.update_datetime),
                new NpgsqlParameter ("@company_id", 1)
            };

            int returnID = Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, npgSqlParams));

            return returnID;
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="shopProduct">The shopProduct<see cref="ShopProduct"/>.</param>
        /// <param name="id">The id<see cref="int?"/>.</param>
        public void Insert(ShopProduct shopProduct, int? id)
        {
            strSql = "INSERT INTO public.m_shop_product(product_id, shop_id," +
                     "create_user_id, update_user_id, create_datetime, update_datetime) " +
                     "VALUES(@id, @shop_id, @create_user_id, @update_user_id, @create_datetime, @update_datetime)";

            NpgsqlParameter[] npgSqlParams = {
                new NpgsqlParameter("@id", id),
                new NpgsqlParameter("@shop_id", shopProduct.shop_id),
                new NpgsqlParameter ("@create_user_id", shopProduct.create_user_id),
                new NpgsqlParameter ("@update_user_id", shopProduct.update_user_id),
                new NpgsqlParameter ("@create_datetime", shopProduct.create_datetime),
                new NpgsqlParameter ("@update_datetime", shopProduct.update_datetime)
            };

            connection.ExecuteNonQuery(CommandType.Text, strSql, npgSqlParams);
        }

        /// <summary>
        /// The GetCateList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetCateList()
        {
            strSql = "SELECT id, name from m_category";
            var result = connection.ExecuteDataTable(CommandType.Text, strSql);
            return result;
        }

        /// <summary>
        /// The GetShopList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetShopList()
        {
            strSql = "SELECT id,name from m_shop where company_id = 1";
            var result = connection.ExecuteDataTable(CommandType.Text, strSql);
            return result;
        }

        /// <summary>
        /// The GetSelectShopList.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSelectShopList(int? id)
        {
            strSql = "SELECT shop_id from m_shop_product where product_id = " + id;
            var result = connection.ExecuteDataTable(CommandType.Text, strSql);
            return result;
        }

        /// <summary>
        /// The GetShopProduct.
        /// </summary>
        /// <param name="pid">The pid<see cref="int"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetShopProduct(int pid)
        {
            strSql = "SELECT id from m_shop_product where product_id = " + pid;
            var result = connection.ExecuteDataTable(CommandType.Text, strSql);
            return result;
        }

        /// <summary>
        /// The GetProductCode.
        /// </summary>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetProductCode()
        {
            strSql = "SELECT product_code FROM m_product ORDER BY product_code DESC;";

            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The GetLastestProductCode.
        /// </summary>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetLastestProductCode()
        {
            strSql = "SELECT product_code FROM m_product ORDER BY id DESC LIMIT 1;";
            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The GetProduct.
        /// </summary>
        /// <param name="pid">The pid<see cref="int?"/>.</param>
        /// <param name="searchName">The searchName<see cref="string"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetProduct(int? pid, string searchName)
        {
            strSql = "select c.id, p.id as pid, p.product_type_id, p.product_code, p.name, p.short_name, p.sale_price, p.product_image_path, p.minimum_quantity, p.mfd_date, p.expire_date, p.description, c.name AS product_category from m_category c " +
                     "inner join m_product p on p.product_type_id = c.id where product_status = 1 and (p.id = " + pid + " OR 0 = " + pid + ") AND p.name like '%" + searchName + "%' ORDER BY p.id ASC;";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The ShowProduct.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable ShowProduct(int? id)
        {
            strSql = "select name from m_category where m_category.id= " + id + ";";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The GetCategory.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetCategory()
        {
            strSql = "SELECT name from m_category;";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The JustCategory.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable JustCategory()
        {
            strSql = "SELECT id, parent_category_id, name from m_category WHERE is_deleted = 0;";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The GetParentCategoryID.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetParentCategoryID(int? id)
        {
            strSql = "SELECT parent_category_id FROM m_category where id=" + id + ";";

            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="product">The product<see cref="Product"/>.</param>
        public void Update(Product product)
        {
            strSql = "UPDATE public.m_product SET id = @id,name = @name, short_name = @short_name,sale_price = @sale_price, product_image_path = @product_image_path," +
                     "minimum_quantity = @minimum_quantity,mfd_date = @mfd_date, expire_date = @expire_date, description = @description,update_datetime = @update_datetime WHERE id = @id;";

            NpgsqlParameter[] npgsqlParameter =
            {
                new NpgsqlParameter("@id", product.id),
                new NpgsqlParameter("@name", product.name),
                new NpgsqlParameter("@short_name", product.short_name),
                new NpgsqlParameter("@sale_price", product.sale_price),
                new NpgsqlParameter("@product_image_path", product.product_image_path),
                new NpgsqlParameter("@minimum_quantity", product.minimum_quantity),
                new NpgsqlParameter("@mfd_date", product.mfd_date),
                new NpgsqlParameter("@expire_date", product.expire_date),
                new NpgsqlParameter("@description", product.description),
                new NpgsqlParameter("@update_datetime", product.update_datetime)
            };
            connection.ExecuteNonQuery(CommandType.Text, strSql, npgsqlParameter);
        }

        /// <summary>
        /// The UpdateShopProduct.
        /// </summary>
        /// <param name="arrayval">The arrayval<see cref="ArrayList"/>.</param>
        /// <param name="id">The id<see cref="int?"/>.</param>
        public void UpdateShopProduct(ArrayList arrayval, int? id)
        {
            strSql = "UPDATE public.m_shop_product SET update_datetime = @update_datetime, update_user_id = @update_user_id  WHERE product_id = " + id + " AND shop_id in ( " + arrayval + ");";

            NpgsqlParameter[] npgsqlParameter =
            {
                new NpgsqlParameter("@update_user_id", 1),
                new NpgsqlParameter("@update_datetime", DateTime.Now)
            };
            connection.ExecuteNonQuery(CommandType.Text, strSql, npgsqlParameter);
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="product">The product<see cref="Product"/>.</param>
        public void Delete(Product product)
        {
            strSql = "UPDATE public.m_product SET product_status = 3 WHERE id = @id;";

            NpgsqlParameter[] npgsqlParameters =
            {
                new NpgsqlParameter("@id",product.id),
                new NpgsqlParameter("@product_status",product.product_status)
            };
            connection.ExecuteNonQuery(CommandType.Text, strSql, npgsqlParameters);
        }
    }
}
