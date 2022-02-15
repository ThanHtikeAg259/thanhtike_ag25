//<copyright file ="StaffDAO.cs"  company ="Seattle Consulting Myanmar">
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
    /// Defines the <see cref="StaffDAO" />.
    /// </summary>
    public class StaffDAO
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
        /// The GetStaff.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetStaff()
        {
            strSql = "SELECT m_staff.id, m_staff.photo, m_staff.name, m_staff.staff_number, m_staff.role, m_staff.staff_type, m_staff.position, m_shop.name, " +
                    "m_staff.nrc_number, m_staff.join_from " +
                    "FROM m_staff " +
                    "INNER JOIN m_shop ON m_staff.shop_id = m_shop.id " +
                    "WHERE staff_status = 1 ORDER BY m_staff.id ASC ;";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The GetShop.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetShop()
        {
            strSql = "SELECT id, name FROM m_shop;";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="staff">The staff<see cref="Staff"/>.</param>
        public void Insert(Staff staff)
        {
            strSql = "INSERT INTO public.m_staff (staff_number, password, role, staff_type, position, bank_account_number, graduated_univeristy," +
                    "name, gender, nrc_number, dob, marital_status, race, city, address, photo, phone_number_1, phone_number_2, join_from," +
                    "join_to, staff_status, create_user_id, create_datetime, update_user_id, update_datetime, old_id, shop_id, company_id)" +
                    "VALUES (@staff_number, @password, @role, @staff_type, @position, @bank_account_number, @graduated_univeristy," +
                    "@name, @gender, @nrc_number, @dob, @marital_status, @race, @city, @address, @photo, @phone_number_1, @phone_number_2, @join_from," +
                    "@join_to, @staff_status, @create_user_id, @create_datetime, @update_user_id, @update_datetime, @old_id, @shop_id, @company_id)";

            NpgsqlParameter[] npgsqlParameters =
            {
                new NpgsqlParameter("@staff_number", staff.staff_number),
                new NpgsqlParameter("@password", staff.password),
                new NpgsqlParameter("@role", staff.role),
                new NpgsqlParameter("@staff_type", staff.staff_type),
                new NpgsqlParameter("@position", staff.position),
                new NpgsqlParameter("@bank_account_number", staff.bank_account_number),
                new NpgsqlParameter("@graduated_univeristy", staff.graduated_univeristy),
                new NpgsqlParameter("@name", staff.name),
                new NpgsqlParameter("@gender", staff.gender),
                new NpgsqlParameter("@nrc_number", staff.nrc_number),
                new NpgsqlParameter("@dob", staff.dob),
                new NpgsqlParameter("@marital_status", staff.marital_status),
                new NpgsqlParameter("@race", staff.race),
                new NpgsqlParameter("@city", staff.city),
                new NpgsqlParameter("@address", staff.address),
                new NpgsqlParameter("@photo", staff.photo),
                new NpgsqlParameter("@phone_number_1", staff.phone_number_1),
                new NpgsqlParameter("@phone_number_2", staff.phone_number_2),
                new NpgsqlParameter("@join_from", staff.join_from),
                new NpgsqlParameter("@join_to", staff.join_to),
                new NpgsqlParameter("@staff_status", staff.staff_status),
                new NpgsqlParameter("@create_user_id", staff.create_user_id),
                new NpgsqlParameter("@create_datetime", staff.create_datetime),
                new NpgsqlParameter("@update_user_id", staff.update_user_id),
                new NpgsqlParameter("@update_datetime", staff.update_datetime),
                new NpgsqlParameter("@old_id", staff.old_id),
                new NpgsqlParameter("@shop_id", staff.shop_id),
                new NpgsqlParameter("@company_id", staff.company_id)
            };
            connection.ExecuteNonQuery(CommandType.Text, strSql, npgsqlParameters);
        }

        /// <summary>
        /// The DisplayStaff.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="Object"/>.</returns>
        public Object DisplayStaff(int? id)
        {
            strSql = "select role from m_staff where id =" + id + ";";

            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The ShowPosition.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="Object"/>.</returns>
        public Object ShowPosition(int? id)
        {
            strSql = "select position from m_staff where id =" + id + ";";

            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The DisplayTypeList.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="Object"/>.</returns>
        public Object DisplayTypeList(int? id)
        {
            strSql = "select staff_type from m_staff where id =" + id + ";";

            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The GetSuperAdmin.
        /// </summary>
        /// <param name="role">The role<see cref="int?"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetSuperAdmin(int? role)
        {
            strSql = "SELECT staff_number FROM m_staff where staff_number like 'A%' and role = " + role + ";";

            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The GetCompanyAdmin.
        /// </summary>
        /// <param name="role">The role<see cref="int?"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetCompanyAdmin(int? role)
        {
            strSql = "SELECT staff_number FROM m_staff WHERE staff_number like 'CA%' and role =" + role + ";";

            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The GetShopAdmin.
        /// </summary>
        /// <param name="role">The role<see cref="int?"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetShopAdmin(int? role)
        {
            strSql = "SELECT staff_number FROM m_staff WHERE staff_number like 'SA%' and role = " + role + ";";

            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The GetWaiterStaff.
        /// </summary>
        /// <param name="role">The role<see cref="int?"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetWaiterStaff(int? role)
        {
            strSql = "SELECT staff_number FROM m_staff WHERE staff_number like 'WS%' and role = " + role + ";";

            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The GetKitchenStaff.
        /// </summary>
        /// <param name="role">The role<see cref="int?"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetKitchenStaff(int? role)
        {
            strSql = "SELECT staff_number FROM m_staff WHERE staff_number like 'KS%' and role = " + role + ";";
            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The GetCashierStaff.
        /// </summary>
        /// <param name="role">The role<see cref="int?"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetCashierStaff(int? role)
        {
            strSql = "SELECT staff_number FROM m_staff WHERE staff_number like 'CS%' and role=" + role + ";";

            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The GetSaleStaff.
        /// </summary>
        /// <param name="role">The role<see cref="int?"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetSaleStaff(int? role)
        {
            strSql = "SELECT staff_number FROM m_staff WHERE staff_number like 'SS%' and role = " + role + ";";

            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The GetStaffRole.
        /// </summary>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetStaffRole()
        {
            strSql = "SELECT role FROM m_staff ORDER BY staff_number DESC";

            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        /// <summary>
        /// The GetUserNo.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetUserNo()
        {
            strSql = "SELECT id, staff_number FROM m_staff;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The GetEdit.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetEdit()
        {
            strSql = "SELECT * FROM m_staff;";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="staff">The staff<see cref="Staff"/>.</param>
        public void Edit(Staff staff)
        {
            strSql = "UPDATE public.m_staff SET name = @name, role = @role, password = @password, position = @position, staff_type = @staff_type, " +
                     "nrc_number=@nrc_number, bank_account_number = @bank_account_number, gender = @gender, marital_status = @marital_status, " +
                     "phone_number_1 = @phone_number_1, phone_number_2 = @phone_number_2, dob = @dob, graduated_univeristy = @graduated_univeristy, " +
                     "race = @race, city = @city, address = @address, photo = @photo, join_from = @join_from, join_to =@join_to, shop_id = @shop_id WHERE id = @id";

            NpgsqlParameter[] npgsqlParameters =
            {
                new NpgsqlParameter("@id", staff.id),
                new NpgsqlParameter("@name", staff.name),
                new NpgsqlParameter("@role", staff.role),
                new NpgsqlParameter("@password", staff.password),
                new NpgsqlParameter("@position", staff.position),
                new NpgsqlParameter("@staff_type", staff.staff_type),
                new NpgsqlParameter("@nrc_number", staff.nrc_number),
                new NpgsqlParameter("@bank_account_number", staff.bank_account_number),
                new NpgsqlParameter("@gender", staff.gender),
                new NpgsqlParameter("@marital_status", staff.marital_status),
                new NpgsqlParameter("@phone_number_1", staff.phone_number_1),
                new NpgsqlParameter("@phone_number_2", staff.phone_number_2),
                new NpgsqlParameter("@dob", staff.dob),
                new NpgsqlParameter("@graduated_univeristy", staff.graduated_univeristy),
                new NpgsqlParameter("@race", staff.race),
                new NpgsqlParameter("@city", staff.city),
                new NpgsqlParameter("@address", staff.address),
                new NpgsqlParameter("@photo", staff.photo),
                new NpgsqlParameter("@join_from", staff.join_from),
                new NpgsqlParameter("@join_to", staff.join_to),
                new NpgsqlParameter("@shop_id", staff.shop_id)
            };
            connection.ExecuteNonQuery(CommandType.Text, strSql, npgsqlParameters);
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="staff">The staff<see cref="Staff"/>.</param>
        public void Delete(Staff staff)
        {
            strSql = "UPDATE m_staff SET staff_status = @staff_status WHERE id = @id";
            NpgsqlParameter[] npgsqlParameters =
            {
                new NpgsqlParameter("@id", staff.id),
                new NpgsqlParameter("@staff_status", staff.staff_status)
            };

            connection.ExecuteNonQuery(CommandType.Text, strSql, npgsqlParameters);
        }
    }
}
