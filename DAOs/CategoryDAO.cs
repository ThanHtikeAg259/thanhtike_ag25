//<copyright file ="CategoryDAO.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/3/2021</date>

namespace POS_OJT.DAOs
{
    using Npgsql;
    using POS_OJT.Config;
    using POS_OJT.Models;
    using System;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="CategoryDAO" />.
    /// </summary>
    public class CategoryDAO
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
        /// The GetCategory.
        /// </summary>
        /// <param name="pid">The pid<see cref="int?"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetCategory(int? pid)
        {
            strSql = "SELECT m_category.id, m_category.name, m_category.description, c.name AS parent_category " +
                     "FROM public.m_category " +
                     "LEFT JOIN m_category c " +
                     "ON (c.id = m_category.parent_category_id) " +
                     "WHERE m_category.is_deleted = 0 " +
                     "AND (m_category.id = " + pid +
                     " OR m_category.parent_category_id = " + pid +
                     " OR 0 = " + pid + ")" +
                     "ORDER BY m_category.id ASC;";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The GetParentCategory.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetParentCategory()
        {
            strSql = "SELECT id, name from m_category;";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="category">The category<see cref="Category"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int Insert(Category category)
        {
            strSql = "INSERT INTO public.m_category(parent_category_id, name, description, is_deleted," +
                     "create_user_id, update_user_id, create_datetime, update_datetime, company_id) " +
                     "VALUES(@parent_category_id, @name, @description,@is_deleted," +
                     "@create_user_id, @update_user_id, @create_datetime, @update_datetime, @company_id) " +
                     "RETURNING id";

            NpgsqlParameter[] npgSqlParams = {
                    new NpgsqlParameter("@parent_category_id", category.parent_category_id),
                    new NpgsqlParameter("@name", category.name),
                    new NpgsqlParameter("@description", category.description),
                    new NpgsqlParameter("@is_deleted", category.is_deleted),
                    new NpgsqlParameter ("@create_user_id", category.create_user_id),
                    new NpgsqlParameter ("@update_user_id", category.update_user_id),
                    new NpgsqlParameter ("@create_datetime", category.create_datetime),
                    new NpgsqlParameter ("@update_datetime", category.update_datetime),
                    new NpgsqlParameter ("@company_id", 1)
            };

            var result = connection.ExecuteScalar(CommandType.Text, strSql, npgSqlParams);

            var returnID = Convert.ToInt32(result);

            return returnID;
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="shopCategory">The shopCategory<see cref="ShopCategory"/>.</param>
        /// <param name="id">The id<see cref="int?"/>.</param>
        public void Insert(ShopCategory shopCategory, int? id)
        {
            strSql = "INSERT INTO public.m_shop_category(category_id,shop_id," +
                     "create_user_id,update_user_id,create_datetime,update_datetime) " +
                     "VALUES(@id,@shop_id,@create_user_id,@update_user_id,@create_datetime,@update_datetime)";

            NpgsqlParameter[] npgSqlParams = {
                    new NpgsqlParameter("@id", id),
                    new NpgsqlParameter("@shop_id", shopCategory.shop_id),
                    new NpgsqlParameter ("@create_user_id",shopCategory.create_user_id),
                    new NpgsqlParameter ("@update_user_id",shopCategory.update_user_id),
                    new NpgsqlParameter ("@create_datetime",shopCategory.create_datetime),
                    new NpgsqlParameter ("@update_datetime",shopCategory.update_datetime)
            };

            connection.ExecuteNonQuery(CommandType.Text, strSql, npgSqlParams);
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="category">The category<see cref="Category"/>.</param>
        public void Update(Category category)
        {
            strSql = "UPDATE public.m_category SET id = @id, name = @name, description = @description, update_datetime = @update_datetime " +
                "WHERE id = @id;";

            NpgsqlParameter[] npgsqlParameter =
            {
                new NpgsqlParameter("@id", category.id),
                new NpgsqlParameter("@name", category.name),
                new NpgsqlParameter("@description", category.description),
                new NpgsqlParameter("@update_datetime", category.update_datetime)
            };

            connection.ExecuteNonQuery(CommandType.Text, strSql, npgsqlParameter);
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="category">The category<see cref="Category"/>.</param>
        public void Delete(Category category)
        {
            strSql = "UPDATE public.m_category SET is_deleted = 1 WHERE id = @id";

            NpgsqlParameter[] npgsqlParameters =
            {
                new NpgsqlParameter("@id", category.id),
                new NpgsqlParameter("@is_deleted", category.is_deleted)
            };

            connection.ExecuteNonQuery(CommandType.Text, strSql, npgsqlParameters);
        }

        /// <summary>
        /// The GetShopList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetShopList()
        {
            strSql = "SELECT id, name from m_shop where company_id = 1";

            var result = connection.ExecuteDataTable(CommandType.Text, strSql);
            return result;
        }
    }
}
