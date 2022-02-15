//<copyright file ="StaffService.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/4/2021</date>

namespace POS_OJT.Services
{
    using POS_OJT.DAOs;
    using POS_OJT.Models;
    using System;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="StaffService" />.
    /// </summary>
    public class StaffService
    {
        /// <summary>
        /// Defines the staffDao.
        /// </summary>
        private StaffDAO staffDao = new StaffDAO();

        /// <summary>
        /// Defines the userNumber, code.
        /// </summary>
        private string userNumber = string.Empty,
                       code = string.Empty;

        /// <summary>
        /// The GetStaff.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetStaff()
        {
            return staffDao.GetStaff();
        }

        /// <summary>
        /// The GetShop.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetShop()
        {
            return staffDao.GetShop();
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="staff">The staff<see cref="Staff"/>.</param>
        public void Insert(Staff staff)
        {
            staffDao.Insert(staff);
        }

        /// <summary>
        /// The GetSuperAdmin.
        /// </summary>
        /// <param name="role">The role<see cref="int?"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string GetSuperAdmin(int? role)
        {
            object staffCode = staffDao.GetSuperAdmin(role);

            if (staffCode == null)
            {
                userNumber = "A001";
            }
            else
            {
                code = new string(staffCode.ToString().ToCharArray().Where(c => char.IsDigit(c)).ToArray());
                userNumber = string.Format("{0:000}", Convert.ToInt32(code) + 1);
                userNumber = "A" + userNumber;
            }
            return userNumber;
        }

        /// <summary>
        /// The GetCompanyAdmin.
        /// </summary>
        /// <param name="role">The role<see cref="int?"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string GetCompanyAdmin(int? role)
        {
            object staffCode = staffDao.GetCompanyAdmin(role); //staffCode is too general. select role specific code number 

            if (staffCode == null)
            {
                userNumber = "CA001";
            }
            else
            {
                code = new string(staffCode.ToString().ToCharArray().Where(c => char.IsDigit(c)).ToArray());
                userNumber = string.Format("{0:000}", Convert.ToInt32(code) + 1);
                userNumber = "CA" + userNumber;
            }
            return userNumber;
        }

        /// <summary>
        /// The GetShopAdmin.
        /// </summary>
        /// <param name="role">The role<see cref="int?"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string GetShopAdmin(int? role)
        {
            object staffCode = staffDao.GetShopAdmin(role); //staffCode is too general. select role specific code number 

            if (staffCode == null)
            {
                userNumber = "SA001";
            }
            else
            {
                code = new string(staffCode.ToString().ToCharArray().Where(c => char.IsDigit(c)).ToArray());
                userNumber = string.Format("{0:000}", Convert.ToInt32(code) + 1);
                userNumber = "SA" + userNumber;
            }
            return userNumber;
        }

        /// <summary>
        /// The GetWaiterStaff.
        /// </summary>
        /// <param name="role">The role<see cref="int?"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string GetWaiterStaff(int? role)
        {
            object staffCode = staffDao.GetWaiterStaff(role); //staffCode is too general. select role specific code number 

            if (staffCode == null)
            {
                userNumber = "WS001";
            }
            else
            {
                code = new string(staffCode.ToString().ToCharArray().Where(c => char.IsDigit(c)).ToArray());
                userNumber = string.Format("{0:000}", Convert.ToInt32(code) + 1);
                userNumber = "WS" + userNumber;
            }
            return userNumber;
        }

        /// <summary>
        /// The GetKitchenStaff.
        /// </summary>
        /// <param name="role">The role<see cref="int?"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string GetKitchenStaff(int? role)
        {
            object staffCode = staffDao.GetKitchenStaff(role); //staffCode is too general. select role specific code number 

            if (staffCode == null)
            {
                userNumber = "KS001";
            }
            else
            {
                code = new string(staffCode.ToString().ToCharArray().Where(c => char.IsDigit(c)).ToArray());
                userNumber = string.Format("{0:000}", Convert.ToInt32(code) + 1);
                userNumber = "KS" + userNumber;
            }
            return userNumber;
        }

        /// <summary>
        /// The GetCashierStaff.
        /// </summary>
        /// <param name="role">The role<see cref="int?"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string GetCashierStaff(int? role)
        {
            object staffCode = staffDao.GetCashierStaff(role); //staffCode is too general. select role specific code number 

            if (staffCode == null)
            {
                userNumber = "CS001";
            }
            else
            {
                code = new string(staffCode.ToString().ToCharArray().Where(c => char.IsDigit(c)).ToArray());
                userNumber = string.Format("{0:000}", Convert.ToInt32(code) + 1);
                userNumber = "CS" + userNumber;
            }
            return userNumber;
        }

        /// <summary>
        /// The GetSaleStaff.
        /// </summary>
        /// <param name="role">The role<see cref="int?"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string GetSaleStaff(int? role)
        {
            object staffCode = staffDao.GetSaleStaff(role); //staffCode is too general. select role specific code number 

            if (staffCode == null)
            {
                userNumber = "SS001";
            }
            else
            {
                code = new string(staffCode.ToString().ToCharArray().Where(c => char.IsDigit(c)).ToArray());
                userNumber = string.Format("{0:000}", Convert.ToInt32(code) + 1);
                userNumber = "SS" + userNumber;
            }
            return userNumber;
        }

        /// <summary>
        /// The DisplayStaff.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="Object"/>.</returns>
        public Object DisplayStaff(int? id)
        {
            return staffDao.DisplayStaff(id);
        }

        /// <summary>
        /// The ShowPosition.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="Object"/>.</returns>
        public Object ShowPosition(int? id)
        {
            return staffDao.ShowPosition(id);
        }

        /// <summary>
        /// The DisplayTypeList.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="Object"/>.</returns>
        public Object DisplayTypeList(int? id)
        {
            return staffDao.DisplayTypeList(id);
        }

        /// <summary>
        /// The GetUserNo.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetUserNo()
        {
            return staffDao.GetUserNo();
        }

        /// <summary>
        /// The GetEdit.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetEdit()
        {
            return staffDao.GetEdit();
        }

        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="staff">The staff<see cref="Staff"/>.</param>
        public void Edit(Staff staff)
        {
            staffDao.Edit(staff);
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="staff">The staff<see cref="Staff"/>.</param>
        public void Delete(Staff staff)
        {
            staffDao.Delete(staff);
        }
    }
}
