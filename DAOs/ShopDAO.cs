//<copyright file ="ShopDAO.cs"  company ="Seattle Consulting Myanmar">
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
    /// Defines the <see cref="ShopDAO" />.
    /// </summary>
    public class ShopDAO
    {
        /// <summary>
        /// Defines the strSql.
        /// </summary>
        private string strSql = String.Empty;

        /// <summary>
        /// Defines the connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        //Get Shop
        /// <summary>
        /// The GetShop.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetShop()
        {
            strSql = "SELECT id,name,address, phone_number_1, phone_number_2 FROM m_shop";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        //Get Shop Names
        /// <summary>
        /// The GetShopName.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetShopName()
        {
            strSql = "SELECT m_shop.name FROM public.m_shop";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The GetShopTypeList.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="Object"/>.</returns>
        public object GetShopTypeList(int? id)
        {
            strSql = "select shop_type from m_shop where id=" + id;

            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        //POST: Add Shop
        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="shop">The shop<see cref="Shop"/>.</param>
        public void Insert(Shop shop)
        {
            strSql = "INSERT INTO public.m_shop(name, address, phone_number_1, phone_number_2, shop_type," +
                "create_user_id, create_datetime, update_user_id, update_datetime, company_id, is_deleted) " +
                " VALUES (@name, @address,@phone_number_1, @phone_number_2, @shop_type, " +
                " @create_user_id, @create_datetime, @update_user_id, @update_datetime, @company_id, @is_deleted)";

            NpgsqlParameter[] npgsqlParameters =
            {
                new NpgsqlParameter("@name", shop.name),
                new NpgsqlParameter("@address", shop.address),
                new NpgsqlParameter("@phone_number_1", shop.phone_number_1),
                new NpgsqlParameter("@phone_number_2", shop.phone_number_2),
                new NpgsqlParameter("@shop_type", shop.shop_type),
                new NpgsqlParameter("@is_deleted", shop.is_deleted),
                new NpgsqlParameter("@create_user_id", shop.create_user_id),
                new NpgsqlParameter("@create_datetime", shop.create_datetime),
                new NpgsqlParameter("@update_user_id", shop.update_user_id),
                new NpgsqlParameter("@update_datetime", shop.update_datetime),
                new NpgsqlParameter("@company_id", shop.company_id)
            };

            connection.ExecuteNonQuery(CommandType.Text, strSql, npgsqlParameters);
        }

        //POST: Edit Shop
        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="shop">The shop<see cref="Shop"/>.</param>
        public void Update(Shop shop)
        {
            strSql = "UPDATE public.m_shop SET name = @name,address = @address,shop_type = @shop_type,phone_number_1 = @phone_number_1,phone_number_2=@phone_number_2,update_datetime=@update_datetime WHERE id=@id";
            NpgsqlParameter[] npgsqlParameters =
            {
                new NpgsqlParameter("@id", shop.id),
                new NpgsqlParameter("@name", shop.name),
                new NpgsqlParameter("@address", shop.address),
                new NpgsqlParameter("shop_type", shop.shop_type),
                new NpgsqlParameter("@phone_number_1", shop.phone_number_1),
                new NpgsqlParameter("@phone_number_2", shop.phone_number_2),
                new NpgsqlParameter("@update_datetime", shop.update_datetime)
            };
            connection.ExecuteNonQuery(CommandType.Text, strSql, npgsqlParameters);
        }

        //GET: Edit Shop
        /// <summary>
        /// The GetEdit.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetEdit()
        {
            strSql = "SELECT * FROM public.m_shop";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }
    }
}
