//<copyright file ="WarehouseDAO.cs"  company ="Seattle Consulting Myanmar">
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
    /// Defines the <see cref="WarehouseDAO" />.
    /// </summary>
    public class WarehouseDAO
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
        /// The GetWarehouseCode.
        /// </summary>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetWarehouseCode()
        {
            strSql = "SELECT name FROM m_warehouse ORDER BY name DESC;";

            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The GetWarehouse.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetWarehouse()
        {
            strSql = "SELECT id,name,address,phone_number_1,phone_number_2 FROM m_warehouse WHERE is_deleted = 0;";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        //GET WAREHOUSE EDIT LIST
        /// <summary>
        /// The GetEdit.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetEdit()
        {
            strSql = "SELECT id,name,address,phone_number_1,phone_number_2 FROM m_warehouse";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="warehouse">The warehouse<see cref="Warehouse"/>.</param>
        public void Update(Warehouse warehouse)
        {
            strSql = "UPDATE public.m_warehouse SET name = @name, address = @address, " +
                "phone_number_1 = @phone_number_1, phone_number_2 = @phone_number_2, " +
                "update_datetime = @update_datetime WHERE id = @id;";

            NpgsqlParameter[] npgsqlParameter =
            {
                new NpgsqlParameter("@id",warehouse.id),
                new NpgsqlParameter("@name",warehouse.name),
                new NpgsqlParameter("@address",warehouse.address),
                new NpgsqlParameter("@phone_number_1",warehouse.phone_number_1),
                new NpgsqlParameter("@phone_number_2",warehouse.phone_number_2),
                new NpgsqlParameter("@update_datetime",warehouse.update_datetime)
            };
            connection.ExecuteNonQuery(CommandType.Text, strSql, npgsqlParameter);
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="warehouse">The warehouse<see cref="Warehouse"/>.</param>
        public void Insert(Warehouse warehouse)
        {
            strSql = "INSERT INTO public.m_warehouse(company_id,name,address,phone_number_1,phone_number_2,create_user_id,create_datetime," +
                "update_user_id,update_datetime,is_deleted) VALUES (@company_id, @name, @address, @phone_number_1, @phone_number_2, @create_user_id, " +
                "@create_datetime, @update_user_id, @update_datetime, @is_deleted) ";
            NpgsqlParameter[] npgsqlParameters =
            {
                new NpgsqlParameter("@company_id",warehouse.company_id),
                new NpgsqlParameter("@name",warehouse.name),
                new NpgsqlParameter("@address",warehouse.address),
                new NpgsqlParameter("@phone_number_1",warehouse.phone_number_1),
                new NpgsqlParameter("@phone_number_2",warehouse.phone_number_2),
                 new NpgsqlParameter("@create_user_id",warehouse.create_user_id),
                new NpgsqlParameter("@create_datetime",warehouse.create_datetime),
                new NpgsqlParameter("@update_user_id",warehouse.update_user_id),
                new NpgsqlParameter("@update_datetime",warehouse.update_datetime),
                 new NpgsqlParameter("@is_deleted",warehouse.is_deleted)
            };
            connection.ExecuteScalar(CommandType.Text, strSql, npgsqlParameters);
        }
    }
}
