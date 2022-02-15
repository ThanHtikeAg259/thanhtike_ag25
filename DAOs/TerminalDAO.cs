//<copyright file ="TerminalDAO.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/1/2021</date>

namespace POS_OJT.DAOs
{
    using Npgsql;
    using POS_OJT.Config;
    using POS_OJT.Models;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="TerminalDAO" />.
    /// </summary>
    public class TerminalDAO
    {
        /// <summary>
        /// Defines the strSql.
        /// </summary>
        string strSql = string.Empty;

        /// <summary>
        /// Defines the connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// The GetTerminal.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetTerminal()
        {
            strSql = "SELECT m_terminal.id, m_terminal.name,  m_shop.name FROM m_terminal INNER JOIN m_shop on (m_terminal.shop_id=m_shop.id) WHERE m_terminal.is_deleted=0 ORDER BY m_terminal.name ASC";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The GetShopName.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetShopName()
        {
            strSql = "SELECT m_shop.id,m_shop.name FROM m_shop";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="terminal">The terminal<see cref="Terminal"/>.</param>
        public void Insert(Terminal terminal)
        {
            strSql = "INSERT INTO public.m_terminal(shop_id, name, create_user_id, create_datetime," +
                     "update_user_id, update_datetime, is_deleted) " +
                     " VALUES (@shop_id, @name, @create_user_id, @create_datetime," +
                     "@update_user_id, @update_datetime, @is_deleted);";

            NpgsqlParameter[] npgsqlParameters =
            {
                new NpgsqlParameter("@shop_id", terminal.shop_id),
                new NpgsqlParameter("@name", terminal.name),
                new NpgsqlParameter("@create_user_id", terminal.create_user_id),
                new NpgsqlParameter("@create_datetime", terminal.create_datetime),
                new NpgsqlParameter("@update_user_id", terminal.update_user_id),
                new NpgsqlParameter("@update_datetime", terminal.update_datetime),
                 new NpgsqlParameter("@is_deleted", terminal.is_deleted)
            };

            connection.ExecuteNonQuery(CommandType.Text, strSql, npgsqlParameters);
        }

        /// <summary>
        /// The GetEdit.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetEdit()
        {
            strSql = "SELECT m_terminal.id, m_terminal.name, m_shop.id, m_shop.name FROM public.m_terminal " +
                     " INNER JOIN m_shop ON m_terminal.shop_id = m_shop.id ;";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="terminal">The terminal<see cref="Terminal"/>.</param>
        public void Update(Terminal terminal)
        {
            strSql = "UPDATE public.m_terminal SET shop_id = @shop_id,name = @name, update_datetime = @update_datetime " +
                     " WHERE id = @id;";

            NpgsqlParameter[] npgsqlParameter =
            {
                new NpgsqlParameter("@id",terminal.id),
                new NpgsqlParameter("@shop_id",terminal.shop_id),
                new NpgsqlParameter("@name",terminal.name),
                new NpgsqlParameter("@update_datetime",terminal.update_datetime)
            };

            connection.ExecuteNonQuery(CommandType.Text, strSql, npgsqlParameter);
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="terminal">The terminal<see cref="Terminal"/>.</param>
        public void Delete(Terminal terminal)
        {
            strSql = "UPDATE public.m_terminal SET is_deleted = @is_deleted WHERE id = @id";

            NpgsqlParameter[] npgsqlParameters =
            {
                new NpgsqlParameter("@id",terminal.id),
                new NpgsqlParameter("@is_deleted",terminal.is_deleted)
            };

            connection.ExecuteNonQuery(CommandType.Text, strSql, npgsqlParameters);
        }
    }
}
