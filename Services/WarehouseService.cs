//<copyright file ="WarehouseService.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>9/30/2021</date>

namespace POS_OJT.Services
{
    using POS_OJT.DAOs;
    using POS_OJT.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="WarehouseService" />.
    /// </summary>
    public class WarehouseService
    {
        /// <summary>
        /// Defines the warehouseDAO.
        /// </summary>
        private WarehouseDAO warehouseDAO = new WarehouseDAO();

        /// <summary>
        /// The GetWarehouseCode.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string GetWarehouseCode()
        {
            object warehouseCode = warehouseDAO.GetWarehouseCode();
            string warehouseName = string.Empty;
            if (warehouseCode == null)
            {
                warehouseName = "W001";
            }
            else
            {
                string codeNo = new string(warehouseCode.ToString().ToCharArray().Where(c => char.IsDigit(c)).ToArray());
                warehouseName = string.Format("{0:000}", Convert.ToInt32(codeNo) + 1);
                warehouseName = "W" + warehouseName;
            }
            return warehouseName;
        }

        /// <summary>
        /// The GetWarehouseList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetWarehouseList()
        {
            return warehouseDAO.GetWarehouse();
        }

        /// <summary>
        /// The GetEdit.
        /// </summary>
        /// <returns>The <see cref="List{Warehouse}"/>.</returns>
        public List<Warehouse> GetEdit()
        {
            List<Warehouse> warehouseList = new List<Warehouse>();
            DataTable dtWarehouseList = warehouseDAO.GetEdit();

            foreach (DataRow rows in dtWarehouseList.Rows)
            {
                warehouseList.Add(new Warehouse
                {
                    id = Convert.ToInt32(rows[0]),
                    name = Convert.ToString(rows[1]),
                    address = Convert.ToString(rows[2]),
                    phone_number_1 = Convert.ToString(rows[3]),
                    phone_number_2 = Convert.ToString(rows[4])
                });
            }
            return warehouseList;
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="warehouse">The warehouse<see cref="Warehouse"/>.</param>
        public void Update(Warehouse warehouse)
        {
            warehouseDAO.Update(warehouse);
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="warehouse">The warehouse<see cref="Warehouse"/>.</param>
        public void Insert(Warehouse warehouse)
        {
            warehouseDAO.Insert(warehouse);
        }
    }
}
